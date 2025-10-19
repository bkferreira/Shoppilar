using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class AdPromotionResponse
{
    public Guid? Id { get; set; }
    
    public AdPromotionResponse()
    {
    }

    public AdPromotionResponse(AdPromotion entity)
    {
        Id = entity.Id;
    }
}