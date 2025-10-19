using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class PersonResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Birth { get; set; }
    public string? PersonTypeDesc { get; set; }
    public string? Image { get; set; }


    public PersonResponse()
    {
    }

    public PersonResponse(Person entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Birth = entity.Birth.ToString("dd/MM/yyyy");
        PersonTypeDesc = entity.PersonType?.Description;
        Image = entity.Image?.Url;
    }
}