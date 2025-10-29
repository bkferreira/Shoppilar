using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IEventService
{
    Task<EventResponse?> GetAsync(Expression<Func<Event, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<EventResponse>> GetAllAsync(Expression<Func<Event, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<EventResponse>> GetPagedAsync(
        Expression<Func<Event, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<EventResponse?> InsertAsync(EventInput input,
        CancellationToken cancellationToken = default);

    Task<EventResponse?> UpdateAsync(EventInput input,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(EventInput input, CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(List<EventInput>? inputs, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<Event, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}