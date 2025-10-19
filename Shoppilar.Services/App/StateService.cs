using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Response;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class StateService(IRepo<State> repository) : IStateService
{
    public async Task<StateResponse?> GetAsync(Expression<Func<State, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var response = new StateResponse(entity);
        return response;
    }

    public async Task<List<StateResponse>> GetAllAsync(Expression<Func<State, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new StateResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<StateResponse>> GetPagedAsync(
        Expression<Func<State, bool>>? predicate = null,
        string? includeProperties = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) =
            await repository.GetPagedAsync(predicate, includeProperties, page, pageSize, cancellationToken);
        var responses = new PaginatedResponse<StateResponse>(
            items.Select(u => new StateResponse(u)).ToList(),
            totalCount
        );
        return responses;
    }
}