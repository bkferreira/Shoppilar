using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IImageService
{
    Task<ImageResponse?> GetAsync(Expression<Func<Image, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<ImageResponse>> GetAllAsync(Expression<Func<Image, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<ImageResponse>> GetPagedAsync(
        Expression<Func<Image, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<ImageResponse?> InsertAsync(ImageInput input,
        CancellationToken cancellationToken = default);

    Task<List<ImageResponse>?> InsertAsync(List<ImageInput> inputs,
        CancellationToken cancellationToken = default);

    Task<ImageResponse?> UpdateAsync(ImageInput input,
        CancellationToken cancellationToken = default);

    Task<List<ImageResponse>> UpdateAsync(List<ImageInput> inputs,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(ImageInput input, CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(List<ImageInput>? inputs, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<Image, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}