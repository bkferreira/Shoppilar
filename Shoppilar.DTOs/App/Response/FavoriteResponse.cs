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
}