using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App.Service;

namespace Shoppilar.Services.App;

public class JobService(IRepo<Job> repository) : IJobService
{
    public async Task<JobResponse?> GetAsync(Expression<Func<Job, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var response = new JobResponse(entity);
        return response;
    }

    public async Task<List<JobResponse>> GetAllAsync(Expression<Func<Job, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new JobResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<JobResponse>> GetPagedAsync(
        Expression<Func<Job, bool>>? predicate = null,
        string? includeProperties = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) =
            await repository.GetPagedAsync(predicate, includeProperties, page, pageSize, cancellationToken);
        var responses = new PaginatedResponse<JobResponse>(
            items.Select(u => new JobResponse(u)).ToList(),
            totalCount
        );
        return responses;
    }

    public async Task<BaseResponse<JobResponse?>> InsertAsync(JobInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new Job
        {
            Id = input.Id ?? Guid.NewGuid(),
            Description = input.Description,
            Contact = input.Contact,
            ExpirationDate = input.ExpirationDate,
            Salary = input.Salary,
            PersonId = input.PersonId,
            ContactTypeId = input.ContactTypeId,
            JobTypeId = input.JobTypeId
        };

        entity.Images = input.Images?.Select(x => new Image
        {
            Size = x.Size,
            Url = x.Url,
            FileName = x.FileName,
            ContentType = x.ContentType,
            ContainerName = x.ContainerName,
            ImageTypeId = x.ImageTypeId,
            JobId = entity.Id,
        }).ToList() ?? [];

        await repository.InsertAsync(entity, cancellationToken);

        var response = new BaseResponse<JobResponse?>(true, Messages.Created, new JobResponse(entity));

        return response;
    }

    public async Task<BaseResponse<JobResponse?>> UpdateAsync(JobInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return new BaseResponse<JobResponse?>(false, Messages.NotFound);

        entity.Description = input.Description;
        entity.Contact = input.Contact;
        entity.ExpirationDate = input.ExpirationDate;
        entity.PersonId = input.PersonId;
        entity.ContactTypeId = input.ContactTypeId;

        await repository.UpdateAsync(entity, cancellationToken);

        var response = new BaseResponse<JobResponse?>(true, Messages.Updated, new JobResponse(entity));

        return response;
    }

    public async Task<bool> HardDeleteAsync(JobInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);

        return result > 0;
    }

    public async Task<bool> HardDeleteAsync(List<JobInput>? inputs,
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

    public async Task<int> CountAsync(Expression<Func<Job, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        return await repository.CountAsync(predicate, cancellationToken);
    }
}