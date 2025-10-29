using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shoppilar.Data.App.Context;
using Shoppilar.Data.App.Models;
using Shoppilar.Interfaces;

namespace Shoppilar.Services;

public sealed class Repo<T>(IDbContextFactory<AppDbContext> contextFactory) : IRepo<T> where T : EntityBase
{
    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        if (!string.IsNullOrWhiteSpace(includeProperties))
        {
            var query = context.Set<T>().AsQueryable().IgnoreAutoIncludes();

            foreach (var property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(property.Trim());
            }

            return await query.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        return await context.Set<T>().AsNoTracking()
            .FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        if (string.IsNullOrWhiteSpace(includeProperties))
        {
            if (predicate != null)
                return await context.Set<T>().Where(predicate).ToListAsync(cancellationToken);
            return await context.Set<T>().ToListAsync(cancellationToken);
        }

        var query = context.Set<T>().AsQueryable().IgnoreAutoIncludes();

        foreach (var property in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(property.Trim());
        }

        if (predicate != null)
            query = query.Where(predicate);

        return await query.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<(List<TModel> Items, int TotalCount)> GetPagedAsync<TModel>(
        Expression<Func<T, bool>>? predicate = null,
        Expression<Func<T, TModel>>? selector = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        var query = context.Set<T>().AsNoTracking().AsQueryable();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        var total = await query.CountAsync(cancellationToken);

        // Projeção: aplica o selector se foi passado, senão faz cast
        IQueryable<TModel> projectedQuery;

        if (selector != null)
        {
            projectedQuery = query.Select(selector);
        }
        else if (typeof(TModel) == typeof(T))
        {
            // Se TModel for a própria entidade, converte sem Select
            projectedQuery = (IQueryable<TModel>)query;
        }
        else
        {
            throw new InvalidOperationException("Selector deve ser informado quando TModel for diferente de T.");
        }

        var items = await projectedQuery
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return (items, total);
    }

    public async Task<int> InsertAsync(T entity, CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Set<T>().AddAsync(entity, cancellationToken);
        return await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> InsertAsync(List<T> entities, CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        await context.Set<T>().AddRangeAsync(entities, cancellationToken);
        return await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        context.Set<T>().Update(entity);
        return await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> UpdateAsync(List<T> entities, CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        context.Set<T>().UpdateRange(entities);
        return await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        context.Set<T>().Remove(entity);
        return await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> DeleteAsync(List<T> entities, CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        context.Set<T>().RemoveRange(entities);
        return await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> HardDeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var entityDbSet = context.Set<T>();

        var entityToDelete = await entityDbSet
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(e => e.Id == entity.Id, cancellationToken);

        if (entityToDelete == null)
            return 0;

        context.HardDeleting = true;

        entityDbSet.Remove(entityToDelete);

        try
        {
            var affected = await context.SaveChangesAsync(cancellationToken);

            if (affected == 0)
                return 0;

            var stillExists = await entityDbSet
                .IgnoreQueryFilters()
                .AnyAsync(e => e.Id == entity.Id, cancellationToken);

            return stillExists ? 0 : 1;
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(
                $"[HardDelete] Falha ao excluir {typeof(T).Name} (FK Restrict?) → {ex.InnerException?.Message ?? ex.Message}");
            return 0;
        }
    }

    public async Task<int> HardDeleteAsync(List<T>? entities, CancellationToken cancellationToken = default)
    {
        if (entities == null || !entities.Any())
            return 0;

        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var entityDbSet = context.Set<T>();

        var ids = entities.Select(e => e.Id).ToList();
        var entitiesToDelete = await entityDbSet
            .IgnoreQueryFilters()
            .Where(e => ids.Contains(e.Id))
            .ToListAsync(cancellationToken);

        if (!entitiesToDelete.Any())
            return 0;

        context.HardDeleting = true;
        entityDbSet.RemoveRange(entitiesToDelete);

        try
        {
            var affected = await context.SaveChangesAsync(cancellationToken);

            if (affected == 0)
                return 0;

            var stillExists = await entityDbSet
                .IgnoreQueryFilters()
                .Where(e => ids.Contains(e.Id))
                .AnyAsync(cancellationToken);

            return stillExists ? 0 : 1;
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(
                $"[HardDeleteList] Falha ao excluir lista de {typeof(T).Name} (FK Restrict?) → {ex.InnerException?.Message ?? ex.Message}");
            return 0;
        }
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);
        var query = context.Set<T>().AsQueryable();

        if (predicate != null)
            query = query.Where(predicate);

        return await query.CountAsync(cancellationToken);
    }
}