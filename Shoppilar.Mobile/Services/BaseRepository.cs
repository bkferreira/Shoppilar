using System.Linq.Expressions;
using Shoppilar.Mobile.Interfaces;
using Shoppilar.Mobile.Models;
using SQLite;

namespace Shoppilar.Mobile.Services;

public class BaseRepository<T>(IDatabaseService databaseService) : IBaseRepository<T>
    where T : IBaseCacheModel, new()
{
    private readonly SQLiteAsyncConnection _db = databaseService.GetConnection();

    public Task<List<T>> GetAllAsync()
    {
        return _db.Table<T>().ToListAsync();
    }

    public Task<List<T>> GetFilteredAsync(Expression<Func<T, bool>> predicate)
    {
        return _db.Table<T>().Where(predicate).ToListAsync();
    }

    public Task<T> GetByIdAsync(int localId)
    {
        return _db.FindAsync<T>(localId);
    }

    public Task<int> SaveAsync(T item)
    {
        if (item.LocalId != 0)
        {
            return _db.UpdateAsync(item);
        }
        else
        {
            return _db.InsertAsync(item);
        }
    }

    public Task<int> SaveAllAsync(IEnumerable<T> items)
    {
        return _db.InsertAllAsync(items);
    }

    public Task<int> DeleteAsync(T item)
    {
        return _db.DeleteAsync(item);
    }

    public Task<int> DeleteAllAsync()
    {
        return _db.DeleteAllAsync<T>();
    }
}