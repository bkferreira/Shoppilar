using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Location;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> entity)
    {
        entity.Property(u => u.Name)
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(u => u.IbgeCode)
            .HasMaxLength(100)
            .IsRequired();

        entity.HasOne(u => u.State)
            .WithMany(u => u.Cities)
            .HasForeignKey(u => u.StateId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasIndex(u => u.Name);
        entity.HasIndex(u => u.IbgeCode).IsUnique();
    }
}