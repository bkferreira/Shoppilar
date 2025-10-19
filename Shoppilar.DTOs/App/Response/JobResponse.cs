using System.Linq.Expressions;
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

    public static Expression<Func<Job, JobResponse>> Projection
    {
        get
        {
            return entity => new JobResponse
            {
                Id = entity.Id
            };
        }
    }
}