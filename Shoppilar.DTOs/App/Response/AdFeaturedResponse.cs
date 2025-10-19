using System.Linq.Expressions;
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

    public static Expression<Func<AdFeatured, AdFeaturedResponse>> Projection
    {
        get
        {
            return entity => new AdFeaturedResponse
            {
                Id = entity.Id,
            };
        }
    }
}