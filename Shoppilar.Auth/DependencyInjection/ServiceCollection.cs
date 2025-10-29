using Shoppilar.Interfaces.App;
using Shoppilar.Interfaces.Auth;
using Shoppilar.Interfaces.Ext;
using Shoppilar.Services.App;
using Shoppilar.Services.Auth;
using Shoppilar.Services.Ext;

namespace Shoppilar.Auth.DependencyInjection;

public static class ServiceCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IVerificationCodeService, VerificationCodeService>();
        services.AddScoped<IPersonService, PersonService>();
        services.AddHttpClient<ISmsService, SmsService>((sp, client) =>
        {
            var config = sp.GetRequiredService<IConfiguration>();
            client.BaseAddress = new Uri(config["Sms:BaseUrl"]!);
            client.DefaultRequestHeaders.Add("auth-key", config["Sms:AuthKey"]!);
            client.Timeout = TimeSpan.FromSeconds(10);
        });
    }
}