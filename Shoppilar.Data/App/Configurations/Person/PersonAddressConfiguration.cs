using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Person;

public class PersonAddressConfiguration : IEntityTypeConfiguration<PersonAddress>
{
    public void Configure(EntityTypeBuilder<PersonAddress> entity)
    {
        entity.Property(u => u.Street)
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(u => u.Neighborhood)
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(u => u.Number)
            .HasMaxLength(20)
            .IsRequired();

        entity.Property(u => u.Complement)
            .HasMaxLength(200);

        entity.Property(u => u.ZipCode)
            .HasMaxLength(20)
            .IsRequired();

        entity.HasOne(u => u.Person)
            .WithMany(u => u.Addresses)
            .HasForeignKey(u => u.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.City)
            .WithMany()
            .HasForeignKey(u => u.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasIndex(u => u.ZipCode);

        entity.HasIndex(u => new { u.PersonId, u.Standard });
    }
}