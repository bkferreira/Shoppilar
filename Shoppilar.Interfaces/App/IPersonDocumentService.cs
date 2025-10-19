using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IPersonDocumentService
{
    Task<PersonDocumentResponse?> GetAsync(Expression<Func<PersonDocument, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<PersonDocumentResponse>> GetAllAsync(Expression<Func<PersonDocument, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<PersonDocumentResponse>> GetPagedProjectionAsync(
        Expression<Func<PersonDocument, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<PersonDocumentResponse?>> InsertAsync(PersonDocumentInput input,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<List<PersonDocumentResponse>>> InsertAsync(List<PersonDocumentInput> inputs,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<PersonDocumentResponse?>> UpdateAsync(PersonDocumentInput input,
        CancellationToken cancellationToken = default);

    Task<BaseResponse<List<PersonDocumentResponse>>> UpdateAsync(List<PersonDocumentInput> inputs,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(PersonDocumentInput input, CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(List<PersonDocumentInput>? inputs, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<PersonDocument, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}