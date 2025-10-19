using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Person;

public class PersonFollowerConfiguration : IEntityTypeConfiguration<PersonFollower>
{
    public void Configure(EntityTypeBuilder<PersonFollower> entity)
    {
        entity.HasOne(u => u.Follower)
            .WithMany(u => u.Following) // segue várias pessoas
            .HasForeignKey(u => u.FollowerId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.Followed)
            .WithMany(u => u.Followers) // é seguido por várias pessoas
            .HasForeignKey(u => u.FollowedId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasIndex(u => new { u.FollowerId, u.FollowedId })
            .IsUnique(); // um usuário não pode seguir o mesmo Person duas vezes
    }
}