using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Interaction;

public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
{
    public void Configure(EntityTypeBuilder<Favorite> entity)
    {
        entity.Property(u => u.TargetId)
            .IsRequired();

        entity.HasOne(u => u.Person)
            .WithMany()
            .HasForeignKey(u => u.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.TargetType)
            .WithMany()
            .HasForeignKey(u => u.TargetTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasIndex(u => new { u.PersonId, u.TargetId, u.TargetTypeId })
            .IsUnique();
    }
}