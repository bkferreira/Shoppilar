using Shoppilar.Mobile.Interfaces;
using Shoppilar.Mobile.Services;
using SQLite;

namespace Shoppilar.Mobile.DependencyInjection;

public static class CacheCollection
{
    public static void AddCacheServices(this IServiceCollection services)
    {
        services.AddSingleton<SQLiteAsyncConnection>(_ =>
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "shoppilar_cache.db3");
            return new SQLiteAsyncConnection(dbPath);
        });
        services.AddSingleton<IDatabaseService, DatabaseService>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IAdCacheService, AdCacheService>();
    }
}