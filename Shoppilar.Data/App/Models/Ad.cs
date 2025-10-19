using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppilar.Data.App.Models;

[Table("ads")]
public class Ad : EntityBase
{
    #region Properties

    [Column("title")] public required string Title { get; set; }
    [Column("description")] public required string Description { get; set; }
    [Column("contact")] public required string Contact { get; set; }
    [Column("views_count")] public int ViewsCount { get; set; }
    [Column("price")] public decimal Price { get; set; }
    [Column("expiration_date")] public required DateTime ExpirationDate { get; set; }
    [Column("promotion")] public bool Promotion { get; set; }
    [Column("donation")] public bool Donation { get; set; }

    #endregion

    #region Foreign keys

    [Column("city_id")] public required Guid CityId { get; set; }
    [Column("person_id")] public required Guid PersonId { get; set; }
    [Column("ad_type_id")] public required Guid AdTypeId { get; set; }
    [Column("ad_sub_type_id")] public required Guid AdSubTypeId { get; set; }

    #endregion

    #region Navigation properties

    public AdType? AdType { get; set; }
    public City? City { get; set; }
    public Person? Person { get; set; }
    public AdSubType? AdSubType { get; set; }

    #endregion

    #region Collections

    public ICollection<AdLike> Likes { get; set; } = new List<AdLike>();
    public ICollection<AdPromotion> Promotions { get; set; } = new List<AdPromotion>();
    public ICollection<AdFeatured> FeaturedItems { get; set; } = new List<AdFeatured>(); //Destaques
    public ICollection<Image> Images { get; set; } = new List<Image>();

    #endregion
}

[Table("ad_likes")]
public class AdLike : EntityBase
{
    #region Foreign keys

    [Column("ad_id")] public required Guid AdId { get; set; }
    [Column("person_id")] public required Guid PersonId { get; set; }

    #endregion

    #region Navigation properties

    public Ad? Ad { get; set; }
    public Person? Person { get; set; }

    #endregion
}

[Table("ad_promotions")]
public class AdPromotion : EntityBase
{
    #region Properties

    [Column("description")] public required string Description { get; set; }
    [Column("price")] public required decimal Price { get; set; }
    [Column("expiration_date")] public required DateTime ExpirationDate { get; set; }

    #endregion

    #region Foreign keys

    [Column("ad_id")] public required Guid AdId { get; set; }

    #endregion

    #region Navigation properties

    public Ad? Ad { get; set; }

    #endregion
}

[Table("ad_featured")]
public class AdFeatured : EntityBase
{
    #region Properties

    [Column("description")] public required string Description { get; set; }
    [Column("expiration_date")] public required DateTime ExpirationDate { get; set; }

    #endregion

    #region Foreign keys

    [Column("ad_id")] public required Guid AdId { get; set; }

    #endregion

    #region Navigation properties

    public Ad? Ad { get; set; }

    #endregion
}