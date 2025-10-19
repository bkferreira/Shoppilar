using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class PersonService(IRepo<Person> repository) : IPersonService
{
    public async Task<PersonResponse?> GetAsync(Expression<Func<Person, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var response = new PersonResponse(entity);
        return response;
    }

    public async Task<List<PersonResponse>> GetAllAsync(Expression<Func<Person, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new PersonResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<PersonResponse>> GetPagedProjectionAsync(
        Expression<Func<Person, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedProjectionAsync(
            predicate: predicate,
            selector: PersonResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var responses = new PaginatedResponse<PersonResponse>(items, totalCount);

        return responses;
    }

    public async Task<BaseResponse<PersonResponse?>> InsertAsync(PersonInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new Person
        {
            Id = input.Id ?? Guid.NewGuid(),
            Name = input.Name,
            Birth = input.Birth,
            CreatedById = input.CreatedById,
            PersonTypeId = input.PersonTypeId,
            ImageId = input.ImageId,
        };

        entity.Image = input.Image != null
            ? new Image
            {
                Size = input.Image.Size,
                Url = input.Image.Url,
                FileName = input.Image.FileName,
                ContentType = input.Image.ContentType,
                ContainerName = input.Image.ContainerName,
                ImageTypeId = input.Image.ImageTypeId,
                PersonId = entity.Id,
            }
            : null;

        entity.Addresses = input.Addresses?.Select(x => new PersonAddress
        {
            CityId = x.CityId,
            Street = x.Street,
            ZipCode = x.ZipCode,
            Neighborhood = x.Neighborhood,
            Number = x.Number,
            Standard = x.Standard,
            Complement = x.Complement,
            PersonId = entity.Id
        }).ToList() ?? [];

        entity.Contacts = input.Contacts?.Select(x => new PersonContact
        {
            ContactValue = x.ContactValue,
            ContactTypeId = x.ContactTypeId,
            Standard = x.Standard,
            PersonId = entity.Id
        }).ToList() ?? [];

        entity.Documents = input.Documents?.Select(x => new PersonDocument
        {
            DocumentNumber = x.DocumentNumber,
            DocumentTypeId = x.DocumentTypeId,
            Standard = x.Standard,
            CategoryTypeId = x.CategoryTypeId,
            Validate = x.Validate,
            PersonId = entity.Id
        }).ToList() ?? [];

        entity.SocialMedias = input.SocialMedias?.Select(x => new PersonSocialMedia
        {
            SocialMediaTypeId = x.SocialMediaTypeId,
            ProfileUrl = x.ProfileUrl,
            PersonId = entity.Id
        }).ToList() ?? [];

        await repository.InsertAsync(entity, cancellationToken);

        var response = new BaseResponse<PersonResponse?>(true, Messages.Created, new PersonResponse(entity));

        return response;
    }

    public async Task<BaseResponse<PersonResponse?>> UpdateAsync(PersonInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return new BaseResponse<PersonResponse?>(false, Messages.NotFound);

        entity.Name = input.Name;
        entity.Birth = input.Birth;
        entity.PersonTypeId = input.PersonTypeId;

        await repository.UpdateAsync(entity, cancellationToken);

        var response = new BaseResponse<PersonResponse?>(true, Messages.Updated, new PersonResponse(entity));

        return response;
    }

    public async Task<bool> DeleteAsync(PersonInput input, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        await repository.DeleteAsync(entity, cancellationToken);

        return true;
    }

    public async Task<int> CountAsync(Expression<Func<Person, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        return await repository.CountAsync(predicate, cancellationToken);
    }
}