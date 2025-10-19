using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces.App;


namespace Shoppilar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonFollowerController(IPersonFollowerService PersonFollowerService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BaseResponse<PersonFollowerResponse?>>> GetById(Guid id, string? includeProperties,
        CancellationToken cancellationToken)
    {
        var follower = await PersonFollowerService.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
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
        var result = await PersonFollowerService.GetAllAsync(predicate, includes, cancellationToken);

        if (!result.Any())
            return NotFound(new BaseResponse<List<PersonFollowerResponse>>(false, "Nenhum seguidor encontrado"));

        return Ok(new BaseResponse<List<PersonFollowerResponse>>(true, "Seguidores encontrados", result));
    }

    [HttpPost("paged")]
    public async Task<ActionResult<BaseResponse<PaginatedResponse<PersonFollowerResponse>>>> GetPaged(
        [FromBody] GetPagedRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonFollower>();
        var includes = request.IncludeProperties;
        var result =
            await PersonFollowerService.GetPagedAsync(predicate, includes, request.Page, request.PageSize,
                cancellationToken);

        if (!result.Items.Any())
            return NotFound(
                new BaseResponse<PaginatedResponse<PersonFollowerResponse>>(false, "Nenhum seguidor encontrado"));

        return Ok(new BaseResponse<PaginatedResponse<PersonFollowerResponse>>(true, "Seguidores encontrados", result));
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<PersonFollowerResponse?>>> Insert([FromBody] PersonFollowerInput input,
        CancellationToken cancellationToken)
    {
        var result = await PersonFollowerService.InsertAsync(input, cancellationToken);
        if (!result.Success)
            return BadRequest(new BaseResponse<PersonFollowerResponse?>(false, "Falha ao criar seguidor"));

        return CreatedAtAction(nameof(GetById), new { id = result.Item?.Id }, result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var success = await PersonFollowerService.HardDeleteAsync(new PersonFollowerInput { Id = id }, cancellationToken);
        if (!success) return NotFound(new BaseResponse<bool>(false, "Seguidor não encontrado"));

        return Ok(new BaseResponse<bool>(true, "Seguidor deletado", true));
    }

    [HttpPost("count")]
    public async Task<ActionResult<BaseResponse<int>>> Count([FromBody] CountRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonFollower>();
        var total = await PersonFollowerService.CountAsync(predicate, cancellationToken);

        return Ok(new BaseResponse<int>(true, "Contagem realizada", total));
    }
}