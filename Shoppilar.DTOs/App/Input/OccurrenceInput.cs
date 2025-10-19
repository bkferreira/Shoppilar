using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class OccurrenceInput
{
    public Guid? Id { get; set; }
    public Guid TargetTypeId { get; set; }
    public Guid TargetId { get; set; }
    public Guid ReportedById { get; set; }
    public Guid OccurrenceTypeId { get; set; }
    public string Description { get; set; }
    public string? ResolutionComment { get; set; }
    public bool Resolved { get; set; }
    public DateTime? ResolvedAt { get; set; }

    public OccurrenceInput()
    {
        
    }

    public OccurrenceInput(Occurrence entity)
    {
        Id = entity.Id;
        TargetTypeId = entity.TargetTypeId;
        TargetId = entity.TargetId;
        ReportedById = entity.ReportedById;
        OccurrenceTypeId = entity.OccurrenceTypeId;
        Description = entity.Description;
        ResolutionComment = entity.ResolutionComment;
        Resolved = entity.Resolved;
        ResolvedAt = entity.ResolvedAt;
    }
}