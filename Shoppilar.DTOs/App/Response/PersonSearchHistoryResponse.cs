using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class PersonSearchHistoryResponse
{
    public Guid? Id { get; set; }
    
    public PersonSearchHistoryResponse()
    {
    }

    public PersonSearchHistoryResponse(PersonSearchHistory entity)
    {
        Id = entity.Id;
    }
}