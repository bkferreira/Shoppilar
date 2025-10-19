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
}