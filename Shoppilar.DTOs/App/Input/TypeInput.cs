using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class TypeInput
{
    public Guid? Id { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    public string? Color { get; set; }
    public int MaxImageCount { get; set; }
    public List<TypeInput>? SubTypes { get; set; }
    public Guid? AdTypeId { get; set; }


    public TypeInput()
    {
    }

    public TypeInput(BaseType entity)
    {
        Id = entity.Id;
        Description = entity.Description;
        Icon = entity.Icon;
        Color = entity.Color;

        switch (entity)
        {
            case JobType jobType:
                MaxImageCount = jobType.MaxImageCount;
                break;
            case EventType eventType:
                MaxImageCount = eventType.MaxImageCount;
                break;
            case AdType adType:
                MaxImageCount = adType.MaxImageCount;
                SubTypes = adType.SubTypes.Select(x => new TypeInput(x)).ToList();
                break;
            case AdSubType { AdType: not null } adSubType:
                AdTypeId = adSubType.AdTypeId;
                break;
        }
    }
}