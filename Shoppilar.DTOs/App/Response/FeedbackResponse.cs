using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Response;

public class FeedbackResponse
{
    public Guid? Id { get; set; }
    
    public FeedbackResponse()
    {
    }

    public FeedbackResponse(Feedback entity)
    {
        Id = entity.Id;
    }
}