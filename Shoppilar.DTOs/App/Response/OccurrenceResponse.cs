using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class OccurrenceResponse
{
    public Guid? Id { get; set; }
    
    public OccurrenceResponse()
    {
    }

    public OccurrenceResponse(Occurrence entity)
    {
        Id = entity.Id;
    }
}