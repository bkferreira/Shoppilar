using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class PersonSocialMediaResponse
{
    public Guid? Id { get; set; }
    
    public PersonSocialMediaResponse()
    {
    }

    public PersonSocialMediaResponse(PersonSocialMedia entity)
    {
        Id = entity.Id;
    }
}