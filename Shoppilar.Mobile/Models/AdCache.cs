using SQLite;

namespace Shoppilar.Mobile.Models;

[Table("ads")]
public class AdCache : IBaseCacheModel
{
    [PrimaryKey, AutoIncrement]
    [Column("local_id")]
    public int LocalId { get; set; }

    [Indexed] [Column("id")] public Guid Id { get; set; }

    [Column("title")] public string? Titulo { get; set; }

    [Column("price")] public decimal Preco { get; set; }

    [Column("image_url")] public string? ImageUrl { get; set; }

    [Column("like_count")] public int ContagemCurtidas { get; set; }

    [Column("liked_user")] public bool UsuarioCurtiu { get; set; }
}