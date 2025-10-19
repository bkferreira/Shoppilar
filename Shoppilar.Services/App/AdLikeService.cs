using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class AdLikeService(IRepo<AdLike> repository) : IAdLikeService
{
    public async Task<AdLikeResponse?> GetAsync(Expression<Func<AdLike, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var response = new AdLikeResponse(entity);
        return response;
    }

    public async Task<List<AdLikeResponse>> GetAllAsync(Expression<Func<AdLike, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new AdLikeResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<AdLikeResponse>> GetPagedProjectionAsync(
        Expression<Func<AdLike, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedProjectionAsync(
            predicate: predicate,
            selector: AdLikeResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var responses = new PaginatedResponse<AdLikeResponse>(items, totalCount);

        return responses;
    }

    public async Task<BaseResponse<AdLikeResponse?>> InsertAsync(AdLikeInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new AdLike
        {
            Id = input.Id ?? Guid.NewGuid(),
            PersonId = input.PersonId,
            AdId = input.AdId
        };

        await repository.InsertAsync(entity, cancellationToken);

        var response = new BaseResponse<AdLikeResponse?>(true, Messages.Created, new AdLikeResponse(entity));

        return response;
    }

    public async Task<bool> HardDeleteAsync(AdLikeInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);

        return result > 0;
    }

    public async Task<int> CountAsync(Expression<Func<AdLike, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        return await repository.CountAsync(predicate, cancellationToken);
    }
}