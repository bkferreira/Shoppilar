using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IAdFeaturedService
{
    Task<AdFeaturedResponse?> GetAsync(Expression<Func<AdFeatured, bool>> predicate, string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<AdFeaturedResponse>> GetAllAsync(Expression<Func<AdFeatured, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<AdFeaturedResponse>> GetPagedAsync(
        Expression<Func<AdFeatured, bool>>? predicate = null,
        string? includeProperties = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<AdFeaturedResponse?>> InsertAsync(AdFeaturedInput input,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<AdFeaturedResponse?>> UpdateAsync(AdFeaturedInput input,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(AdFeaturedInput input, CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(List<AdFeaturedInput>? inputs, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<AdFeatured, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}