using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.App;


namespace Shoppilar.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonContactController(IPersonContactService service) : ControllerBase
{
    [HttpPost("get")]
    public async Task<ActionResult<BaseResponse<PersonContactResponse?>>> GetAsync([FromBody] GetAllRequest request)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonContact>();
        var includes = request.IncludeProperties;

        if (predicate == null) return NotFound(new BaseResponse<PersonContactResponse>(false, Messages.NotFound));

        var response = await service.GetAsync(predicate, includes);
        return Ok(new BaseResponse<PersonContactResponse>(true, Messages.Found, response));
    }

    [HttpPost("get-all")]
    public async Task<ActionResult<BaseResponse<List<PersonContactResponse>>>> GetAll([FromBody] GetAllRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonContact>();
        var includes = request.IncludeProperties;
        var result = await service.GetAllAsync(predicate, includes, cancellationToken);

        if (!result.Any())
            return NotFound(new BaseResponse<List<PersonContactResponse>>(false, Messages.NoneFound));

        return Ok(new BaseResponse<List<PersonContactResponse>>(true, Messages.Found, result));
    }

    [HttpPost("get-paged")]
    public async Task<ActionResult<BaseResponse<PaginatedResponse<PersonContactResponse>>>> GetPaged(
        [FromBody] GetPagedRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression?.DeserializeLambdaExpression<PersonContact>();

        var result = await service.GetPagedAsync(
            predicate,
            page: request.Page,
            pageSize: request.PageSize,
            cancellationToken: cancellationToken
        );

        if (!result.Items.Any())
            return NotFound(new BaseResponse<PaginatedResponse<PersonContactResponse>>(false, Messages.NoneFound));

        return Ok(new BaseResponse<PaginatedResponse<PersonContactResponse>>(true, Messages.Found, result));
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<PersonContactResponse?>>> Insert([FromBody] PersonContactInput input,
        CancellationToken cancellationToken)
    {
        var result = await service.InsertAsync(input, cancellationToken);
        if (result == null)
            return BadRequest(new BaseResponse<PersonContactResponse?>(false, Messages.OperationFailed));

        return Ok(new BaseResponse<PersonContactResponse?>(true, Messages.Created, result));
    }

    [HttpPost("insert-batch")]
    public async Task<ActionResult<BaseResponse<List<PersonContactResponse>>>> InsertBatch(
        [FromBody] List<PersonContactInput> inputs,
        CancellationToken cancellationToken)
    {
        var result = await service.InsertAsync(inputs, cancellationToken);
        if (!result.Any())
            return BadRequest(new BaseResponse<List<PersonContactResponse>>(false, Messages.OperationFailed));

        return Ok(new BaseResponse<List<PersonContactResponse?>>(true, Messages.Created, result!));
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<BaseResponse<PersonContactResponse?>>> Update(Guid id,
        [FromBody] PersonContactInput input,
        CancellationToken cancellationToken)
    {
        if (id != input.Id)
            return NotFound(new BaseResponse<PersonContactResponse?>(false, Messages.NotFound));

        var result = await service.UpdateAsync(input, cancellationToken);
        if (result == null)
            return BadRequest(
                new BaseResponse<PersonContactResponse?>(false, Messages.OperationFailed));

        return Ok(new BaseResponse<PersonContactResponse?>(true, Messages.Updated, result));
    }

    [HttpPut("update-batch")]
    public async Task<ActionResult<BaseResponse<List<PersonContactResponse>>>> UpdateBatch(
        [FromBody] List<PersonContactInput> inputs,
        CancellationToken cancellationToken)
    {
        var result = await service.UpdateAsync(inputs, cancellationToken);
        if (!result.Any())
            return BadRequest(
                new BaseResponse<List<PersonContactResponse>>(false, Messages.OperationFailed));

        return Ok(new BaseResponse<List<PersonContactResponse?>>(true, Messages.Updated, result!));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var success = await service.HardDeleteAsync(new PersonContactInput { Id = id }, cancellationToken);
        if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));

        return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
    }

    [HttpDelete("delete-batch")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<PersonContactInput> inputs,
        CancellationToken cancellationToken)
    {
        var success = await service.HardDeleteAsync(inputs, cancellationToken);
        if (!success) return BadRequest(new BaseResponse<bool>(false, message: Messages.OperationFailed));

        return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
    }

    [HttpPost("count")]
    public async Task<ActionResult<BaseResponse<int>>> Count([FromBody] CountRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonContact>();
        var total = await service.CountAsync(predicate, cancellationToken);

        return Ok(new BaseResponse<int>(true, Messages.Counted, total));
    }
}