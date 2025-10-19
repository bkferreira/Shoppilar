using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppilar.Data.App.Models;

public abstract class EntityBase
{
    #region Properties

    [Key] [Column("id")] public Guid Id { get; set; } = Guid.NewGuid();
    [Column("cod")] public int Cod { get; set; }
    [Column("created_at")] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Column("updated_at")] public DateTime? UpdatedAt { get; set; }
    [Column("deleted_at")] public DateTime? DeletedAt { get; set; }
    [Column("is_deleted")] public bool IsDeleted { get; set; } = false;
    [Column("is_active")] public bool IsActive { get; set; } = true;
    [ConcurrencyCheck] [Column("version")] public int Version { get; set; } = 1;

    #endregion

    #region Foreign keys

    [Column("created_by_id")] public Guid? CreatedById { get; set; }
    [Column("updated_by_id")] public Guid? UpdatedById { get; set; }
    [Column("deleted_by_id")] public Guid? DeletedById { get; set; }

    #endregion
}