using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class AdFeaturedResponse
{
    public Guid? Id { get; set; }
    
    public AdFeaturedResponse()
    {
    }

    public AdFeaturedResponse(AdFeatured entity)
    {
        Id = entity.Id;
    }
}