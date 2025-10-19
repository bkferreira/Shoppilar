using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class EventInput
{
    public Guid? Id { get; set; }
    public Guid EventTypeId { get; set; }
    public Guid PersonId { get; set; }
    public Guid ContactTypeId { get; set; }
    public Guid CityId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Contact { get; set; }
    public string? ExternalUrl { get; set; }
    public string? Location { get; set; }
    public decimal? Price { get; set; }
    public bool IsPublic { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<ImageInput>? Images { get; set; }

    public EventInput()
    {
    }

    public EventInput(Event entity)
    {
        Id = entity.Id;
        EventTypeId = entity.EventTypeId;
        PersonId = entity.PersonId;
        ContactTypeId = entity.ContactTypeId;
        CityId = entity.CityId;
        Title = entity.Title;
        Description = entity.Description;
        Contact = entity.Contact;
        ExternalUrl = entity.ExternalUrl;
        Location = entity.Location;
        Price = entity.Price;
        IsPublic = entity.IsPublic;
        ExpirationDate = entity.ExpirationDate;
        StartDate = entity.StartDate;
        EndDate = entity.EndDate;
        Images = entity.Images?.Select(x => new ImageInput(x)).ToList();
    }
}