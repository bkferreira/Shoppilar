using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Activity;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> entity)
    {
        entity.Property(u => u.Description) // TODO: Criar FullTextSearch
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(u => u.Contact)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(u => u.Salary)
            .HasColumnType("decimal(18,2)");

        entity.Property(u => u.ExpirationDate).IsRequired();

        entity.HasOne(u => u.Person)
            .WithMany()
            .HasForeignKey(u => u.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.JobType)
            .WithMany()
            .HasForeignKey(u => u.JobTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(u => u.ContactType)
            .WithMany()
            .HasForeignKey(u => u.ContactTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasMany(u => u.Images)
            .WithOne(i => i.Job)
            .HasForeignKey(i => i.JobId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}