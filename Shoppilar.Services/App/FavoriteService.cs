using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class FavoriteService(IRepo<Favorite> repository) : IFavoriteService
{
    public async Task<FavoriteResponse?> GetAsync(Expression<Func<Favorite, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var response = new FavoriteResponse(entity);
        return response;
    }

    public async Task<List<FavoriteResponse>> GetAllAsync(Expression<Func<Favorite, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new FavoriteResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<FavoriteResponse>> GetPagedAsync(
        Expression<Func<Favorite, bool>>? predicate = null,
        string? includeProperties = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) =
            await repository.GetPagedAsync(predicate, includeProperties, page, pageSize, cancellationToken);
        var responses = new PaginatedResponse<FavoriteResponse>(
            items.Select(u => new FavoriteResponse(u)).ToList(),
            totalCount
        );
        return responses;
    }

    public async Task<BaseResponse<FavoriteResponse?>> InsertAsync(FavoriteInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new Favorite
        {
            Id = input.Id ?? Guid.NewGuid(),
            TargetId = input.TargetId,
            TargetTypeId = input.TargetTypeId,
            PersonId = input.PersonId
        };

        await repository.InsertAsync(entity, cancellationToken);

        var response = new BaseResponse<FavoriteResponse?>(true, Messages.Created, new FavoriteResponse(entity));

        return response;
    }

    public async Task<bool> HardDeleteAsync(FavoriteInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);

        return result > 0;
    }

    public async Task<bool> HardDeleteAsync(List<FavoriteInput>? inputs,
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

    public async Task<int> CountAsync(Expression<Func<Favorite, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        return await repository.CountAsync(predicate, cancellationToken);
    }
}