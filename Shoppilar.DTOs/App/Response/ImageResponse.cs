using System.Linq.Expressions;
using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class ImageResponse
{
    public Guid? Id { get; set; }
    public string? Url { get; set; }


    public ImageResponse()
    {
    }

    public ImageResponse(Image entity)
    {
        Id = entity.Id;
        Url = entity.Url;
    }

    public static Expression<Func<Image, ImageResponse>> Projection
    {
        get
        {
            return entity => new ImageResponse
            {
                Id = entity.Id,
                Url = entity.Url
            };
        }
    }
}