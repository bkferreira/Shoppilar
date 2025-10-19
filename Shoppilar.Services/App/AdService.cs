using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class AdService(IRepo<Ad> repository) : IAdService
{
    public async Task<AdResponse?> GetAsync(Expression<Func<Ad, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var response = new AdResponse(entity);
        return response;
    }

    public async Task<List<AdResponse>> GetAllAsync(Expression<Func<Ad, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new AdResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<AdResponse>> GetPagedProjectionAsync(
        Expression<Func<Ad, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedProjectionAsync(
            predicate: predicate,
            selector: AdResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var responses = new PaginatedResponse<AdResponse>(items, totalCount);

        return responses;
    }

    public async Task<BaseResponse<AdResponse?>> InsertAsync(AdInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new Ad()
        {
            Id = input.Id ?? Guid.NewGuid(),
            Title = input.Title,
            Description = input.Description,
            Contact = input.Contact,
            ViewsCount = input.ViewsCount,
            Price = input.Price,
            ExpirationDate = input.ExpirationDate,
            Promotion = input.Promotion,
            Donation = input.Donation,
            CityId = input.CityId,
            PersonId = input.PersonId,
            AdTypeId = input.AdTypeId,
            AdSubTypeId = input.AdSubTypeId
        };

        entity.Promotions = input.Promotions?.Select(x => new AdPromotion
        {
            AdId = entity.Id,
            Description = x.Description,
            ExpirationDate = x.ExpirationDate,
            Price = x.Price
        }).ToList() ?? [];

        entity.FeaturedItems = input.FeaturedItems?.Select(x => new AdFeatured
        {
            AdId = entity.Id,
            Description = x.Description,
            ExpirationDate = x.ExpirationDate
        }).ToList() ?? [];

        entity.Images = input.Images?.Select(x => new Image
        {
            Size = x.Size,
            Url = x.Url,
            FileName = x.FileName,
            ContentType = x.ContentType,
            ContainerName = x.ContainerName,
            ImageTypeId = x.ImageTypeId,
            AdId = entity.Id,
        }).ToList() ?? [];

        await repository.InsertAsync(entity, cancellationToken);

        var response = new BaseResponse<AdResponse?>(true, Messages.Created, new AdResponse(entity));

        return response;
    }

    public async Task<BaseResponse<AdResponse?>> UpdateAsync(AdInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return new BaseResponse<AdResponse?>(false, Messages.NotFound);

        entity.Title = input.Title;
        entity.Description = input.Description;
        entity.Contact = input.Contact;
        entity.ViewsCount = input.ViewsCount;
        entity.Price = input.Price;
        entity.ExpirationDate = input.ExpirationDate;
        entity.Promotion = input.Promotion;
        entity.Donation = input.Donation;
        entity.CityId = input.CityId;
        entity.PersonId = input.PersonId;
        entity.AdTypeId = input.AdTypeId;
        entity.AdSubTypeId = input.AdSubTypeId;

        await repository.UpdateAsync(entity, cancellationToken);

        var response = new BaseResponse<AdResponse?>(true, Messages.Updated, new AdResponse(entity));

        return response;
    }

    public async Task<bool> DeleteAsync(AdInput input, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        await repository.DeleteAsync(entity, cancellationToken);

        return true;
    }

    public async Task<bool> DeleteAsync(List<AdInput>? inputs, CancellationToken cancellationToken = default)
    {
        if (inputs == null || inputs.Count == 0)
            return false;

        var ids = inputs.Select(i => i.Id).Where(id => id.HasValue).Select(id => id!.Value).ToList();

        if (!ids.Any())
            return false;

        var entities = await repository.GetAllAsync(
            x => ids.Contains(x.Id),
            null,
            cancellationToken
        );

        if (!entities.Any())
            return false;

        await repository.DeleteAsync(entities, cancellationToken);

        return true;
    }

    public async Task<int> CountAsync(Expression<Func<Ad, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        return await repository.CountAsync(predicate, cancellationToken);
    }
}