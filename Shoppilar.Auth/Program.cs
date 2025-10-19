using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shoppilar.Auth.DependencyInjection;
using Shoppilar.Data.Auth.Context;
using Shoppilar.Data.App.Context;
using Shoppilar.Data.App.Interceptor;
using Shoppilar.Data.Auth.Models;

var builder = WebApplication.CreateBuilder(args);

// Configura o Entity Framework Core para usar PostgreSQL
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PgConnection"),
        npgsqlOptions => npgsqlOptions.MigrationsAssembly("Shoppilar.Auth")
    ));

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

// Configura o ASP.NET Identity
builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
    {
        options.Password.RequireDigit = true;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;

        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddDefaultTokenProviders();

// Extensões personalizadas que registram os repositórios da camada Data
builder.Services.AddRepositories();

// Extensões personalizadas que registram os serviços da camada Application
builder.Services.AddServices();

// Adiciona controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Shoppilar Auth API",
        Version = "v1",
        Description = "Serviço de autenticação aberto, sem token 🔐"
    });
});

var app = builder.Build();

// Swagger apenas em desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shoppilar Auth API v1");
        c.DocumentTitle = "Shoppilar Auth Docs";
        c.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();