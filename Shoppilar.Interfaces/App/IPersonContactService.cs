using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IPersonContactService
{
    Task<PersonContactResponse?> GetAsync(Expression<Func<PersonContact, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<PersonContactResponse>> GetAllAsync(Expression<Func<PersonContact, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<PersonContactResponse>> GetPagedAsync(
        Expression<Func<PersonContact, bool>>? predicate = null,
        string? includeProperties = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<PersonContactResponse?>> InsertAsync(PersonContactInput input,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<List<PersonContactResponse>>> InsertAsync(List<PersonContactInput> inputs,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<PersonContactResponse?>> UpdateAsync(PersonContactInput input,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<List<PersonContactResponse>>> UpdateAsync(List<PersonContactInput> inputs,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(PersonContactInput input, CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(List<PersonContactInput>? inputs, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<PersonContact, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}