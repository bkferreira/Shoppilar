using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class PersonFollowerInput
{
    public Guid? Id { get; set; }
    public Guid FollowerId { get; set; }
    public Guid FollowedId { get; set; }

    public PersonFollowerInput()
    {
        
    }

    public PersonFollowerInput(PersonFollower entity)
    {
        Id = entity.Id;
        FollowerId = entity.FollowerId;
        FollowedId = entity.FollowedId;
    }
}