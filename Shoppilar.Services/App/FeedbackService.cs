using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class FeedbackService(IRepo<Feedback> repository) : IFeedbackService
{
    public async Task<FeedbackResponse?> GetAsync(Expression<Func<Feedback, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var response = new FeedbackResponse(entity);
        return response;
    }

    public async Task<List<FeedbackResponse>> GetAllAsync(Expression<Func<Feedback, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new FeedbackResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<FeedbackResponse>> GetPagedProjectionAsync(
        Expression<Func<Feedback, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedProjectionAsync(
            predicate: predicate,
            selector: FeedbackResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var responses = new PaginatedResponse<FeedbackResponse>(items, totalCount);

        return responses;
    }

    public async Task<BaseResponse<FeedbackResponse?>> InsertAsync(FeedbackInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new Feedback
        {
            Id = input.Id ?? Guid.NewGuid(),
            Rating = input.Rating,
            Comment = input.Comment,
            TargetId = input.TargetId,
            TargetTypeId = input.TargetTypeId,
            PersonId = input.PersonId
        };

        await repository.InsertAsync(entity, cancellationToken);

        var response = new BaseResponse<FeedbackResponse?>(true, Messages.Created, new FeedbackResponse(entity));

        return response;
    }

    public async Task<BaseResponse<FeedbackResponse?>> UpdateAsync(FeedbackInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return new BaseResponse<FeedbackResponse?>(false, Messages.NotFound);

        entity.Rating = input.Rating;
        entity.Comment = input.Comment;
        entity.TargetId = input.TargetId;
        entity.TargetTypeId = input.TargetTypeId;
        entity.PersonId = input.PersonId;

        await repository.UpdateAsync(entity, cancellationToken);

        var response = new BaseResponse<FeedbackResponse?>(true, Messages.Updated, new FeedbackResponse(entity));

        return response;
    }

    public async Task<bool> HardDeleteAsync(FeedbackInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);

        return result > 0;
    }

    public async Task<int> CountAsync(Expression<Func<Feedback, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        return await repository.CountAsync(predicate, cancellationToken);
    }
}