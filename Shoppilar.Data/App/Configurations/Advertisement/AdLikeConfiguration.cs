using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Advertisement;

public class AdLikeConfiguration : IEntityTypeConfiguration<AdLike>
{
    public void Configure(EntityTypeBuilder<AdLike> entity)
    {
        entity.HasOne(u => u.Person)
            .WithMany()
            .HasForeignKey(u => u.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.Ad)
            .WithMany(u => u.Likes)
            .HasForeignKey(u => u.AdId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasIndex(u => new { u.AdId, u.PersonId })
            .IsUnique();
    }
}