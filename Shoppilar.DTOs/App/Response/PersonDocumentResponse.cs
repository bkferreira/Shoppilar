using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class PersonDocumentResponse
{
    public Guid? Id { get; set; }
    
    public PersonDocumentResponse()
    {
    }

    public PersonDocumentResponse(PersonDocument entity)
    {
        Id = entity.Id;
    }
}