using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Advertisement;

public class AdFeaturedConfiguration : IEntityTypeConfiguration<AdFeatured>
{
    public void Configure(EntityTypeBuilder<AdFeatured> entity)
    {
        entity.Property(u => u.Description) // TODO : Criar FullTextSearch
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(u => u.ExpirationDate)
            .IsRequired();

        entity.HasOne(u => u.Ad)
            .WithMany(u => u.FeaturedItems)
            .HasForeignKey(u => u.AdId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasIndex(u => u.ExpirationDate);
    }
}