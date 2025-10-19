using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shoppilar.Data.App.Configurations.Person;

public class PersonConfiguration : IEntityTypeConfiguration<Models.Person>
{
    public void Configure(EntityTypeBuilder<Models.Person> entity)
    {
        entity.Property(u => u.Name)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(u => u.Birth)
            .IsRequired();

        entity.HasOne(u => u.PersonType)
            .WithMany()
            .HasForeignKey(u => u.PersonTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(u => u.Image)
            .WithMany()
            .HasForeignKey(u => u.ImageId)
            .OnDelete(DeleteBehavior.SetNull);

        entity.HasMany(u => u.Addresses)
            .WithOne(a => a.Person)
            .HasForeignKey(a => a.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(u => u.Documents)
            .WithOne(d => d.Person)
            .HasForeignKey(d => d.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(u => u.Contacts)
            .WithOne(c => c.Person)
            .HasForeignKey(c => c.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(u => u.Followers)
            .WithOne(f => f.Followed)
            .HasForeignKey(f => f.FollowedId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(u => u.Following)
            .WithOne(f => f.Follower)
            .HasForeignKey(f => f.FollowerId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(u => u.SocialMedias)
            .WithOne(s => s.Person)
            .HasForeignKey(s => s.PersonId);

        entity.HasIndex(u => new { u.Name, u.Birth })
            .IsUnique(false);
    }
}