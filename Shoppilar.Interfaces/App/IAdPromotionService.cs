using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IAdPromotionService
{
    Task<AdPromotionResponse?> GetAsync(Expression<Func<AdPromotion, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<AdPromotionResponse>> GetAllAsync(Expression<Func<AdPromotion, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<AdPromotionResponse>> GetPagedAsync(
        Expression<Func<AdPromotion, bool>>? predicate = null,
        string? includeProperties = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<AdPromotionResponse?>> InsertAsync(AdPromotionInput input,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<AdPromotionResponse?>> UpdateAsync(AdPromotionInput input,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(AdPromotionInput input, CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(List<AdPromotionInput>? inputs, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<AdPromotion, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}