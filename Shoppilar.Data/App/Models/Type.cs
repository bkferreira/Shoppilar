using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppilar.Data.App.Models;

public abstract class BaseType : EntityBase
{
    #region Properties

    [Column("description")] public required string Description { get; set; }
    [Column("icon")] public string? Icon { get; set; }
    [Column("color")] public string? Color { get; set; }

    #endregion
}

[Table("document_types")]
public class DocumentType : BaseType
{
}

[Table("contact_types")]
public class ContactType : BaseType
{
}

[Table("occurrence_types")]
public class OccurrenceType : BaseType
{
}

[Table("target_types")]
public class TargetType : BaseType
{
}

[Table("category_types")]
public class CategoryType : BaseType
{
}

[Table("person_types")]
public class PersonType : BaseType
{
}

[Table("image_types")]
public class ImageType : BaseType
{
}

[Table("job_types")]
public class JobType : BaseType
{
    #region Properties

    [Column("max_image_count")] public int MaxImageCount { get; set; }

    #endregion
}

[Table("event_types")]
public class EventType : BaseType
{
    #region Properties

    [Column("max_image_count")] public int MaxImageCount { get; set; }

    #endregion
}

[Table("social_media_types")]
public class SocialMediaType : BaseType
{
}

[Table("ad_types")]
public class AdType : BaseType
{
    #region Properties

    [Column("max_image_count")] public int MaxImageCount { get; set; }

    #endregion

    #region Collections

    public ICollection<AdSubType> SubTypes { get; set; } = new List<AdSubType>();

    #endregion
}

[Table("ad_sub_types")]
public class AdSubType : BaseType
{
    #region Foreign keys

    [Column("ad_type_id")] public required Guid AdTypeId { get; set; }

    #endregion

    #region Navigation properties

    public AdType? AdType { get; set; }

    #endregion
}