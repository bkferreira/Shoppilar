using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class AdLikeInput
{
    public Guid? Id { get; set; }
    public Guid AdId { get; set; }
    public Guid PersonId { get; set; }

    public AdLikeInput()
    {
        
    }
    
    public AdLikeInput(AdLike entity)
    {
        Id = entity.Id;
        AdId = entity.AdId;
        PersonId = entity.PersonId;
    }
}