using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Type;

public abstract class BaseTypeConfiguration<T> : IEntityTypeConfiguration<T>
    where T : BaseType
{
    public virtual void Configure(EntityTypeBuilder<T> entity)
    {
        entity.Property(u => u.Description)
            .HasMaxLength(100)
            .IsRequired();

        entity.Property(u => u.Icon)
            .HasMaxLength(50);

        entity.Property(u => u.Color)
            .HasMaxLength(20);

        entity.HasIndex(u => u.Description).IsUnique();
    }
}