using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonSocialMediaController(IPersonSocialMediaService service) : ControllerBase
{
    [HttpPost("get")]
    public async Task<ActionResult<BaseResponse<PersonSocialMediaResponse?>>> GetAsync(
        [FromBody] GetAllRequest request)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonSocialMedia>();
        var includes = request.IncludeProperties;

        if (predicate == null)
            return NotFound(new BaseResponse<PersonSocialMediaResponse>(false, Messages.NotFound));

        var response = await service.GetAsync(predicate, includes);
        return Ok(new BaseResponse<PersonSocialMediaResponse>(true, Messages.Found, response));
    }

    [HttpPost("get-all")]
    public async Task<ActionResult<BaseResponse<List<PersonSocialMediaResponse>>>> GetAll(
        [FromBody] GetAllRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonSocialMedia>();
        var includes = request.IncludeProperties;
        var result = await service.GetAllAsync(predicate, includes, cancellationToken);

        if (!result.Any())
            return NotFound(new BaseResponse<List<PersonSocialMediaResponse>>(false, Messages.NoneFound));

        return Ok(new BaseResponse<List<PersonSocialMediaResponse>>(true, Messages.Found, result));
    }

    [HttpPost("get-paged")]
    public async Task<ActionResult<BaseResponse<PaginatedResponse<PersonSocialMediaResponse>>>> GetPaged(
        [FromBody] GetPagedRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression?.DeserializeLambdaExpression<PersonSocialMedia>();

        var result = await service.GetPagedAsync(
            predicate,
            page: request.Page,
            pageSize: request.PageSize,
            cancellationToken: cancellationToken
        );

        if (!result.Items.Any())
            return NotFound(new BaseResponse<PaginatedResponse<PersonSocialMediaResponse>>(false, Messages.NoneFound));

        return Ok(new BaseResponse<PaginatedResponse<PersonSocialMediaResponse>>(true, Messages.Found, result));
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<PersonSocialMediaResponse?>>> Insert(
        [FromBody] PersonSocialMediaInput input,
        CancellationToken cancellationToken)
    {
        var result = await service.InsertAsync(input, cancellationToken);
        if (result == null)
            return BadRequest(new BaseResponse<PersonSocialMediaResponse?>(false, Messages.OperationFailed));

        return Ok(new BaseResponse<PersonSocialMediaResponse?>(true, Messages.Created, result));
    }

    [HttpPost("insert-batch")]
    public async Task<ActionResult<BaseResponse<List<PersonSocialMediaResponse>>>> InsertBatch(
        [FromBody] List<PersonSocialMediaInput> inputs,
        CancellationToken cancellationToken)
    {
        var result = await service.InsertAsync(inputs, cancellationToken);
        if (!result.Any())
            return BadRequest(new BaseResponse<List<PersonSocialMediaResponse>>(false, Messages.OperationFailed));

        return Ok(new BaseResponse<List<PersonSocialMediaResponse?>>(true, Messages.Created, result!));
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<BaseResponse<PersonSocialMediaResponse?>>> Update(Guid id,
        [FromBody] PersonSocialMediaInput input,
        CancellationToken cancellationToken)
    {
        if (id != input.Id)
            return NotFound(new BaseResponse<PersonSocialMediaResponse?>(false, Messages.NotFound));

        var result = await service.UpdateAsync(input, cancellationToken);
        if (result == null)
            return BadRequest(
                new BaseResponse<PersonSocialMediaResponse?>(false, Messages.OperationFailed));

        return Ok(new BaseResponse<PersonSocialMediaResponse?>(true, Messages.Updated, result));
    }

    [HttpPut("update-batch")]
    public async Task<ActionResult<BaseResponse<List<PersonSocialMediaResponse>>>> UpdateBatch(
        [FromBody] List<PersonSocialMediaInput> inputs,
        CancellationToken cancellationToken)
    {
        var result = await service.UpdateAsync(inputs, cancellationToken);
        if (!result.Any())
            return BadRequest(
                new BaseResponse<List<PersonSocialMediaResponse>>(false, Messages.OperationFailed));

        return Ok(new BaseResponse<List<PersonSocialMediaResponse?>>(true, Messages.Updated, result!));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var success = await service.HardDeleteAsync(new PersonSocialMediaInput() { Id = id }, cancellationToken);
        if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));

        return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
    }

    [HttpDelete("delete-batch")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<PersonSocialMediaInput> inputs,
        CancellationToken cancellationToken)
    {
        var success = await service.HardDeleteAsync(inputs, cancellationToken);
        if (!success) return BadRequest(new BaseResponse<bool>(false, message: Messages.OperationFailed));

        return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
    }

    [HttpPost("count")]
    public async Task<ActionResult<int>> Count([FromBody] GetAllRequest request, CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonSocialMedia>();
        var result = await service.CountAsync(predicate, cancellationToken);
        return Ok(result);
    }
}