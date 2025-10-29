using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController(IPersonService service) : ControllerBase
{
    [HttpPost("get")]
    public async Task<ActionResult<BaseResponse<PersonResponse?>>> GetAsync([FromBody] GetAllRequest request)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<Person>();
        var includes = request.IncludeProperties;

        if (predicate == null) return NotFound(new BaseResponse<PersonResponse>(false, Messages.NotFound));

        var response = await service.GetAsync(predicate, includes);
        return Ok(new BaseResponse<PersonResponse>(true, Messages.Found, response));
    }

    [HttpPost("get-all")]
    public async Task<ActionResult<BaseResponse<List<PersonResponse>>>> GetAll([FromBody] GetAllRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<Person>();
        var includes = request.IncludeProperties;
        var result = await service.GetAllAsync(predicate, includes, cancellationToken);

        if (!result.Any())
            return NotFound(new BaseResponse<List<PersonResponse>>(false, Messages.NoneFound));

        return Ok(new BaseResponse<List<PersonResponse>>(true, Messages.Found, result));
    }

    [HttpPost("get-paged")]
    public async Task<ActionResult<BaseResponse<PaginatedResponse<PersonResponse>>>> GetPaged(
        [FromBody] GetPagedRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression?.DeserializeLambdaExpression<Person>();

        var result = await service.GetPagedAsync(
            predicate,
            page: request.Page,
            pageSize: request.PageSize,
            cancellationToken: cancellationToken
        );

        if (!result.Items.Any())
            return NotFound(new BaseResponse<PaginatedResponse<PersonResponse>>(false, Messages.NoneFound));

        return Ok(new BaseResponse<PaginatedResponse<PersonResponse>>(true, Messages.Found, result));
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<BaseResponse<PersonResponse?>>> Update(Guid id,
        [FromBody] PersonInput input,
        CancellationToken cancellationToken)
    {
        if (id != input.Id)
            return NotFound(new BaseResponse<PersonResponse?>(false, Messages.NotFound));

        var result = await service.UpdateAsync(input, cancellationToken);
        if (result == null)
            return BadRequest(
                new BaseResponse<PersonResponse?>(false, Messages.OperationFailed));

        return Ok(new BaseResponse<PersonResponse?>(true, Messages.Updated, result));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var success = await service.DeleteAsync(new PersonInput { Id = id }, cancellationToken);
        if (!success) return BadRequest(new BaseResponse<bool>(false, message: Messages.OperationFailed));

        return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
    }

    [HttpPost("count")]
    public async Task<ActionResult<BaseResponse<int>>> Count([FromBody] GetAllRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<Person>();
        var total = await service.CountAsync(predicate, cancellationToken);

        return Ok(new BaseResponse<int>(true, Messages.Counted, total));
    }
}