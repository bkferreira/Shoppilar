using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Report;

public class OccurrenceConfiguration : IEntityTypeConfiguration<Occurrence>
{
    public void Configure(EntityTypeBuilder<Occurrence> entity)
    {
        entity.Property(u => u.Description)
            .HasMaxLength(500)
            .IsRequired();

        entity.Property(u => u.ResolutionComment)
            .HasMaxLength(500);

        entity.Property(u => u.TargetId)
            .IsRequired();

        entity.HasOne(u => u.ReportedBy)
            .WithMany()
            .HasForeignKey(u => u.ReportedById)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.TargetType)
            .WithMany()
            .HasForeignKey(u => u.TargetTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(u => u.OccurrenceType)
            .WithMany()
            .HasForeignKey(u => u.OccurrenceTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasIndex(u => new { u.ReportedById, u.TargetId, u.TargetTypeId })
            .IsUnique();
    }
}