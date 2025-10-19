using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Location;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> entity)
    {
        entity.Property(u => u.Name)
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(u => u.Uf)
            .HasMaxLength(2)
            .IsFixedLength()
            .IsRequired();

        entity.Property(u => u.IbgeCode)
            .HasMaxLength(100)
            .IsRequired();

        entity.HasMany(u => u.Cities)
            .WithOne(c => c.State)
            .HasForeignKey(c => c.StateId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasIndex(u => u.Name);

        entity.HasIndex(u => u.IbgeCode).IsUnique();

        entity.HasIndex(u => u.Uf).IsUnique();
    }
}