using Shoppilar.Data.App.Models;

namespace Shoppilar.DTOs.App.Input;

public class JobInput
{
    public Guid? Id { get; set; }
    public Guid JobTypeId { get; set; }
    public Guid PersonId { get; set; }
    public Guid ContactTypeId { get; set; }
    public string Description { get; set; }
    public string Contact { get; set; }
    public DateTime ExpirationDate { get; set; }
    public decimal? Salary { get; set; }
    public List<ImageInput>? Images { get; set; }

    public JobInput()
    {
        
    }

    public JobInput(Job entity)
    {
        Id = entity.Id;
        JobTypeId = entity.JobTypeId;
        PersonId = entity.PersonId;
        ContactTypeId = entity.ContactTypeId;
        Description = entity.Description;
        Contact = entity.Contact;
        ExpirationDate = entity.ExpirationDate;
        Salary = entity.Salary;
        Images = entity.Images?.Select(x => new ImageInput(x)).ToList();
    }
}