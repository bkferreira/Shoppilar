using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class PersonFollowerService(IRepo<PersonFollower> repository) : IPersonFollowerService
{
    public async Task<PersonFollowerResponse?> GetAsync(Expression<Func<PersonFollower, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var result = new PersonFollowerResponse(entity);
        return result;
    }

    public async Task<List<PersonFollowerResponse>> GetAllAsync(
        Expression<Func<PersonFollower, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var results = entities.Select(x => new PersonFollowerResponse(x)).ToList();
        return results;
    }

    public async Task<PaginatedResponse<PersonFollowerResponse>> GetPagedAsync(
        Expression<Func<PersonFollower, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedAsync(
            predicate: predicate,
            selector: PersonFollowerResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var results = new PaginatedResponse<PersonFollowerResponse>(items, totalCount);
        return results;
    }

    public async Task<PersonFollowerResponse?> InsertAsync(PersonFollowerInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new PersonFollower
        {
            FollowerId = input.FollowerId,
            FollowedId = input.FollowedId
        };

        await repository.InsertAsync(entity, cancellationToken);

        var result = new PersonFollowerResponse(entity);
        return result;
    }

    public async Task<bool> HardDeleteAsync(PersonFollowerInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);
        return result > 0;
    }

    public async Task<int> CountAsync(Expression<Func<PersonFollower, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.CountAsync(predicate, cancellationToken);
        return result;
    }
}