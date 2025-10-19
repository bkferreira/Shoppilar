using System.Linq.Expressions;
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

    public static Expression<Func<City, CityResponse>> Projection
    {
        get
        {
            return entity => new CityResponse
            {
                Id = entity.Id,
            };
        }
    }
}