using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IPersonSearchHistoryService
{
    Task<PersonSearchHistoryResponse?> GetAsync(Expression<Func<PersonSearchHistory, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<PersonSearchHistoryResponse>> GetAllAsync(Expression<Func<PersonSearchHistory, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<PersonSearchHistoryResponse>> GetPagedAsync(
        Expression<Func<PersonSearchHistory, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<PersonSearchHistoryResponse?> InsertAsync(PersonSearchHistoryInput input,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(PersonSearchHistoryInput input, CancellationToken cancellationToken = default);
    Task<bool> HardDeleteAsync(List<PersonSearchHistoryInput>? inputs, CancellationToken cancellationToken = default);
}