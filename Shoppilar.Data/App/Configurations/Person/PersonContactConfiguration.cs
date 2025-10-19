using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Person;

public class PersonContactConfiguration : IEntityTypeConfiguration<PersonContact>
{
    public void Configure(EntityTypeBuilder<PersonContact> entity)
    {
        entity.Property(u => u.ContactValue)
            .HasMaxLength(100)
            .IsRequired();

        entity.HasOne(u => u.Person)
            .WithMany(u => u.Contacts)
            .HasForeignKey(u => u.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.ContactType)
            .WithMany()
            .HasForeignKey(u => u.ContactTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasIndex(u => new { u.ContactValue })
            .IsUnique();

        entity.HasIndex(u => new { u.PersonId, u.Standard });
    }
}