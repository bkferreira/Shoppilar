using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IAdLikeService
{
    Task<AdLikeResponse?> GetAsync(Expression<Func<AdLike, bool>> predicate, string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<AdLikeResponse>> GetAllAsync(Expression<Func<AdLike, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<AdLikeResponse>> GetPagedProjectionAsync(
        Expression<Func<AdLike, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<AdLikeResponse?>> InsertAsync(AdLikeInput input,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(AdLikeInput input, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<AdLike, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}