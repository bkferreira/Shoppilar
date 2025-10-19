using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Interaction;

public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> entity)
    {
        entity.Property(u => u.Comment)
            .HasMaxLength(500);

        entity.Property(u => u.Rating)
            .IsRequired();

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