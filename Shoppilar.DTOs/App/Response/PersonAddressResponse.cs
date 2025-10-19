using System.Linq.Expressions;
using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class PersonAddressResponse
{
    public Guid? Id { get; set; }
    
    public PersonAddressResponse()
    {
    }

    public PersonAddressResponse(PersonAddress entity)
    {
        Id = entity.Id;
    }

    public static Expression<Func<PersonAddress, PersonAddressResponse>> Projection
    {
        get
        {
            return entity => new PersonAddressResponse
            {
                Id = entity.Id
            };
        }
    }
}