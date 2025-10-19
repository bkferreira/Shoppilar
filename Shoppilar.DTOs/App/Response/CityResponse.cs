using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class CityResponse
{
    public Guid? Id { get; set; }
    
    public CityResponse()
    {
    }

    public CityResponse(City entity)
    {
        Id = entity.Id;
    }
}