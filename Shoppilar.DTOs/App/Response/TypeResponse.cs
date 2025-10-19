using System.Linq.Expressions;
using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class TypeResponse
{
    public Guid? Id { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    public string? Color { get; set; }
    public int MaxImageCount { get; set; }
    public List<TypeResponse>? SubTypes { get; set; }
    public TypeResponse? AdType { get; set; }

    public TypeResponse(BaseType entity)
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
                SubTypes = adType.SubTypes.Select(x => new TypeResponse(x)).ToList();
                break;
            case AdSubType { AdType: not null } adSubType:
                AdType = new TypeResponse(adSubType.AdType);
                break;
        }
    }
}