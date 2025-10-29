using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class PersonInput
{
    public Guid? Id { get; set; }
    public Guid? CreatedById { get; set; }
    public Guid PersonTypeId { get; set; }
    public string Name { get; set; }
    public DateTime? Birth { get; set; }
    public Guid? ImageId { get; set; }
    public List<PersonAddressInput>? Addresses { get; set; }
    public List<PersonDocumentInput>? Documents { get; set; }
    public List<PersonContactInput>? Contacts { get; set; }
    public List<PersonSocialMediaInput>? SocialMedias { get; set; }
    public ImageInput? Image { get; set; }

    public PersonInput()
    {
    }

    public PersonInput(Person entity)
    {
        Id = entity.Id;
        CreatedById = entity.CreatedById;
        PersonTypeId = entity.PersonTypeId;
        Name = entity.Name;
        ImageId = entity.ImageId;
        Birth = entity.Birth;
        Addresses = entity.Addresses?.Select(x => new PersonAddressInput(x)).ToList();
        Documents = entity.Documents?.Select(x => new PersonDocumentInput(x)).ToList();
        Contacts = entity.Contacts?.Select(x => new PersonContactInput(x)).ToList();
        SocialMedias = entity.SocialMedias?.Select(x => new PersonSocialMediaInput(x)).ToList();
    }
}