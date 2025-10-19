using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppilar.Data.App.Models;

[Table("images")]
public class Image : EntityBase
{
    #region Properties

    [Column("size")] public required long Size { get; set; }
    [Column("url")] public required string Url { get; set; }
    [Column("file_name")] public required string FileName { get; set; }
    [Column("content_type")] public required string ContentType { get; set; }
    [Column("container_name")] public required string ContainerName { get; set; }

    #endregion

    #region Foreign keys

    [Column("image_type_id")] public required Guid ImageTypeId { get; set; }
    [Column("person_id")] public Guid? PersonId { get; set; }
    [Column("ad_id")] public Guid? AdId { get; set; }
    [Column("job_id")] public Guid? JobId { get; set; }
    [Column("event_id")] public Guid? EventId { get; set; }

    #endregion

    #region Navigation properties

    public Person? Person { get; set; }
    public Ad? Ad { get; set; }
    public Job? Job { get; set; }
    public Event? Event { get; set; }
    public ImageType? ImageType { get; set; }

    #endregion
}