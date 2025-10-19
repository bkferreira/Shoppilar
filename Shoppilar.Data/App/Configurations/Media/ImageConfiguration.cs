using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Media;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> entity)
    {
        entity.Property(u => u.Url)
            .HasMaxLength(300)
            .IsRequired();

        entity.Property(u => u.FileName)
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(u => u.ContentType)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(u => u.ContainerName)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(u => u.Size)
            .HasColumnType("bigint")
            .IsRequired();

        entity.HasOne(u => u.Person)
            .WithMany()
            .HasForeignKey(u => u.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.Job)
            .WithMany(u => u.Images)
            .HasForeignKey(u => u.JobId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.Ad)
            .WithMany(u => u.Images)
            .HasForeignKey(u => u.AdId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.Event)
            .WithMany(u => u.Images)
            .HasForeignKey(u => u.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.ImageType)
            .WithMany()
            .HasForeignKey(u => u.ImageTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}