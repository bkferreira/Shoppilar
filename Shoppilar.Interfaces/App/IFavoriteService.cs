using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IFavoriteService
{
    Task<FavoriteResponse?> GetAsync(Expression<Func<Favorite, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<FavoriteResponse>> GetAllAsync(Expression<Func<Favorite, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<FavoriteResponse>> GetPagedProjectionAsync(
        Expression<Func<Favorite, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<FavoriteResponse?>> InsertAsync(FavoriteInput input,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(FavoriteInput input, CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(List<FavoriteInput>? inputs, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<Favorite, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}