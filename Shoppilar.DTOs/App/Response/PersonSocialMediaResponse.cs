using System.Linq.Expressions;
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

    public static Expression<Func<PersonSocialMedia, PersonSocialMediaResponse>> Projection
    {
        get
        {
            return entity => new PersonSocialMediaResponse
            {
                Id = entity.Id
            };
        }
    }
}