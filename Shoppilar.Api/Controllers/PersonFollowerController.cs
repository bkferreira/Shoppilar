using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.App;


namespace Shoppilar.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonFollowerController(IPersonFollowerService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BaseResponse<PersonFollowerResponse?>>> GetById(Guid id, string? includeProperties,
        CancellationToken cancellationToken)
    {
        var follower = await service.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
        if (follower == null)
            return NotFound(new BaseResponse<PersonFollowerResponse?>(false, "Seguidor não encontrado"));

        return Ok(new BaseResponse<PersonFollowerResponse?>(true, "Seguidor encontrado", follower));
    }

    [HttpPost("all")]
    public async Task<ActionResult<BaseResponse<List<PersonFollowerResponse>>>> GetAll([FromBody] GetAllRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonFollower>();
        var includes = request.IncludeProperties;
        var result = await service.GetAllAsync(predicate, includes, cancellationToken);

        if (!result.Any())
            return NotFound(new BaseResponse<List<PersonFollowerResponse>>(false, "Nenhum seguidor encontrado"));

        return Ok(new BaseResponse<List<PersonFollowerResponse>>(true, "Seguidores encontrados", result));
    }

    [HttpPost("paged")]
    public async Task<ActionResult<BaseResponse<PaginatedResponse<PersonFollowerResponse>>>> GetPagedProjection(
        [FromBody] GetPagedRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression?.DeserializeLambdaExpression<PersonFollower>();

        var result = await service.GetPagedProjectionAsync(
            predicate,
            page: request.Page,
            pageSize: request.PageSize,
            cancellationToken: cancellationToken
        );

        if (!result.Items.Any())
            return NotFound(new BaseResponse<PaginatedResponse<PersonFollowerResponse>>(false, Messages.NoneFound));

        return Ok(new BaseResponse<PaginatedResponse<PersonFollowerResponse>>(true, Messages.Found, result));
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<PersonFollowerResponse?>>> Insert([FromBody] PersonFollowerInput input,
        CancellationToken cancellationToken)
    {
        var result = await service.InsertAsync(input, cancellationToken);
        if (!result.Success)
            return BadRequest(new BaseResponse<PersonFollowerResponse?>(false, "Falha ao criar seguidor"));

        return CreatedAtAction(nameof(GetById), new { id = result.Item?.Id }, result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var success = await service.HardDeleteAsync(new PersonFollowerInput { Id = id }, cancellationToken);
        if (!success) return NotFound(new BaseResponse<bool>(false, "Seguidor não encontrado"));

        return Ok(new BaseResponse<bool>(true, "Seguidor deletado", true));
    }

    [HttpPost("count")]
    public async Task<ActionResult<BaseResponse<int>>> Count([FromBody] CountRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonFollower>();
        var total = await service.CountAsync(predicate, cancellationToken);

        return Ok(new BaseResponse<int>(true, "Contagem realizada", total));
    }
}