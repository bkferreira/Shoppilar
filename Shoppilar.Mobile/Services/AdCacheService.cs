using Shoppilar.Mobile.Interfaces;
using Shoppilar.Mobile.Models;

namespace Shoppilar.Mobile.Services;

public class AdCacheService(IBaseRepository<AdCache> anuncioRepository) : IAdCacheService
{
    public Task<List<AdCache>> GetFeedAsync()
    {
        return anuncioRepository.GetAllAsync();
    }

    public async Task RefreshFeedAsync(List<AdCache> ads)
    {
        await anuncioRepository.DeleteAllAsync();
        await anuncioRepository.SaveAllAsync(ads);
    }

    public Task UpdateAnuncioAsync(AdCache ad)
    {
        return anuncioRepository.SaveAsync(ad);
    }

    public async Task<AdCache?> GetAnuncioByApiIdAsync(Guid id)
    {
        var list = await anuncioRepository.GetFilteredAsync(a => a.Id == id);
        return list.FirstOrDefault();
    }
}