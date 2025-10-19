using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
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
        var response = new PersonContactResponse(entity);
        return response;
    }

    public async Task<List<PersonContactResponse>> GetAllAsync(Expression<Func<PersonContact, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new PersonContactResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<PersonContactResponse>> GetPagedProjectionAsync(
        Expression<Func<PersonContact, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedProjectionAsync(
            predicate: predicate,
            selector: PersonContactResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var responses = new PaginatedResponse<PersonContactResponse>(items, totalCount);

        return responses;
    }

    public async Task<BaseResponse<PersonContactResponse?>> InsertAsync(PersonContactInput input,
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

        var response =
            new BaseResponse<PersonContactResponse?>(true, Messages.Created, new PersonContactResponse(entity));

        return response;
    }

    public async Task<BaseResponse<List<PersonContactResponse>>> InsertAsync(List<PersonContactInput> inputs,
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

        var responses = entities.Select(e => new PersonContactResponse(e)).ToList();
        return new BaseResponse<List<PersonContactResponse>>(true, Messages.Created, responses);
    }

    public async Task<BaseResponse<PersonContactResponse?>> UpdateAsync(PersonContactInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return new BaseResponse<PersonContactResponse?>(false, Messages.NotFound);

        entity.Standard = input.Standard;
        entity.ContactValue = input.ContactValue;
        entity.PersonId = input.PersonId;
        entity.ContactTypeId = input.ContactTypeId;

        await repository.UpdateAsync(entity, cancellationToken);

        var response =
            new BaseResponse<PersonContactResponse?>(true, Messages.Updated, new PersonContactResponse(entity));

        return response;
    }

    public async Task<BaseResponse<List<PersonContactResponse>>> UpdateAsync(List<PersonContactInput> inputs,
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

        var responses = entities.Select(e => new PersonContactResponse(e)).ToList();
        return new BaseResponse<List<PersonContactResponse>>(true, Messages.Updated, responses);
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
        return await repository.CountAsync(predicate, cancellationToken);
    }
}