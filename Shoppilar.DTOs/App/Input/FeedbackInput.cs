using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class FeedbackInput
{
    public Guid? Id { get; set; }
    public Guid TargetId { get; set; }
    public Guid TargetTypeId { get; set; }
    public Guid PersonId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }

    public FeedbackInput()
    {
        
    }

    public FeedbackInput(Feedback entity)
    {
        Id = entity.Id;
        TargetId = entity.TargetId;
        TargetTypeId = entity.TargetTypeId;
        PersonId = entity.PersonId;
        Rating = entity.Rating;
        Comment = entity.Comment;
    }
}