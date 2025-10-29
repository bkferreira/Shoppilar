using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;

namespace Shoppilar.Interfaces.App;

public interface IFeedbackService
{
    Task<FeedbackResponse?> GetAsync(Expression<Func<Feedback, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default);

    Task<List<FeedbackResponse>> GetAllAsync(Expression<Func<Feedback, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default);

    Task<PaginatedResponse<FeedbackResponse>> GetPagedAsync(
        Expression<Func<Feedback, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default);

    Task<FeedbackResponse?> InsertAsync(FeedbackInput input,
        CancellationToken cancellationToken = default);

    Task<FeedbackResponse?> UpdateAsync(FeedbackInput input,
        CancellationToken cancellationToken = default);

    Task<bool> HardDeleteAsync(FeedbackInput input, CancellationToken cancellationToken = default);

    Task<int> CountAsync(Expression<Func<Feedback, bool>>? predicate = null,
        CancellationToken cancellationToken = default);
}