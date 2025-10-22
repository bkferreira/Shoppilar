using Shoppilar.Mobile.Models;

namespace Shoppilar.Mobile.Interfaces;

public interface IAdCacheService
{
    Task<List<AdCache>> GetFeedAsync();
    Task RefreshFeedAsync(List<AdCache> ads);
    Task UpdateAnuncioAsync(AdCache ad);
    Task<AdCache?> GetAnuncioByApiIdAsync(Guid id);
}