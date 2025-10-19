using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class AdPromotionInput
{
    public Guid? Id { get; set; }
    public Guid AdId { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime ExpirationDate { get; set; }

    public AdPromotionInput()
    {
        
    }

    public AdPromotionInput(AdPromotion entity)
    {
        Id = entity.Id;
        AdId = entity.AdId;
        Description = entity.Description;
        Price = entity.Price;
        ExpirationDate = entity.ExpirationDate;
    }
}