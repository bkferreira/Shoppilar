using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Activity;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> entity)
    {
        entity.Property(u => u.Title)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(u => u.Description) // TODO: Criar FullTextSearch
            .HasMaxLength(200)
            .IsRequired();

        entity.Property(u => u.Contact)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(u => u.ExternalUrl)
            .HasMaxLength(300);

        entity.Property(u => u.Location)
            .HasMaxLength(200);

        entity.Property(u => u.Price)
            .HasColumnType("decimal(18,2)");

        entity.Property(u => u.ExpirationDate).IsRequired();

        entity.Property(u => u.StartDate).IsRequired();

        entity.Property(u => u.EndDate).IsRequired();

        entity.HasOne(u => u.Person)
            .WithMany()
            .HasForeignKey(u => u.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.City)
            .WithMany()
            .HasForeignKey(u => u.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(u => u.EventType)
            .WithMany()
            .HasForeignKey(u => u.EventTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(u => u.ContactType)
            .WithMany()
            .HasForeignKey(u => u.ContactTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasMany(u => u.Images)
            .WithOne(i => i.Event)
            .HasForeignKey(i => i.EventId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}