using System.Linq.Expressions;
using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class FavoriteResponse
{
    public Guid? Id { get; set; }
    
    public FavoriteResponse()
    {
    }

    public FavoriteResponse(Favorite entity)
    {
        Id = entity.Id;
    }
    
    public static Expression<Func<Favorite, FavoriteResponse>> Projection
    {
        get
        {
            return entity => new FavoriteResponse
            {
                Id = entity.Id,
            };
        }
    }
}