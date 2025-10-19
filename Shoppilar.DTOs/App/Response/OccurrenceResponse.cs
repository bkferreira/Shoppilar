using System.Linq.Expressions;
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

    public static Expression<Func<Occurrence, OccurrenceResponse>> Projection
    {
        get
        {
            return entity => new OccurrenceResponse
            {
                Id = entity.Id
            };
        }
    }
}