using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Configurations.Type;

public class AdTypeConfiguration : BaseTypeConfiguration<AdType>
{
    public override void Configure(EntityTypeBuilder<AdType> entity)
    {
        base.Configure(entity);

        entity.HasMany(a => a.SubTypes)
            .WithOne(s => s.AdType)
            .HasForeignKey(s => s.AdTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}