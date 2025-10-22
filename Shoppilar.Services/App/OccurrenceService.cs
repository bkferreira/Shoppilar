using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class OccurrenceService(IRepo<Occurrence> repository) : IOccurrenceService
{
    public async Task<OccurrenceResponse?> GetAsync(Expression<Func<Occurrence, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        var response = new OccurrenceResponse(entity);
        return response;
    }

    public async Task<List<OccurrenceResponse>> GetAllAsync(Expression<Func<Occurrence, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        var responses = entities.Select(x => new OccurrenceResponse(x)).ToList();
        return responses;
    }

    public async Task<PaginatedResponse<OccurrenceResponse>> GetPagedProjectionAsync(
        Expression<Func<Occurrence, bool>>? predicate = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) = await repository.GetPagedProjectionAsync(
            predicate: predicate,
            selector: OccurrenceResponse.Projection,
            page: page,
            pageSize: pageSize,
            cancellationToken: cancellationToken
        );

        var responses = new PaginatedResponse<OccurrenceResponse>(items, totalCount);

        return responses;
    }

    public async Task<BaseResponse<OccurrenceResponse?>> InsertAsync(OccurrenceInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new Occurrence
        {
            Id = input.Id ?? Guid.NewGuid(),
            Description = input.Description,
            ResolutionComment = input.ResolutionComment,
            Resolved = input.Resolved,
            ResolvedAt = input.ResolvedAt,
            TargetId = input.TargetId,
            TargetTypeId = input.TargetTypeId,
            ReportedById = input.ReportedById,
            OccurrenceTypeId = input.OccurrenceTypeId
        };

        await repository.InsertAsync(entity, cancellationToken);

        var response = new BaseResponse<OccurrenceResponse?>(true, Messages.Created, new OccurrenceResponse(entity));

        return response;
    }

    public async Task<BaseResponse<OccurrenceResponse?>> UpdateAsync(OccurrenceInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null)
            return new BaseResponse<OccurrenceResponse?>(false, Messages.NotFound);

        entity.Description = input.Description;
        entity.ResolutionComment = input.ResolutionComment;
        entity.Resolved = input.Resolved;
        entity.ResolvedAt = input.ResolvedAt;
        entity.TargetId = input.TargetId;
        entity.TargetTypeId = input.TargetTypeId;
        entity.ReportedById = input.ReportedById;
        entity.OccurrenceTypeId = input.OccurrenceTypeId;

        await repository.UpdateAsync(entity, cancellationToken);

        var response = new BaseResponse<OccurrenceResponse?>(true, Messages.Updated, new OccurrenceResponse(entity));

        return response;
    }

    public async Task<bool> HardDeleteAsync(OccurrenceInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);

        return result > 0;
    }

    public async Task<bool> HardDeleteAsync(List<OccurrenceInput>? inputs,
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

    public async Task<int> CountAsync(Expression<Func<Occurrence, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        return await repository.CountAsync(predicate, cancellationToken);
    }
}