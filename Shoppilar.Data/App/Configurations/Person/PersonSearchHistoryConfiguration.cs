using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Person;

public class PersonSearchHistoryConfiguration : IEntityTypeConfiguration<PersonSearchHistory>
{
    public void Configure(EntityTypeBuilder<PersonSearchHistory> entity)
    {
        entity.Property(u => u.Query)
            .HasMaxLength(300)
            .IsRequired();

        entity.Property(u => u.SearchedAt)
            .IsRequired();

        entity.HasOne(u => u.Person)
            .WithMany()
            .HasForeignKey(u => u.PersonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}