using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class ImageInput
{
    public Guid? Id { get; set; }
    public Guid ImageTypeId { get; set; }
    public Guid? PersonId { get; set; }
    public Guid? AdId { get; set; }
    public Guid? JobId { get; set; }
    public Guid? EventId { get; set; }
    public long Size { get; set; }
    public string Url { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public string ContainerName { get; set; }

    public ImageInput()
    {
        
    }

    public ImageInput(Image entity)
    {
        Id = entity.Id;
        ImageTypeId = entity.ImageTypeId;
        PersonId = entity.PersonId;
        AdId = entity.AdId;
        JobId = entity.JobId;
        EventId = entity.EventId;
        Size = entity.Size;
        Url = entity.Url;
        FileName = entity.FileName;
        ContentType = entity.ContentType;
        ContainerName = entity.ContainerName;
    }
}