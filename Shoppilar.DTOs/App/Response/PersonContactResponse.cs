using System.Linq.Expressions;
using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class PersonContactResponse
{
    public Guid? Id { get; set; }
    
    public PersonContactResponse()
    {
    }

    public PersonContactResponse(PersonContact entity)
    {
        Id = entity.Id;
    }

    public static Expression<Func<PersonContact, PersonContactResponse>> Projection
    {
        get
        {
            return entity => new PersonContactResponse
            {
                Id = entity.Id
            };
        }
    }
}