using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class PersonDocumentInput
{
    public Guid? Id { get; set; }
    public Guid? CategoryTypeId { get; set; }
    public Guid PersonId { get; set; }
    public Guid DocumentTypeId { get; set; }
    public string DocumentNumber { get; set; }
    public DateTime? Validate { get; set; }
    public bool Standard { get; set; }

    public PersonDocumentInput()
    {
        
    }

    public PersonDocumentInput(PersonDocument entity)
    {
        Id = entity.Id;
        CategoryTypeId = entity.CategoryTypeId;
        PersonId = entity.PersonId;
        DocumentTypeId = entity.DocumentTypeId;
        DocumentNumber = entity.DocumentNumber;
        Validate = entity.Validate;
        Standard = entity.Standard;
    }
}