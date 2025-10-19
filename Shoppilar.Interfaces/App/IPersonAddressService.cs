using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IPersonAddressService
{
    Task<PersonAddressResponse?> GetAsync(Expression<Func<PersonAddress, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<PersonAddressResponse>> GetAllAsync(Expression<Func<PersonAddress, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<PersonAddressResponse>> GetPagedProjectionAsync(
        Expression<Func<PersonAddress, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<PersonAddressResponse?>> InsertAsync(PersonAddressInput input,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<List<PersonAddressResponse>>> InsertAsync(List<PersonAddressInput> inputs,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<PersonAddressResponse?>> UpdateAsync(PersonAddressInput input,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<List<PersonAddressResponse>>> UpdateAsync(List<PersonAddressInput> inputs,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(PersonAddressInput input, CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(List<PersonAddressInput>? inputs, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<PersonAddress, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}