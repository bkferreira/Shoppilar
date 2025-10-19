using System.Linq.Expressions;
using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class EventResponse
{
    public Guid? Id { get; set; }
    public List<ImageResponse>? Images { get; set; }
    
    public EventResponse()
    {
    }

    public EventResponse(Event entity)
    {
        Id = entity.Id;
        Images = entity.Images.Select(i => new ImageResponse(i)).ToList();
    }

    public static Expression<Func<Event, EventResponse>> Projection
    {
        get
        {
            return entity => new EventResponse
            {
                Id = entity.Id,
                Images = entity.Images.Select(i => new ImageResponse(i)).ToList()
            };
        }
    }
}