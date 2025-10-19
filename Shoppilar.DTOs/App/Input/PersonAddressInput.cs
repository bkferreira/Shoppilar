using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class PersonAddressInput
{
    public Guid? Id { get; set; }
    public Guid PersonId { get; set; }
    public Guid CityId { get; set; }
    public string Street { get; set; }
    public string Neighborhood { get; set; }
    public string Number { get; set; }
    public string? Complement { get; set; }
    public string ZipCode { get; set; }
    public bool Standard { get; set; }

    public PersonAddressInput()
    {
        
    }

    public PersonAddressInput(PersonAddress entity)
    {
        Id = entity.Id;
        PersonId = entity.PersonId;
        CityId = entity.CityId;
        Street = entity.Street;
        Neighborhood = entity.Neighborhood;
        Number = entity.Number;
        Complement = entity.Complement;
        ZipCode = entity.ZipCode;
        Standard = entity.Standard;
    }
}