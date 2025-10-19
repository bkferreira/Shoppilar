using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shoppilar.Data.App.Context;
using Shoppilar.Data.App.Models;

namespace Shoppilar.Data.App.Extensions;

public static class ModelBuilderExtensions
{
    public static void ConfigureValidation(this ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public static void ConfigureEntityCod(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var type = entityType.ClrType;
            if (!typeof(EntityBase).IsAssignableFrom(type) || type.IsAbstract)
                continue;

            var entityBuilder = modelBuilder.Entity(type);

            entityBuilder.Property<int>(nameof(EntityBase.Cod))
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            entityBuilder.HasIndex(nameof(EntityBase.Cod)).IsUnique();
        }
    }

    public static void ConfigureSoftDelete(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var type = entityType.ClrType;
            if (!typeof(EntityBase).IsAssignableFrom(type) || type.IsAbstract)
                continue;

            var entityBuilder = modelBuilder.Entity(type);

            var param = Expression.Parameter(type, "e");
            var prop = Expression.Property(param, nameof(EntityBase.IsDeleted));
            var condition = Expression.Equal(prop, Expression.Constant(false));
            var lambda = Expression.Lambda(condition, param);

            entityBuilder.HasQueryFilter(lambda);
        }
    }
}