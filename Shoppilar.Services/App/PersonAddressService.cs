using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class PersonAddressService(IRepo<PersonAddress> repository) : IPersonAddressService
{
    public async Task<PersonAddressResponse?> GetAsync(Expression<Func<PersonAddress, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var result = new PersonAddressResponse(entity);
        return result;
    }

    public async Task<List<PersonAddressResponse>> GetAllAsync(Expression<Func<PersonAddress, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var results = entities.Select(x => new PersonAddressResponse(x)).ToList();
        return results;
    }

    public async Task<PaginatedResponse<PersonAddressResponse>> GetPagedAsync(
        Expression<Func<PersonAddress, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedAsync(
            predicate: predicate,
            selector: PersonAddressResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var results = new PaginatedResponse<PersonAddressResponse>(items, totalCount);
        return results;
    }

    public async Task<PersonAddressResponse?> InsertAsync(PersonAddressInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new PersonAddress
        {
            Neighborhood = input.Neighborhood,
            Number = input.Number,
            Street = input.Street,
            ZipCode = input.ZipCode,
            Complement = input.Complement,
            Standard = input.Standard,
            PersonId = input.PersonId,
            CityId = input.CityId
        };

        await repository.InsertAsync(entity, cancellationToken);

        var result = new PersonAddressResponse(entity);
        return result;
    }

    public async Task<List<PersonAddressResponse>> InsertAsync(
        List<PersonAddressInput>? inputs,
        CancellationToken cancellationToken = default)
    {
        if (inputs == null || !inputs.Any())
            return [];

        var entities = inputs.Select(input => new PersonAddress
        {
            Neighborhood = input.Neighborhood,
            Number = input.Number,
            Street = input.Street,
            ZipCode = input.ZipCode,
            Complement = input.Complement,
            Standard = input.Standard,
            PersonId = input.PersonId,
            CityId = input.CityId
        }).ToList();

        await repository.InsertAsync(entities, cancellationToken);

        var results = entities.Select(e => new PersonAddressResponse(e)).ToList();
        return results;
    }

    public async Task<PersonAddressResponse?> UpdateAsync(PersonAddressInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return null;

        entity.Neighborhood = input.Neighborhood;
        entity.Number = input.Number;
        entity.Street = input.Street;
        entity.ZipCode = input.ZipCode;
        entity.Complement = input.Complement;
        entity.Standard = input.Standard;
        entity.PersonId = input.PersonId;
        entity.CityId = input.CityId;

        await repository.UpdateAsync(entity, cancellationToken);

        var result = new PersonAddressResponse(entity);
        return result;
    }

    public async Task<List<PersonAddressResponse>> UpdateAsync(
        List<PersonAddressInput>? inputs,
        CancellationToken cancellationToken = default)
    {
        if (inputs == null || !inputs.Any())
            return [];

        var updatedEntities = new List<PersonAddress>();
        var results = new List<PersonAddressResponse>();

        foreach (var input in inputs)
        {
            var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);
            if (entity == null)
                continue;

            entity.Neighborhood = input.Neighborhood;
            entity.Number = input.Number;
            entity.Street = input.Street;
            entity.ZipCode = input.ZipCode;
            entity.Complement = input.Complement;
            entity.Standard = input.Standard;
            entity.PersonId = input.PersonId;
            entity.CityId = input.CityId;

            updatedEntities.Add(entity);
            results.Add(new PersonAddressResponse(entity));
        }

        if (!updatedEntities.Any())
            return [];

        await repository.UpdateAsync(updatedEntities, cancellationToken);
        return results;
    }

    public async Task<bool> HardDeleteAsync(PersonAddressInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);
        return result > 0;
    }

    public async Task<bool> HardDeleteAsync(List<PersonAddressInput>? inputs,
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

    public async Task<int> CountAsync(Expression<Func<PersonAddress, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.CountAsync(predicate, cancellationToken);
        return result;
    }
}