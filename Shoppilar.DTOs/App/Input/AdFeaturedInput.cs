using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class AdFeaturedInput
{
    public Guid? Id { get; set; }
    public Guid AdId { get; set; }
    public string Description { get; set; }
    public DateTime ExpirationDate { get; set; }

    public AdFeaturedInput()
    {
        
    }
    
    public AdFeaturedInput(AdFeatured entity)
    {
        Id = entity.Id;
        AdId = entity.AdId;
        Description = entity.Description;
        ExpirationDate = entity.ExpirationDate;
    }
}