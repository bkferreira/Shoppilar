using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IPersonFollowerService
{
    Task<PersonFollowerResponse?> GetAsync(Expression<Func<PersonFollower, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<PersonFollowerResponse>> GetAllAsync(Expression<Func<PersonFollower, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<PersonFollowerResponse>> GetPagedProjectionAsync(
        Expression<Func<PersonFollower, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<PersonFollowerResponse?>> InsertAsync(PersonFollowerInput input,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(PersonFollowerInput input, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<PersonFollower, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}