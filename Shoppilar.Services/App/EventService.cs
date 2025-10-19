using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class EventService(IRepo<Event> repository) : IEventService
{
    public async Task<EventResponse?> GetAsync(Expression<Func<Event, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var response = new EventResponse(entity);
        return response;
    }

    public async Task<List<EventResponse>> GetAllAsync(Expression<Func<Event, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new EventResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<EventResponse>> GetPagedProjectionAsync(
        Expression<Func<Event, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedProjectionAsync(
            predicate: predicate,
            selector: EventResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var responses = new PaginatedResponse<EventResponse>(items, totalCount);

        return responses;
    }

    public async Task<BaseResponse<EventResponse?>> InsertAsync(EventInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new Event
        {
            Id = input.Id ?? Guid.NewGuid(),
            Title = input.Title,
            Description = input.Description,
            Contact = input.Contact,
            ExternalUrl = input.ExternalUrl,
            Location = input.Location,
            Price = input.Price,
            IsPublic = input.IsPublic,
            ExpirationDate = input.ExpirationDate,
            StartDate = input.StartDate,
            EndDate = input.EndDate,
            EventTypeId = input.EventTypeId,
            PersonId = input.PersonId,
            ContactTypeId = input.ContactTypeId,
            CityId = input.CityId,
        };

        entity.Images = input.Images?.Select(x => new Image
        {
            Size = x.Size,
            Url = x.Url,
            FileName = x.FileName,
            ContentType = x.ContentType,
            ContainerName = x.ContainerName,
            ImageTypeId = x.ImageTypeId,
            EventId = entity.Id,
        }).ToList() ?? [];

        await repository.InsertAsync(entity, cancellationToken);

        var response = new BaseResponse<EventResponse?>(true, Messages.Created, new EventResponse(entity));

        return response;
    }

    public async Task<BaseResponse<EventResponse?>> UpdateAsync(EventInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return new BaseResponse<EventResponse?>(false, Messages.NotFound);

        entity.Title = input.Title;
        entity.Description = input.Description;
        entity.Contact = input.Contact;
        entity.ExternalUrl = input.ExternalUrl;
        entity.Location = input.Location;
        entity.Price = input.Price;
        entity.IsPublic = input.IsPublic;
        entity.ExpirationDate = input.ExpirationDate;
        entity.StartDate = input.StartDate;
        entity.EndDate = input.EndDate;
        entity.EventTypeId = input.EventTypeId;
        entity.PersonId = input.PersonId;
        entity.ContactTypeId = input.ContactTypeId;
        entity.CityId = input.CityId;

        await repository.UpdateAsync(entity, cancellationToken);

        var response = new BaseResponse<EventResponse?>(true, Messages.Updated, new EventResponse(entity));

        return response;
    }

    public async Task<bool> HardDeleteAsync(EventInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);

        return result > 0;
    }

    public async Task<bool> HardDeleteAsync(List<EventInput>? inputs,
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

    public async Task<int> CountAsync(Expression<Func<Event, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        return await repository.CountAsync(predicate, cancellationToken);
    }
}