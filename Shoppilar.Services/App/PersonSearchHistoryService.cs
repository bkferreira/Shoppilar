using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class PersonSearchHistoryService(IRepo<PersonSearchHistory> repository) : IPersonSearchHistoryService
{
    public async Task<PersonSearchHistoryResponse?> GetAsync(Expression<Func<PersonSearchHistory, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var result = new PersonSearchHistoryResponse(entity);
        return result;
    }

    public async Task<List<PersonSearchHistoryResponse>> GetAllAsync(
        Expression<Func<PersonSearchHistory, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var results = entities.Select(x => new PersonSearchHistoryResponse(x)).ToList();
        return results;
    }

    public async Task<PaginatedResponse<PersonSearchHistoryResponse>> GetPagedAsync(
        Expression<Func<PersonSearchHistory, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedAsync(
            predicate: predicate,
            selector: PersonSearchHistoryResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var results = new PaginatedResponse<PersonSearchHistoryResponse>(items, totalCount);
        return results;
    }

    public async Task<PersonSearchHistoryResponse?> InsertAsync(PersonSearchHistoryInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new PersonSearchHistory
        {
            Id = input.Id ?? Guid.NewGuid(),
            PersonId = input.PersonId,
            Query = input.Query,
            SearchedAt = input.SearchedAt
        };

        await repository.InsertAsync(entity, cancellationToken);

        var result = new PersonSearchHistoryResponse(entity);
        return result;
    }

    public async Task<bool> HardDeleteAsync(PersonSearchHistoryInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);
        return result > 0;
    }

    public async Task<bool> HardDeleteAsync(List<PersonSearchHistoryInput>? inputs,
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
}