using SQLite;

namespace Shoppilar.Mobile.Interfaces;

public interface IDatabaseService
{
    SQLiteAsyncConnection GetConnection();
    Task InitAsync();
}