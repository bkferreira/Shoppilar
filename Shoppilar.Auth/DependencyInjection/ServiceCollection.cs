using Shoppilar.Interfaces.App;

using Shoppilar.Interfaces.Auth;
using Shoppilar.Services.App;
using Shoppilar.Services.Auth;

namespace Shoppilar.Auth.DependencyInjection;

public static class ServiceCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPersonService, PersonService>();
    }
}