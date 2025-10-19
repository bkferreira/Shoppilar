using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IOccurrenceService
{
    Task<OccurrenceResponse?> GetAsync(Expression<Func<Occurrence, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<OccurrenceResponse>> GetAllAsync(Expression<Func<Occurrence, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<OccurrenceResponse>> GetPagedProjectionAsync(
        Expression<Func<Occurrence, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<OccurrenceResponse?>> InsertAsync(OccurrenceInput input,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<OccurrenceResponse?>> UpdateAsync(OccurrenceInput input,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(OccurrenceInput input, CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(List<OccurrenceInput>? inputs, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<Occurrence, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}