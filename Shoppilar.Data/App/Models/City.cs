using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppilar.Data.App.Models;

[Table("cities")]
public class City : EntityBase
{
    #region Properties

    [Column("name")] public required string Name { get; set; }
    [Column("ibge_code")] public required string IbgeCode { get; set; }

    #endregion

    #region Foreign keys

    [Column("state_id")] public required Guid StateId { get; set; }

    #endregion

    #region Navigation properties

    public State? State { get; set; }

    #endregion
}

[Table("states")]
public class State : EntityBase
{
    #region Properties

    [Column("name")] public required string Name { get; set; }
    [Column("uf")] public required string Uf { get; set; }
    [Column("ibge_code")] public required string IbgeCode { get; set; }

    #endregion

    #region Collections

    public ICollection<City> Cities { get; set; } = new List<City>();

    #endregion
}