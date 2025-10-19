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
}