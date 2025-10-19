using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class AdPromotionService(IRepo<AdPromotion> repository) : IAdPromotionService
{
    public async Task<AdPromotionResponse?> GetAsync(Expression<Func<AdPromotion, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var response = new AdPromotionResponse(entity);
        return response;
    }

    public async Task<List<AdPromotionResponse>> GetAllAsync(Expression<Func<AdPromotion, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new AdPromotionResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<AdPromotionResponse>> GetPagedProjectionAsync(
        Expression<Func<AdPromotion, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedProjectionAsync(
            predicate: predicate,
            selector: AdPromotionResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var responses = new PaginatedResponse<AdPromotionResponse>(items, totalCount);

        return responses;
    }

    public async Task<BaseResponse<AdPromotionResponse?>> InsertAsync(AdPromotionInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new AdPromotion
        {
            Id = input.Id ?? Guid.NewGuid(),
            Description = input.Description,
            Price = input.Price,
            ExpirationDate = input.ExpirationDate,
            AdId = input.AdId
        };

        await repository.InsertAsync(entity, cancellationToken);

        var response = new BaseResponse<AdPromotionResponse?>(true, Messages.Created, new AdPromotionResponse(entity));

        return response;
    }

    public async Task<BaseResponse<AdPromotionResponse?>> UpdateAsync(AdPromotionInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return new BaseResponse<AdPromotionResponse?>(false, Messages.NotFound);

        entity.Description = input.Description;
        entity.Price = input.Price;
        entity.ExpirationDate = input.ExpirationDate;
        entity.AdId = input.AdId;

        await repository.UpdateAsync(entity, cancellationToken);

        var response = new BaseResponse<AdPromotionResponse?>(true, Messages.Updated, new AdPromotionResponse(entity));

        return response;
    }

    public async Task<bool> HardDeleteAsync(AdPromotionInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);

        return result > 0;
    }

    public async Task<bool> HardDeleteAsync(List<AdPromotionInput>? inputs,
        CancellationToken cancellationToken = default)
    {
        if (inputs == null || inputs.Count == 0)
            return false;

        var ids = inputs.Select(i => i.Id).ToList();

        var entities = await repository.GetAllAsync(
            x => ids.Contains(x.Id),
            null,
            cancellationToken
        );

        if (!entities.Any())
            return false;

        var result = await repository.HardDeleteAsync(entities.ToList(), cancellationToken);

        return result > 0;
    }

    public async Task<int> CountAsync(Expression<Func<AdPromotion, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        return await repository.CountAsync(predicate, cancellationToken);
    }
}