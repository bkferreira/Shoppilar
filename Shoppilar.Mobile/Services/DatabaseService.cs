using Shoppilar.Mobile.Interfaces;
using Shoppilar.Mobile.Models;
using SQLite;

namespace Shoppilar.Mobile.Services;

public class DatabaseService(SQLiteAsyncConnection database) : IDatabaseService
{
    private bool _initialized;

    public SQLiteAsyncConnection GetConnection()
    {
        return database;
    }

    public async Task InitAsync()
    {
        if (_initialized) return;

        var connection = GetConnection();

        await connection.CreateTableAsync<AdCache>();

        _initialized = true;
    }
}