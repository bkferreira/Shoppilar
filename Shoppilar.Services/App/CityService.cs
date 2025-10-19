using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Response;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class CityService(IRepo<City> repository) : ICityService
{
    public async Task<CityResponse?> GetAsync(Expression<Func<City, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var response = new CityResponse(entity);
        return response;
    }

    public async Task<List<CityResponse>> GetAllAsync(Expression<Func<City, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new CityResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<CityResponse>> GetPagedProjectionAsync(
        Expression<Func<City, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedProjectionAsync(
            predicate: predicate,
            selector: CityResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var responses = new PaginatedResponse<CityResponse>(items, totalCount);

        return responses;
    }
}