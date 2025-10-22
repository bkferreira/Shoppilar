using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class PersonSocialMediaService(IRepo<PersonSocialMedia> repository) : IPersonSocialMediaService
{
    public async Task<PersonSocialMediaResponse?> GetAsync(Expression<Func<PersonSocialMedia, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var response = new PersonSocialMediaResponse(entity);
        return response;
    }

    public async Task<List<PersonSocialMediaResponse>> GetAllAsync(
        Expression<Func<PersonSocialMedia, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new PersonSocialMediaResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<PersonSocialMediaResponse>> GetPagedProjectionAsync(
        Expression<Func<PersonSocialMedia, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedProjectionAsync(
            predicate: predicate,
            selector: PersonSocialMediaResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var responses = new PaginatedResponse<PersonSocialMediaResponse>(items, totalCount);

        return responses;
    }

    public async Task<BaseResponse<PersonSocialMediaResponse?>> InsertAsync(PersonSocialMediaInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new PersonSocialMedia
        {
            ProfileUrl = input.ProfileUrl,
            PersonId = input.PersonId,
            SocialMediaTypeId = input.SocialMediaTypeId
        };

        await repository.InsertAsync(entity, cancellationToken);

        var response =
            new BaseResponse<PersonSocialMediaResponse?>(true, Messages.Created, new PersonSocialMediaResponse(entity));

        return response;
    }

    public async Task<BaseResponse<List<PersonSocialMediaResponse>>> InsertAsync(List<PersonSocialMediaInput> inputs,
        CancellationToken cancellationToken = default)
    {
        var entities = inputs.Select(input => new PersonSocialMedia
        {
            ProfileUrl = input.ProfileUrl,
            PersonId = input.PersonId,
            SocialMediaTypeId = input.SocialMediaTypeId
        }).ToList();

        await repository.InsertAsync(entities, cancellationToken);

        var responses = entities.Select(e => new PersonSocialMediaResponse(e)).ToList();
        return new BaseResponse<List<PersonSocialMediaResponse>>(true, Messages.Created, responses);
    }

    public async Task<BaseResponse<PersonSocialMediaResponse?>> UpdateAsync(PersonSocialMediaInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return new BaseResponse<PersonSocialMediaResponse?>(false, Messages.NotFound);

        entity.ProfileUrl = input.ProfileUrl;
        entity.PersonId = input.PersonId;
        entity.SocialMediaTypeId = input.SocialMediaTypeId;

        await repository.UpdateAsync(entity, cancellationToken);

        var response =
            new BaseResponse<PersonSocialMediaResponse?>(true, Messages.Updated, new PersonSocialMediaResponse(entity));

        return response;
    }

    public async Task<BaseResponse<List<PersonSocialMediaResponse>>> UpdateAsync(List<PersonSocialMediaInput> inputs,
        CancellationToken cancellationToken = default)
    {
        var responses = new List<PersonSocialMediaResponse>();

        foreach (var input in inputs)
        {
            var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);
            if (entity == null) continue;

            entity.ProfileUrl = input.ProfileUrl;
            entity.PersonId = input.PersonId;
            entity.SocialMediaTypeId = input.SocialMediaTypeId;

            await repository.UpdateAsync(entity, cancellationToken);
            responses.Add(new PersonSocialMediaResponse(entity));
        }

        return new BaseResponse<List<PersonSocialMediaResponse>>(true, Messages.Updated, responses);
    }

    public async Task<bool> HardDeleteAsync(PersonSocialMediaInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);

        return result > 0;
    }

    public async Task<bool> HardDeleteAsync(List<PersonSocialMediaInput>? inputs,
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

    public async Task<int> CountAsync(Expression<Func<PersonSocialMedia, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        return await repository.CountAsync(predicate, cancellationToken);
    }
}