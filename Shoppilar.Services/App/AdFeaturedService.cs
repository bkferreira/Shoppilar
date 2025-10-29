using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
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
        var result = new AdFeaturedResponse(entity);
        return result;
    }

    public async Task<List<AdFeaturedResponse>> GetAllAsync(Expression<Func<AdFeatured, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var results = entities.Select(x => new AdFeaturedResponse(x)).ToList();
        return results;
    }

    public async Task<PaginatedResponse<AdFeaturedResponse>> GetPagedAsync(
        Expression<Func<AdFeatured, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedAsync(
            predicate: predicate,
            selector: AdFeaturedResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var results = new PaginatedResponse<AdFeaturedResponse>(items, totalCount);
        return results;
    }

    public async Task<AdFeaturedResponse?> InsertAsync(AdFeaturedInput input,
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

        var result = new AdFeaturedResponse(entity);
        return result;
    }

    public async Task<AdFeaturedResponse?> UpdateAsync(AdFeaturedInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return null;

        entity.Description = input.Description;
        entity.ExpirationDate = input.ExpirationDate;
        entity.AdId = input.AdId;

        await repository.UpdateAsync(entity, cancellationToken);

        var result = new AdFeaturedResponse(entity);
        return result;
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
        var result = await repository.CountAsync(predicate, cancellationToken);
        return result;
    }
}