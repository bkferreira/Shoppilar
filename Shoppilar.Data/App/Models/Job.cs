using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppilar.Data.App.Models;

[Table("jobs")]
public class Job : EntityBase
{
    #region Properties

    [Column("description")] public required string Description { get; set; }
    [Column("contact")] public required string Contact { get; set; }
    [Column("expiration_date")] public required DateTime ExpirationDate { get; set; }
    [Column("salary")] public decimal? Salary { get; set; }

    #endregion

    #region Foreign keys

    [Column("job_type_id")] public required Guid JobTypeId { get; set; }
    [Column("person_id")] public required Guid PersonId { get; set; }
    [Column("contact_type_id")] public required Guid ContactTypeId { get; set; }

    #endregion

    #region Navigation properties

    public JobType? JobType { get; set; }
    public Person? Person { get; set; }
    public ContactType? ContactType { get; set; }

    #endregion

    #region Collections

    public ICollection<Image> Images { get; set; } = new List<Image>();

    #endregion
}