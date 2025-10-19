using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IStateService
{
    Task<StateResponse?> GetAsync(Expression<Func<State, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<StateResponse>> GetAllAsync(Expression<Func<State, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<StateResponse>> GetPagedProjectionAsync(
        Expression<Func<State, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);
}