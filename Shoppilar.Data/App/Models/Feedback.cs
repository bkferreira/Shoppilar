using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppilar.Data.App.Models;

[Table("feedbacks")]
public class Feedback : EntityBase
{
    #region Properties

    [Column("rating")] public required int Rating { get; set; } // Nota
    [Column("comment")] public string? Comment { get; set; }

    #endregion

    #region Foreign keys

    [Column("target_id")] public required Guid TargetId { get; set; } // ID da entidade avaliada
    [Column("target_type_id")] public required Guid TargetTypeId { get; set; } // Tipo da entidade: "Ad", "Event", "Job", "Person"
    [Column("person_id")] public required Guid PersonId { get; set; } // Quem está avaliando

    #endregion

    #region Navigation properties

    public Person? Person { get; set; }
    public TargetType? TargetType { get; set; }

    #endregion
}