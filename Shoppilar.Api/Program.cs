using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shoppilar.Api.DependencyInjection;
using Shoppilar.Data.App.Context;
using Shoppilar.Data.App.Interceptor;
using Shoppilar.Data.Auth.Context;

var builder = WebApplication.CreateBuilder(args); // Cria o construtor da aplicação (ponto inicial do ASP.NET Core)

// Permite acessar informações do contexto HTTP em serviços (ex: usuário logado)
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Registra o interceptor de auditoria (usado pelo Entity Framework para logar quem criou/alterou entidades)
builder.Services.AddSingleton<AuditInfoInterceptor>();

// Configura o uso do EF Core com PostgreSQL e o interceptor de auditoria
builder.Services.AddDbContextFactory<AppDbContext>((serviceProvider, options) =>
{
    // Define a string de conexão do PostgreSQL e o assembly onde estão as migrações
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PgConnection"),
        optionsBuilder => optionsBuilder.MigrationsAssembly("Shoppilar.Api")
    );

    // Injeta o interceptor de auditoria para monitorar alterações no banco
    options.AddInterceptors(serviceProvider.GetRequiredService<AuditInfoInterceptor>());
});

// Configura o Entity Framework Core para usar PostgreSQL
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PgConnection"),
        npgsqlOptions => npgsqlOptions.MigrationsAssembly("Shoppilar.Auth")
    ));

// Lê as configurações do token JWT do appsettings.json (Issuer, Audience, Key)
var jwt = builder.Configuration.GetSection("Jwt");

// Adiciona o esquema de autenticação baseado em JWT Bearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Define as regras de validação do token
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Valida se o emissor (Issuer) é confiável
            ValidateAudience = true, // Valida se o público (Audience) é permitido
            ValidateLifetime = true, // Verifica se o token está dentro do prazo de validade
            ValidateIssuerSigningKey = true, // Verifica se a assinatura do token é válida
            ValidIssuer = jwt["Issuer"], // Emissor esperado (vem do appsettings)
            ValidAudience = jwt["Audience"], // Público esperado (vem do appsettings)
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwt["Key"]?.Trim() ?? string.Empty) // Chave secreta usada para validar o token
            ),
            ClockSkew = TimeSpan.Zero // Remove tolerância de tempo entre servidores (expira exatamente na hora certa)
        };

        // Define eventos de callback para logar erros ou sucesso na autenticação
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"❌ JWT inválido: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine($"✅ JWT válido para: {context.Principal?.Identity?.Name}");
                return Task.CompletedTask;
            }
        };
    });

// Define uma política de fallback: toda rota exige autenticação por padrão
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser() // Requer que o usuário esteja autenticado
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme) // Usa o esquema JWT como padrão
        .Build();
});

// Extensões personalizadas que registram os repositórios da camada Data
builder.Services.AddRepositories();

// Extensões personalizadas que registram os serviços da camada Application
builder.Services.AddServices();

// Adiciona os controllers (endpoints) e configura o JSON para evitar loops de referência
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer(); // Necessário para mapear endpoints pro Swagger

builder.Services.AddSwaggerGen(c =>
{
    // Define informações da API no Swagger
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Shoppilar API",
        Version = "v1",
        Description = "API oficial do Shoppilar 🚀"
    });

    // Adiciona a configuração do esquema de autenticação JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT **sem** o prefixo 'Bearer '.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http, // Define o tipo como HTTP (para o Swagger adicionar 'Bearer ' automaticamente)
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    // Exige autenticação JWT em todos os endpoints do Swagger
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    // Evita conflitos de nomes de classes nos modelos do Swagger
    c.CustomSchemaIds(type => type.FullName);
});

var app = builder.Build(); // Constrói a pipeline e os serviços configurados acima

// Middleware global para capturar e retornar erros em formato JSON
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.ContentType = "application/json"; // Resposta sempre em JSON
        var error = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>()?.Error;
        var result = System.Text.Json.JsonSerializer.Serialize(new
        {
            error = error?.Message ?? "Erro interno no servidor"
        });
        await context.Response.WriteAsync(result);
    });
});

// Ativa o Swagger apenas no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Gera o endpoint /swagger/v1/swagger.json
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelsExpandDepth(-1); // Oculta os modelos no painel para simplificar a visualização
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shoppilar API v1"); // Define o endpoint do Swagger
        c.DocumentTitle = "Shoppilar API Docs"; // Título da aba do navegador
    });
}

// Redireciona requisições HTTP para HTTPS automaticamente
app.UseHttpsRedirection();

// Adiciona o middleware de autenticação (valida tokens JWT nas requisições)
app.UseAuthentication();

// Adiciona o middleware de autorização (verifica permissões e políticas)
app.UseAuthorization();

// Mapeia automaticamente todos os controllers registrados
app.MapControllers();

// Executa a aplicação (mantém o servidor rodando e processando requisições)
app.Run();