using Shoppilar.Interfaces;
using Shoppilar.Services;

namespace Shoppilar.Api.DependencyInjection;

public static class RepositoryCollection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
    }
}