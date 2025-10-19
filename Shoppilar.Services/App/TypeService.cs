using System.Linq.Expressions;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Services.App;

public class TypeService<T>(IRepo<T> repository) : ITypeService<T> where T : BaseType, new()
{
    public async Task<TypeResponse?> GetAsync(Expression<Func<T, bool>> predicate,
        string? includeProperties,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(predicate, includeProperties, cancellationToken);
        if (entity == null) return null;
        return new TypeResponse(entity);
    }

    public async Task<List<TypeResponse>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
        string? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetAllAsync(predicate, includeProperties, cancellationToken);
        return entities.Select(x => new TypeResponse(x)).ToList();
    }

    public async Task<PaginatedResponse<TypeResponse>> GetPagedAsync(
        Expression<Func<T, bool>>? predicate = null,
        string? includeProperties = null,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var (items, totalCount) =
            await repository.GetPagedAsync(predicate, includeProperties, page, pageSize, cancellationToken);
        return new PaginatedResponse<TypeResponse>(
            items.Select(u => new TypeResponse(u)).ToList(),
            totalCount
        );
    }

    public async Task<BaseResponse<TypeResponse?>> InsertAsync(TypeInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = new T
        {
            Id = input.Id ?? Guid.NewGuid(),
            Description = input.Description ?? string.Empty,
            Icon = input.Icon,
            Color = input.Color
        };

        ApplySubclassProperties(entity, input);

        await repository.InsertAsync(entity, cancellationToken);

        return new BaseResponse<TypeResponse?>(true, Messages.Created, new TypeResponse(entity));
    }

    public async Task<BaseResponse<TypeResponse?>> UpdateAsync(TypeInput input,
        CancellationToken cancellationToken = default)
    {
        if (input.Id == null)
            return new BaseResponse<TypeResponse?>(false, Messages.NotFound);

        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);
        if (entity == null)
            return new BaseResponse<TypeResponse?>(false, Messages.NotFound);

        entity.Description = input.Description ?? string.Empty;
        entity.Icon = input.Icon;
        entity.Color = input.Color;

        ApplySubclassProperties(entity, input);

        await repository.UpdateAsync(entity, cancellationToken);

        return new BaseResponse<TypeResponse?>(true, Messages.Updated, new TypeResponse(entity));
    }

    public async Task<bool> HardDeleteAsync(TypeInput input,
        CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetAsync(x => x.Id == input.Id, null, cancellationToken);

        if (entity == null) return false;

        var result = await repository.HardDeleteAsync(entity, cancellationToken);

        return result > 0;
    }

    private void ApplySubclassProperties(T entity, TypeInput input)
    {
        switch (entity)
        {
            case JobType jobType:
                jobType.MaxImageCount = input.MaxImageCount;
                break;

            case EventType eventType:
                eventType.MaxImageCount = input.MaxImageCount;
                break;

            case AdType adType:
                adType.MaxImageCount = input.MaxImageCount;
                HandleAdSubTypes(adType, input.SubTypes);
                break;

            case AdSubType adSubType:
                if (input.AdTypeId != null)
                    adSubType.AdTypeId = input.AdTypeId.Value;
                break;
        }
    }

    private void HandleAdSubTypes(AdType adType, List<TypeInput>? subTypesInput)
    {
        if (subTypesInput == null) return;

        foreach (var stInput in subTypesInput)
        {
            var sub = adType.SubTypes.FirstOrDefault(x => x.Id == stInput.Id);
            if (sub != null)
            {
                sub.Description = stInput.Description ?? string.Empty;
                sub.Icon = stInput.Icon;
                sub.Color = stInput.Color;
            }
            else
            {
                adType.SubTypes.Add(new AdSubType
                {
                    Id = stInput.Id ?? Guid.NewGuid(),
                    Description = stInput.Description ?? string.Empty,
                    Icon = stInput.Icon,
                    Color = stInput.Color,
                    AdTypeId = adType.Id
                });
            }
        }
    }
}