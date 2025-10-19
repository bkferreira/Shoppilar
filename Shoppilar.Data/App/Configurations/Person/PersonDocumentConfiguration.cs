using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Person;

public class PersonDocumentConfiguration : IEntityTypeConfiguration<PersonDocument>
{
    public void Configure(EntityTypeBuilder<PersonDocument> entity)
    {
        entity.Property(u => u.DocumentNumber)
            .HasMaxLength(100)
            .IsRequired();

        entity.HasOne(d => d.CategoryType)
            .WithMany()
            .HasForeignKey(d => d.CategoryTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(u => u.Person)
            .WithMany(u => u.Documents)
            .HasForeignKey(u => u.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(u => u.DocumentType)
            .WithMany()
            .HasForeignKey(u => u.DocumentTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasIndex(u => new { u.DocumentNumber, u.DocumentTypeId })
            .IsUnique();

        entity.HasIndex(u => new { u.PersonId, u.Standard });
    }
}