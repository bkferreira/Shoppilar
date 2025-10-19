using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Person;

public class PersonSocialMediaConfiguration : IEntityTypeConfiguration<PersonSocialMedia>
{
    public void Configure(EntityTypeBuilder<PersonSocialMedia> entity)
    {
        entity.Property(u => u.ProfileUrl)
            .HasMaxLength(300)
            .IsRequired();

        entity.HasOne(u => u.Person)
            .WithMany(u => u.SocialMedias)
            .HasForeignKey(u => u.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.SocialMediaType)
            .WithMany()
            .HasForeignKey(u => u.SocialMediaTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasIndex(u => new { u.PersonId, u.SocialMediaTypeId })
            .IsUnique();
    }
}