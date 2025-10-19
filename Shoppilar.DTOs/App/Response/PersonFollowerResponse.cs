using System.Linq.Expressions;
using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class PersonFollowerResponse
{
    public Guid? Id { get; set; }
    
    public PersonFollowerResponse()
    {
    }

    public PersonFollowerResponse(PersonFollower entity)
    {
        Id = entity.Id;
    }

    public static Expression<Func<PersonFollower, PersonFollowerResponse>> Projection
    {
        get
        {
            return entity => new PersonFollowerResponse
            {
                Id = entity.Id
            };
        }
    }
}