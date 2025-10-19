using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class StateResponse
{
    public Guid? Id { get; set; }
    
    public StateResponse()
    {
    }

    public StateResponse(State entity)
    {
        Id = entity.Id;
    }
}