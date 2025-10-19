using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Advertisement;

public class AdConfiguration : IEntityTypeConfiguration<Ad>
{
    public void Configure(EntityTypeBuilder<Ad> entity)
    {
        entity.Property(u => u.Title)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(u => u.Description) // TODO : Criar FullTextSearch
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(u => u.Contact)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(u => u.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        entity.Property(u => u.ExpirationDate)
            .IsRequired();

        entity.HasOne(u => u.Person)
            .WithMany()
            .HasForeignKey(u => u.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.City)
            .WithMany()
            .HasForeignKey(u => u.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(u => u.AdType)
            .WithMany()
            .HasForeignKey(u => u.AdTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(u => u.AdSubType)
            .WithMany()
            .HasForeignKey(u => u.AdSubTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasMany(u => u.Likes)
            .WithOne(d => d.Ad)
            .HasForeignKey(d => d.AdId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(u => u.Promotions)
            .WithOne(c => c.Ad)
            .HasForeignKey(c => c.AdId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(u => u.FeaturedItems)
            .WithOne(f => f.Ad)
            .HasForeignKey(f => f.AdId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(u => u.Images)
            .WithOne(f => f.Ad)
            .HasForeignKey(f => f.AdId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasIndex(u => u.Title);

        entity.HasIndex(u => u.Price);

        entity.HasIndex(u => u.AdTypeId);

        entity.HasIndex(u => u.AdSubTypeId);

        entity.HasIndex(u => u.CityId);
    }
}