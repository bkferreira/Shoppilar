using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IAdService
{
    Task<AdResponse?> GetAsync(Expression<Func<Ad, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<AdResponse>> GetAllAsync(Expression<Func<Ad, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<AdResponse>> GetPagedAsync(
        Expression<Func<Ad, bool>>? predicate = null,
        string? includeProperties = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<AdResponse>> GetPagedProjectionAsync(
        Expression<Func<Ad, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<AdResponse?>> InsertAsync(AdInput input,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<AdResponse?>> UpdateAsync(AdInput input,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(AdInput input, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(List<AdInput>? inputs, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<Ad, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}