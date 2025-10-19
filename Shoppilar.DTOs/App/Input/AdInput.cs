using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class AdInput
{
    public Guid? Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Contact { get; set; }
    public int ViewsCount { get; set; }
    public decimal Price { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool Promotion { get; set; }
    public bool Donation { get; set; }
    public Guid CityId { get; set; }
    public Guid PersonId { get; set; }
    public Guid AdTypeId { get; set; }
    public Guid AdSubTypeId { get; set; }
    public List<AdPromotionInput>? Promotions { get; set; }
    public List<AdFeaturedInput>? FeaturedItems { get; set; }
    public List<ImageInput>? Images { get; set; }

    public AdInput()
    {
    }

    public AdInput(Ad entity)
    {
        Id = entity.Id;
        Title = entity.Title;
        Description = entity.Description;
        Contact = entity.Contact;
        ViewsCount = entity.ViewsCount;
        Price = entity.Price;
        ExpirationDate = entity.ExpirationDate;
        Promotion = entity.Promotion;
        Donation = entity.Donation;
        CityId = entity.CityId;
        PersonId = entity.PersonId;
        AdTypeId = entity.AdTypeId;
        AdSubTypeId = entity.AdSubTypeId;
        Promotions = entity.Promotions?.Select(x => new AdPromotionInput(x)).ToList();
        FeaturedItems = entity.FeaturedItems?.Select(x => new AdFeaturedInput(x)).ToList();
        Images = entity.Images?.Select(x => new ImageInput(x)).ToList();
    }
}