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
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BaseResponse<PersonSearchHistoryResponse?>>> GetById(Guid id,
        string? includeProperties,
        CancellationToken cancellationToken)
    {
        var result = await service.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
        if (result == null)
            return NotFound(new BaseResponse<PersonSearchHistoryResponse?>(false, "Histórico não encontrado"));

        return Ok(new BaseResponse<PersonSearchHistoryResponse?>(true, "Histórico encontrado", result));
    }

    [HttpPost("all")]
    public async Task<ActionResult<BaseResponse<List<PersonSearchHistoryResponse>>>> GetAll(
        [FromBody] GetAllRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonSearchHistory>();
        var includes = request.IncludeProperties;
        var result = await service.GetAllAsync(predicate, includes, cancellationToken);

        if (!result.Any())
            return NotFound(new BaseResponse<List<PersonSearchHistoryResponse>>(false, "Nenhum histórico encontrado"));

        return Ok(new BaseResponse<List<PersonSearchHistoryResponse>>(true, "Históricos encontrados", result));
    }

    [HttpPost("paged")]
    public async Task<ActionResult<BaseResponse<PaginatedResponse<PersonSearchHistoryResponse>>>> GetPagedProjection(
        [FromBody] GetPagedRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression?.DeserializeLambdaExpression<PersonSearchHistory>();

        var result = await service.GetPagedProjectionAsync(
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
        if (!result.Success)
            return BadRequest(new BaseResponse<PersonSearchHistoryResponse?>(false, "Falha ao criar histórico"));

        return CreatedAtAction(nameof(GetById), new { id = result.Item?.Id }, result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var success =
            await service.HardDeleteAsync(new PersonSearchHistoryInput { Id = id }, cancellationToken);
        if (!success) return NotFound(new BaseResponse<bool>(false, "Histórico não encontrado"));

        return Ok(new BaseResponse<bool>(true, "Histórico deletado", true));
    }

    [HttpDelete("batch")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<PersonSearchHistoryInput> inputs,
        CancellationToken cancellationToken)
    {
        var success = await service.HardDeleteAsync(inputs, cancellationToken);
        if (!success) return NotFound(new BaseResponse<bool>(false, "Nenhum histórico encontrado para deletar"));

        return Ok(new BaseResponse<bool>(true, "Históricos deletados", true));
    }
}