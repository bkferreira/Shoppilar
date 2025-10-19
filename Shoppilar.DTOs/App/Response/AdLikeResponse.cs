using System.Linq.Expressions;
using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class AdLikeResponse
{
    public Guid? Id { get; set; }

    public AdLikeResponse()
    {
    }

    public AdLikeResponse(AdLike entity)
    {
        Id = entity.Id;
    }

    public static Expression<Func<AdLike, AdLikeResponse>> Projection
    {
        get
        {
            return entity => new AdLikeResponse
            {
                Id = entity.Id,
            };
        }
    }
}