using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class AdFeaturedService(IRepo<AdFeatured> repository) : IAdFeaturedService
{
    public async Task<AdFeaturedResponse?> GetAsync(Expression<Func<AdFeatured, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var response = new AdFeaturedResponse(entity);
        return response;
    }

    public async Task<List<AdFeaturedResponse>> GetAllAsync(Expression<Func<AdFeatured, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new AdFeaturedResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<AdFeaturedResponse>> GetPagedAsync(
        Expression<Func<AdFeatured, bool>>? predicate = null,
        string? includeProperties = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) =
            await repository.GetPagedAsync(predicate, includeProperties, page, pageSize, cancellationToken);
        var responses = new PaginatedResponse<AdFeaturedResponse>(
            items.Select(u => new AdFeaturedResponse(u)).ToList(),
            totalCount
        );
        return responses;
    }

    public async Task<BaseResponse<AdFeaturedResponse?>> InsertAsync(AdFeaturedInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new AdFeatured
        {
            Id = input.Id ?? Guid.NewGuid(),
            Description = input.Description,
            ExpirationDate = input.ExpirationDate,
            AdId = input.AdId
        };

        await repository.InsertAsync(entity, cancellationToken);

        var response = new BaseResponse<AdFeaturedResponse?>(true, Messages.Created, new AdFeaturedResponse(entity));

        return response;
    }

    public async Task<BaseResponse<AdFeaturedResponse?>> UpdateAsync(AdFeaturedInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return new BaseResponse<AdFeaturedResponse?>(false, Messages.NotFound);

        entity.Description = input.Description;
        entity.ExpirationDate = input.ExpirationDate;
        entity.AdId = input.AdId;

        await repository.UpdateAsync(entity, cancellationToken);

        var response = new BaseResponse<AdFeaturedResponse?>(true, Messages.Updated, new AdFeaturedResponse(entity));

        return response;
    }

    public async Task<bool> HardDeleteAsync(AdFeaturedInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);

        return result > 0;
    }

    public async Task<bool> HardDeleteAsync(List<AdFeaturedInput>? inputs,
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

    public async Task<int> CountAsync(Expression<Func<AdFeatured, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        return await repository.CountAsync(predicate, cancellationToken);
    }
}