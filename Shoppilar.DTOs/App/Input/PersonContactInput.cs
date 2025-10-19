using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class PersonContactInput
{
    public Guid? Id { get; set; }
    public Guid PersonId { get; set; }
    public Guid ContactTypeId { get; set; }
    public string ContactValue { get; set; }
    public bool Standard { get; set; }

    public PersonContactInput()
    {
        
    }

    public PersonContactInput(PersonContact entity)
    {
        Id = entity.Id;
        PersonId = entity.PersonId;
        ContactTypeId = entity.ContactTypeId;
        ContactValue = entity.ContactValue;
        Standard = entity.Standard;
    }
}