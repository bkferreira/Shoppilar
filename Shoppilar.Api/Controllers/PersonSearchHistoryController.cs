using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.App;


namespace Shoppilar.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonSearchHistoryController(IPersonSearchHistoryService service) : ControllerBase
{
    [HttpPost("get")]
    public async Task<ActionResult<BaseResponse<PersonSearchHistoryResponse?>>> GetAsync(
        [FromBody] GetAllRequest request)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonSearchHistory>();
        var includes = request.IncludeProperties;

        if (predicate == null)
            return NotFound(new BaseResponse<PersonSearchHistoryResponse>(false, Messages.NotFound));

        var response = await service.GetAsync(predicate, includes);
        return Ok(new BaseResponse<PersonSearchHistoryResponse>(true, Messages.Found, response));
    }

    [HttpPost("get-all")]
    public async Task<ActionResult<BaseResponse<List<PersonSearchHistoryResponse>>>> GetAll(
        [FromBody] GetAllRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonSearchHistory>();
        var includes = request.IncludeProperties;
        var result = await service.GetAllAsync(predicate, includes, cancellationToken);

        if (!result.Any())
            return NotFound(new BaseResponse<List<PersonSearchHistoryResponse>>(false, Messages.NoneFound));

        return Ok(new BaseResponse<List<PersonSearchHistoryResponse>>(true, Messages.Found, result));
    }

    [HttpPost("get-paged")]
    public async Task<ActionResult<BaseResponse<PaginatedResponse<PersonSearchHistoryResponse>>>> GetPaged(
        [FromBody] GetPagedRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression?.DeserializeLambdaExpression<PersonSearchHistory>();

        var result = await service.GetPagedAsync(
            predicate,
            page: request.Page,
            pageSize: request.PageSize,
            cancellationToken: cancellationToken
        );

        if (!result.Items.Any())
            return NotFound(
                new BaseResponse<PaginatedResponse<PersonSearchHistoryResponse>>(false, Messages.NoneFound));

        return Ok(new BaseResponse<PaginatedResponse<PersonSearchHistoryResponse>>(true, Messages.Found, result));
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<PersonSearchHistoryResponse?>>> Insert(
        [FromBody] PersonSearchHistoryInput input,
        CancellationToken cancellationToken)
    {
        var result = await service.InsertAsync(input, cancellationToken);
        if (result == null)
            return BadRequest(new BaseResponse<PersonSearchHistoryResponse?>(false, Messages.OperationFailed));

        return Ok(new BaseResponse<PersonSearchHistoryResponse?>(true, Messages.Created, result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var success =
            await service.HardDeleteAsync(new PersonSearchHistoryInput { Id = id }, cancellationToken);
        if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));

        return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
    }

    [HttpDelete("delete-batch")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<PersonSearchHistoryInput> inputs,
        CancellationToken cancellationToken)
    {
        var success = await service.HardDeleteAsync(inputs, cancellationToken);
        if (!success) return NotFound(new BaseResponse<bool>(false, Messages.OperationFailed));

        return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
    }
}