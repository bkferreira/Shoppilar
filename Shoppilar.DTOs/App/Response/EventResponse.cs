using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class EventResponse
{
    public Guid? Id { get; set; }
    
    public EventResponse()
    {
    }

    public EventResponse(Event entity)
    {
        Id = entity.Id;
    }
}