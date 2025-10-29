using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface ICityService
{
    Task<CityResponse?> GetAsync(Expression<Func<City, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<CityResponse>> GetAllAsync(Expression<Func<City, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<CityResponse>> GetPagedAsync(
        Expression<Func<City, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);
}