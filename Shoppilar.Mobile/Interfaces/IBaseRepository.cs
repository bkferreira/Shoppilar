using System.Linq.Expressions;
using Shoppilar.Mobile.Models;

namespace Shoppilar.Mobile.Interfaces;

public interface IBaseRepository<T> where T : IBaseCacheModel, new()
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> predicate);
    Task<T> GetByIdAsync(int localId);
    Task<int> SaveAsync(T item);
    Task<int> SaveAllAsync(IEnumerable<T> items);
    Task<int> DeleteAsync(T item);
    Task<int> DeleteAllAsync();
}