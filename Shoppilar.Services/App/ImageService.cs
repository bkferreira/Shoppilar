using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class ImageService(IRepo<Image> repository) : IImageService
{
    public async Task<ImageResponse?> GetAsync(Expression<Func<Image, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var result = new ImageResponse(entity);
        return result;
    }

    public async Task<List<ImageResponse>> GetAllAsync(Expression<Func<Image, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var results = entities.Select(x => new ImageResponse(x)).ToList();
        return results;
    }

    public async Task<PaginatedResponse<ImageResponse>> GetPagedAsync(
        Expression<Func<Image, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedAsync(
            predicate: predicate,
            selector: ImageResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var results = new PaginatedResponse<ImageResponse>(items, totalCount);
        return results;
    }

    public async Task<ImageResponse?> InsertAsync(ImageInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new Image
        {
            Id = input.Id ?? Guid.NewGuid(),
            Size = input.Size,
            Url = input.Url,
            FileName = input.FileName,
            ContentType = input.ContentType,
            ContainerName = input.ContainerName,
            ImageTypeId = input.ImageTypeId,
            PersonId = input.PersonId,
            AdId = input.AdId,
            JobId = input.JobId,
            EventId = input.EventId
        };

        await repository.InsertAsync(entity, cancellationToken);

        var result = new ImageResponse(entity);
        return result;
    }

    public async Task<List<ImageResponse>?> InsertAsync(
        List<ImageInput> inputs,
        CancellationToken cancellationToken = default)
    {
        var entities = new List<Image>();

        foreach (var input in inputs)
        {
            var entity = new Image
            {
                Id = input.Id ?? Guid.NewGuid(),
                Size = input.Size,
                Url = input.Url,
                FileName = input.FileName,
                ContentType = input.ContentType,
                ContainerName = input.ContainerName,
                ImageTypeId = input.ImageTypeId,
                PersonId = input.PersonId,
                AdId = input.AdId,
                JobId = input.JobId,
                EventId = input.EventId
            };

            entities.Add(entity);
        }

        await repository.InsertAsync(entities, cancellationToken);

        var result = entities.Select(e => new ImageResponse(e)).ToList();
        return result;
    }

    public async Task<ImageResponse?> UpdateAsync(ImageInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return null;

        entity.Size = input.Size;
        entity.Url = input.Url;
        entity.FileName = input.FileName;
        entity.ContentType = input.ContentType;
        entity.ContainerName = input.ContainerName;
        entity.ImageTypeId = input.ImageTypeId;
        entity.PersonId = input.PersonId;
        entity.AdId = input.AdId;
        entity.JobId = input.JobId;
        entity.EventId = input.EventId;

        await repository.UpdateAsync(entity, cancellationToken);

        var result = new ImageResponse(entity);
        return result;
    }

    public async Task<List<ImageResponse>> UpdateAsync(
        List<ImageInput>? inputs,
        CancellationToken cancellationToken = default)
    {
        if (inputs == null || !inputs.Any())
            return [];

        var updatedEntities = new List<Image>();
        var results = new List<ImageResponse>();

        foreach (var input in inputs)
        {
            var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

            if (entity == null)
                continue;

            entity.Size = input.Size;
            entity.Url = input.Url;
            entity.FileName = input.FileName;
            entity.ContentType = input.ContentType;
            entity.ContainerName = input.ContainerName;
            entity.ImageTypeId = input.ImageTypeId;
            entity.PersonId = input.PersonId;
            entity.AdId = input.AdId;
            entity.JobId = input.JobId;
            entity.EventId = input.EventId;

            updatedEntities.Add(entity);
            results.Add(new ImageResponse(entity));
        }

        if (!updatedEntities.Any())
            return [];

        await repository.UpdateAsync(updatedEntities, cancellationToken);
        return results;
    }

    public async Task<bool> HardDeleteAsync(ImageInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);
        return result > 0;
    }

    public async Task<bool> HardDeleteAsync(List<ImageInput>? inputs,
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

    public async Task<int> CountAsync(Expression<Func<Image, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        var result = await repository.CountAsync(predicate, cancellationToken);
        return result;
    }
}