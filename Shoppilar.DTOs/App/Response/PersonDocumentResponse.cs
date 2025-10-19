using System.Linq.Expressions;
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
    
    public static Expression<Func<PersonDocument, PersonDocumentResponse>> Projection
    {
        get
        {
            return entity => new PersonDocumentResponse
            {
                Id = entity.Id
            };
        }
    }
}