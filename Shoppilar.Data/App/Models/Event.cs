using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppilar.Data.App.Models;

[Table("events")]
public class Event : EntityBase
{
    #region Properties

    [Column("title")] public required string Title { get; set; }
    [Column("description")] public required string Description { get; set; }
    [Column("contact")] public required string Contact { get; set; }
    [Column("external_url")] public string? ExternalUrl { get; set; }
    [Column("location")] public string? Location { get; set; }
    [Column("price")] public decimal? Price { get; set; }
    [Column("is_public")] public bool IsPublic { get; set; } = true;
    [Column("expiration_date")] public required DateTime ExpirationDate { get; set; }
    [Column("start_date")] public required DateTime StartDate { get; set; }
    [Column("end_date")] public required DateTime EndDate { get; set; }

    #endregion

    #region Foreign keys

    [Column("event_type_id")] public required Guid EventTypeId { get; set; }
    [Column("person_id")] public required Guid PersonId { get; set; }
    [Column("contact_type_id")] public required Guid ContactTypeId { get; set; }
    [Column("city_id")] public required Guid CityId { get; set; }

    #endregion

    #region Navigation properties

    public EventType? EventType { get; set; }
    public Person? Person { get; set; }
    public ContactType? ContactType { get; set; }
    public City? City { get; set; }

    #endregion

    #region Collections

    public ICollection<Image> Images { get; set; } = new List<Image>();

    #endregion
}