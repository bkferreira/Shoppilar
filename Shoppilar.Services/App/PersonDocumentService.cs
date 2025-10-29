using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class PersonDocumentService(IRepo<PersonDocument> repository) : IPersonDocumentService
{
    public async Task<PersonDocumentResponse?> GetAsync(Expression<Func<PersonDocument, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var result = new PersonDocumentResponse(entity);
        return result;
    }

    public async Task<List<PersonDocumentResponse>> GetAllAsync(
        Expression<Func<PersonDocument, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var results = entities.Select(x => new PersonDocumentResponse(x)).ToList();
        return results;
    }

    public async Task<PaginatedResponse<PersonDocumentResponse>> GetPagedAsync(
        Expression<Func<PersonDocument, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedAsync(
            predicate: predicate,
            selector: PersonDocumentResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var results = new PaginatedResponse<PersonDocumentResponse>(items, totalCount);
        return results;
    }

    public async Task<PersonDocumentResponse?> InsertAsync(PersonDocumentInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new PersonDocument
        {
            Standard = input.Standard,
            Validate = input.Validate,
            DocumentNumber = input.DocumentNumber,
            PersonId = input.PersonId,
            DocumentTypeId = input.DocumentTypeId,
            CategoryTypeId = input.CategoryTypeId,
        };

        await repository.InsertAsync(entity, cancellationToken);

        var result = new PersonDocumentResponse(entity);
        return result;
    }

    public async Task<List<PersonDocumentResponse>> InsertAsync(List<PersonDocumentInput> inputs,
        CancellationToken cancellationToken = default)
    {
        var entities = inputs.Select(input => new PersonDocument
        {
            Standard = input.Standard,
            Validate = input.Validate,
            DocumentNumber = input.DocumentNumber,
            PersonId = input.PersonId,
            DocumentTypeId = input.DocumentTypeId,
            CategoryTypeId = input.CategoryTypeId,
        }).ToList();

        await repository.InsertAsync(entities, cancellationToken);

        var results = entities.Select(e => new PersonDocumentResponse(e)).ToList();
        return results;
    }

    public async Task<PersonDocumentResponse?> UpdateAsync(PersonDocumentInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return null;

        entity.Standard = input.Standard;
        entity.Validate = input.Validate;
        entity.DocumentNumber = input.DocumentNumber;
        entity.PersonId = input.PersonId;
        entity.DocumentTypeId = input.DocumentTypeId;
        entity.CategoryTypeId = input.CategoryTypeId;

        await repository.UpdateAsync(entity, cancellationToken);

        var result = new PersonDocumentResponse(entity);
        return result;
    }

    public async Task<List<PersonDocumentResponse>> UpdateAsync(List<PersonDocumentInput> inputs,
        CancellationToken cancellationToken = default)
    {
        var results = new List<PersonDocumentResponse>();

        foreach (var input in inputs)
        {
            var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);
            if (entity == null) continue;

            entity.Standard = input.Standard;
            entity.Validate = input.Validate;
            entity.DocumentNumber = input.DocumentNumber;
            entity.PersonId = input.PersonId;
            entity.DocumentTypeId = input.DocumentTypeId;
            entity.CategoryTypeId = input.CategoryTypeId;

            await repository.UpdateAsync(entity, cancellationToken);
            results.Add(new PersonDocumentResponse(entity));
        }

        return results;
    }

    public async Task<bool> HardDeleteAsync(PersonDocumentInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);
        return result > 0;
    }

    public async Task<bool> HardDeleteAsync(List<PersonDocumentInput>? inputs,
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

    public async Task<int> CountAsync(Expression<Func<PersonDocument, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.CountAsync(predicate, cancellationToken);
        return result;
    }
}