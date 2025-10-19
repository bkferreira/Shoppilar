using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
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
        var response = new PersonDocumentResponse(entity);
        return response;
    }

    public async Task<List<PersonDocumentResponse>> GetAllAsync(
        Expression<Func<PersonDocument, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new PersonDocumentResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<PersonDocumentResponse>> GetPagedProjectionAsync(
        Expression<Func<PersonDocument, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedProjectionAsync(
            predicate: predicate,
            selector: PersonDocumentResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var responses = new PaginatedResponse<PersonDocumentResponse>(items, totalCount);

        return responses;
    }

    public async Task<BaseResponse<PersonDocumentResponse?>> InsertAsync(PersonDocumentInput input,
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

        var response =
            new BaseResponse<PersonDocumentResponse?>(true, Messages.Created, new PersonDocumentResponse(entity));

        return response;
    }

    public async Task<BaseResponse<List<PersonDocumentResponse>>> InsertAsync(List<PersonDocumentInput> inputs,
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

        var responses = entities.Select(e => new PersonDocumentResponse(e)).ToList();
        return new BaseResponse<List<PersonDocumentResponse>>(true, Messages.Created, responses);
    }

    public async Task<BaseResponse<PersonDocumentResponse?>> UpdateAsync(PersonDocumentInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return new BaseResponse<PersonDocumentResponse?>(false, Messages.NotFound);

        entity.Standard = input.Standard;
        entity.Validate = input.Validate;
        entity.DocumentNumber = input.DocumentNumber;
        entity.PersonId = input.PersonId;
        entity.DocumentTypeId = input.DocumentTypeId;
        entity.CategoryTypeId = input.CategoryTypeId;

        await repository.UpdateAsync(entity, cancellationToken);

        var response =
            new BaseResponse<PersonDocumentResponse?>(true, Messages.Updated, new PersonDocumentResponse(entity));

        return response;
    }

    public async Task<BaseResponse<List<PersonDocumentResponse>>> UpdateAsync(List<PersonDocumentInput> inputs,
        CancellationToken cancellationToken = default)
    {
        var responses = new List<PersonDocumentResponse>();

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
            responses.Add(new PersonDocumentResponse(entity));
        }

        return new BaseResponse<List<PersonDocumentResponse>>(true, Messages.Updated, responses);
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
        return await repository.CountAsync(predicate, cancellationToken);
    }
}