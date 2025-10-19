using System.Linq.Expressions;
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

    public static Expression<Func<PersonSearchHistory, PersonSearchHistoryResponse>> Projection
    {
        get
        {
            return entity => new PersonSearchHistoryResponse
            {
                Id = entity.Id
            };
        }
    }
}