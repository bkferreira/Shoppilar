using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IJobService
{
    Task<JobResponse?> GetAsync(Expression<Func<Job, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<JobResponse>> GetAllAsync(Expression<Func<Job, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<JobResponse>> GetPagedProjectionAsync(
        Expression<Func<Job, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<JobResponse?>> InsertAsync(JobInput input,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<JobResponse?>> UpdateAsync(JobInput input,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(JobInput input, CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(List<JobInput>? inputs, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<Job, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}