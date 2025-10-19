using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class JobResponse
{
    public Guid? Id { get; set; }
    
    public JobResponse()
    {
    }

    public JobResponse(Job entity)
    {
        Id = entity.Id;
    }
}