using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class PersonSocialMediaInput
{
    public Guid? Id { get; set; }
    public Guid PersonId { get; set; }
    public Guid SocialMediaTypeId { get; set; }
    public string ProfileUrl { get; set; }

    public PersonSocialMediaInput()
    {
        
    }

    public PersonSocialMediaInput(PersonSocialMedia entity)
    {
        Id = entity.Id;
        PersonId = entity.PersonId;
        SocialMediaTypeId = entity.SocialMediaTypeId;
        ProfileUrl = entity.ProfileUrl;
    }
}