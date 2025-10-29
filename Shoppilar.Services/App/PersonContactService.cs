using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class PersonContactService(IRepo<PersonContact> repository) : IPersonContactService
{
    public async Task<PersonContactResponse?> GetAsync(Expression<Func<PersonContact, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var result = new PersonContactResponse(entity);
        return result;
    }

    public async Task<List<PersonContactResponse>> GetAllAsync(Expression<Func<PersonContact, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var results = entities.Select(x => new PersonContactResponse(x)).ToList();
        return results;
    }

    public async Task<PaginatedResponse<PersonContactResponse>> GetPagedAsync(
        Expression<Func<PersonContact, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedAsync(
            predicate: predicate,
            selector: PersonContactResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var results = new PaginatedResponse<PersonContactResponse>(items, totalCount);
        return results;
    }

    public async Task<PersonContactResponse?> InsertAsync(PersonContactInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new PersonContact
        {
            Standard = input.Standard,
            ContactValue = input.ContactValue,
            PersonId = input.PersonId,
            ContactTypeId = input.ContactTypeId,
        };

        await repository.InsertAsync(entity, cancellationToken);

        var result = new PersonContactResponse(entity);
        return result;
    }

    public async Task<List<PersonContactResponse>> InsertAsync(List<PersonContactInput> inputs,
        CancellationToken cancellationToken = default)
    {
        var entities = inputs.Select(input => new PersonContact
        {
            Standard = input.Standard,
            ContactValue = input.ContactValue,
            PersonId = input.PersonId,
            ContactTypeId = input.ContactTypeId,
        }).ToList();

        await repository.InsertAsync(entities, cancellationToken);

        var results = entities.Select(e => new PersonContactResponse(e)).ToList();
        return results;
    }

    public async Task<PersonContactResponse?> UpdateAsync(PersonContactInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return null;

        entity.Standard = input.Standard;
        entity.ContactValue = input.ContactValue;
        entity.PersonId = input.PersonId;
        entity.ContactTypeId = input.ContactTypeId;

        await repository.UpdateAsync(entity, cancellationToken);

        var result = new PersonContactResponse(entity);
        return result;
    }

    public async Task<List<PersonContactResponse>> UpdateAsync(List<PersonContactInput> inputs,
        CancellationToken cancellationToken = default)
    {
        var entities = new List<PersonContact>();

        foreach (var input in inputs)
        {
            var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);
            if (entity == null) continue;

            entity.Standard = input.Standard;
            entity.ContactValue = input.ContactValue;
            entity.PersonId = input.PersonId;
            entity.ContactTypeId = input.ContactTypeId;

            entities.Add(entity);
        }

        await repository.UpdateAsync(entities, cancellationToken);

        var results = entities.Select(e => new PersonContactResponse(e)).ToList();
        return results;
    }

    public async Task<bool> HardDeleteAsync(PersonContactInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);
        return result > 0;
    }

    public async Task<bool> HardDeleteAsync(List<PersonContactInput>? inputs,
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

    public async Task<int> CountAsync(Expression<Func<PersonContact, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.CountAsync(predicate, cancellationToken);
        return result;
    }
}