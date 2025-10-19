using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface ITypeService<T> where T : BaseType
{
    Task<TypeResponse?> GetAsync(Expression<Func<T, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<TypeResponse>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<TypeResponse?>> InsertAsync(TypeInput input, CancellationToken cancellationToken = default);

    Task<BaseResponse<TypeResponse?>> UpdateAsync(TypeInput input, CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(TypeInput input, CancellationToken cancellationToken = default);
}