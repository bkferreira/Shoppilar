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
}