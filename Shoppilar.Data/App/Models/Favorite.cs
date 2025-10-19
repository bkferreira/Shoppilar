using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppilar.Data.App.Models;

[Table("favorites")]
public class Favorite : EntityBase
{
    #region Foreign keys

    [Column("target_id")] public required Guid TargetId { get; set; } // ID da entidade favoritada
    [Column("target_type_id")] public required Guid TargetTypeId { get; set; } // Tipo da entidade: "Ad", "Event", "Job", "Person"
    [Column("person_id")] public required Guid PersonId { get; set; } // Usuário que favoritou

    #endregion

    #region Navigation properties

    public Person? Person { get; set; }
    public TargetType? TargetType { get; set; }

    #endregion
}