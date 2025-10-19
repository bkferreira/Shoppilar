using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class PersonSearchHistoryInput
{
    public Guid? Id { get; set; }
    public Guid PersonId { get; set; }
    public string Query { get; set; }
    public DateTime SearchedAt { get; set; }

    public PersonSearchHistoryInput()
    {
    }

    public PersonSearchHistoryInput(PersonSearchHistory entity)
    {
        Id = entity.Id;
        PersonId = entity.PersonId;
        Query = entity.Query;
        SearchedAt = entity.SearchedAt;
    }
}