using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class FavoriteInput
{
    public Guid? Id { get; set; }
    public Guid TargetId { get; set; }
    public Guid TargetTypeId { get; set; }
    public Guid PersonId { get; set; }

    public FavoriteInput()
    {
        
    }

    public FavoriteInput(Favorite entity)
    {
        Id = entity.Id;
        TargetId = entity.TargetId;
        TargetTypeId = entity.TargetTypeId;
        PersonId = entity.PersonId;
    }
}