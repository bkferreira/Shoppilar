using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IPersonSocialMediaService
{
    Task<PersonSocialMediaResponse?> GetAsync(Expression<Func<PersonSocialMedia, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<PersonSocialMediaResponse>> GetAllAsync(Expression<Func<PersonSocialMedia, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<PersonSocialMediaResponse>> GetPagedAsync(
        Expression<Func<PersonSocialMedia, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<PersonSocialMediaResponse?> InsertAsync(PersonSocialMediaInput input,
        CancellationToken cancellationToken = default);

    Task<List<PersonSocialMediaResponse>> InsertAsync(List<PersonSocialMediaInput> inputs,
        CancellationToken cancellationToken = default);

    Task<PersonSocialMediaResponse?> UpdateAsync(PersonSocialMediaInput input,
        CancellationToken cancellationToken = default);

    Task<List<PersonSocialMediaResponse>> UpdateAsync(List<PersonSocialMediaInput> inputs,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(PersonSocialMediaInput input, CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(List<PersonSocialMediaInput>? inputs, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<PersonSocialMedia, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}