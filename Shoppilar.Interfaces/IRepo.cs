using System.Linq.Expressions;

namespace Shoppilar.Interfaces;

public interface IRepo<T> where T : class
{
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate, string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<(List<T> Items, int TotalCount)> GetPagedAsync(
        Expression<Func<T, bool>>? predicate = null,
        string? includeProperties = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<(List<TModel> Items, int TotalCount)> GetPagedProjectionAsync<TModel>(
        Expression<Func<T, bool>>? predicate = null,
        Expression<Func<T, TModel>>? selector = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<int> InsertAsync(T entity, CancellationToken cancellationToken = default);

    Task<int> InsertAsync(List<T> entities, CancellationToken cancellationToken = default);

    Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default);

    Task<int> UpdateAsync(List<T> entities, CancellationToken cancellationToken = default);

    Task<int> DeleteAsync(T entity, CancellationToken cancellationToken = default);

    Task<int> DeleteAsync(List<T> entities, CancellationToken cancellationToken = default); // TODO : Implementar

    Task<int> HardDeleteAsync(T entity, CancellationToken cancellationToken = default);

    Task<int> HardDeleteAsync(List<T>? entities, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}