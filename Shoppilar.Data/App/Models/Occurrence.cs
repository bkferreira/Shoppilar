using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppilar.Data.App.Models;

[Table("occurrences")]
public class Occurrence : EntityBase
{
    #region Properties

    [Column("description")] public required string Description { get; set; }
    [Column("resolution_comment")] public string? ResolutionComment { get; set; }
    [Column("resolved")] public bool Resolved { get; set; }
    [Column("resolved_at")] public DateTime? ResolvedAt { get; set; }

    #endregion

    #region Foreign keys
    
    [Column("target_type_id")] public required Guid TargetTypeId { get; set; } // Identifica o alvo da ocorrência (Anúncio, Usuário, Evento etc.)
    [Column("target_id")] public required Guid TargetId { get; set; }
    [Column("reported_by_id")] public required Guid ReportedById { get; set; } // Quem denunciou
    [Column("occurrence_type_id")] public required Guid OccurrenceTypeId { get; set; }

    #endregion

    #region Navigation properties

    public Person? ReportedBy { get; set; }
    public OccurrenceType? OccurrenceType { get; set; }
    public TargetType? TargetType { get; set; }

    #endregion
}