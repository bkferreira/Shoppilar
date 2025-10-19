using System.Linq.Expressions;
using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class AdResponse
{
    public Guid? Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Contact { get; set; }
    public int ViewsCount { get; set; }
    public decimal Price { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public bool Promotion { get; set; }
    public bool Donation { get; set; }
    public string? AdTypeDescription { get; set; }
    public string? AdSubTypeDescription { get; set; }
    public string? CityName { get; set; }
    public List<ImageResponse>? Images { get; set; }

    public AdResponse()
    {
    }

    public AdResponse(Ad entity)
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
        CityName = entity.City?.Name;
        AdTypeDescription = entity.AdType?.Description;
        AdSubTypeDescription = entity.AdSubType?.Description;
        Images = entity.Images.Select(i => new ImageResponse(i)).ToList();
    }

    public static Expression<Func<Ad, AdResponse>> Projection
    {
        get
        {
            return entity => new AdResponse
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Contact = entity.Contact,
                ViewsCount = entity.ViewsCount,
                Price = entity.Price,
                ExpirationDate = entity.ExpirationDate,
                Promotion = entity.Promotion,
                Donation = entity.Donation,
                CityName = entity.City!.Name,
                AdTypeDescription = entity.AdType!.Description,
                AdSubTypeDescription = entity.AdSubType!.Description,
                Images = entity.Images.Select(i => new ImageResponse(i)).ToList()
            };
        }
    }
}