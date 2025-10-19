using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces.App;


namespace Shoppilar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonDocumentController(IPersonDocumentService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BaseResponse<PersonDocumentResponse?>>> GetById(Guid id, string? includeProperties,
        CancellationToken cancellationToken)
    {
        var doc = await service.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
        if (doc == null) return NotFound(new BaseResponse<PersonDocumentResponse?>(false, "Documento não encontrado"));

        return Ok(new BaseResponse<PersonDocumentResponse?>(true, "Documento encontrado", doc));
    }

    [HttpPost("all")]
    public async Task<ActionResult<BaseResponse<List<PersonDocumentResponse>>>> GetAll([FromBody] GetAllRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonDocument>();
        var includes = request.IncludeProperties;
        var result = await service.GetAllAsync(predicate, includes, cancellationToken);

        if (!result.Any())
            return NotFound(new BaseResponse<List<PersonDocumentResponse>>(false, "Nenhum documento encontrado"));

        return Ok(new BaseResponse<List<PersonDocumentResponse>>(true, "Documentos encontrados", result));
    }

    [HttpPost("paged")]
    public async Task<ActionResult<BaseResponse<PaginatedResponse<PersonDocumentResponse>>>> GetPagedProjection(
        [FromBody] GetPagedRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression?.DeserializeLambdaExpression<PersonDocument>();

        var result = await service.GetPagedProjectionAsync(
            predicate,
            page: request.Page,
            pageSize: request.PageSize,
            cancellationToken: cancellationToken
        );

        if (!result.Items.Any())
            return NotFound(new BaseResponse<PaginatedResponse<PersonDocumentResponse>>(false, Messages.NoneFound));

        return Ok(new BaseResponse<PaginatedResponse<PersonDocumentResponse>>(true, Messages.Found, result));
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<PersonDocumentResponse?>>> Insert([FromBody] PersonDocumentInput input,
        CancellationToken cancellationToken)
    {
        var result = await service.InsertAsync(input, cancellationToken);
        if (!result.Success)
            return BadRequest(new BaseResponse<PersonDocumentResponse?>(false, "Falha ao criar documento"));

        return CreatedAtAction(nameof(GetById), new { id = result.Item?.Id }, result);
    }

    [HttpPost("batch")]
    public async Task<ActionResult<BaseResponse<List<PersonDocumentResponse>>>> InsertBatch(
        [FromBody] List<PersonDocumentInput> inputs,
        CancellationToken cancellationToken)
    {
        var result = await service.InsertAsync(inputs, cancellationToken);
        if (!result.Success)
            return BadRequest(new BaseResponse<List<PersonDocumentResponse>>(false, "Falha ao criar documentos"));

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<BaseResponse<PersonDocumentResponse?>>> Update(Guid id,
        [FromBody] PersonDocumentInput input,
        CancellationToken cancellationToken)
    {
        if (id != input.Id)
            return BadRequest(new BaseResponse<PersonDocumentResponse?>(false, "ID inválido"));

        var result = await service.UpdateAsync(input, cancellationToken);
        if (!result.Success)
            return NotFound(
                new BaseResponse<PersonDocumentResponse?>(false, result.Message ?? "Documento não encontrado"));

        return Ok(result);
    }

    [HttpPut("batch")]
    public async Task<ActionResult<BaseResponse<List<PersonDocumentResponse>>>> UpdateBatch(
        [FromBody] List<PersonDocumentInput> inputs,
        CancellationToken cancellationToken)
    {
        var result = await service.UpdateAsync(inputs, cancellationToken);
        if (!result.Success)
            return NotFound(
                new BaseResponse<List<PersonDocumentResponse>>(false, result.Message ?? "Nenhum documento encontrado"));

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var success = await service.HardDeleteAsync(new PersonDocumentInput { Id = id }, cancellationToken);
        if (!success) return NotFound(new BaseResponse<bool>(false, "Documento não encontrado"));

        return Ok(new BaseResponse<bool>(true, "Documento deletado", true));
    }

    [HttpDelete("batch")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<PersonDocumentInput> inputs,
        CancellationToken cancellationToken)
    {
        var success = await service.HardDeleteAsync(inputs, cancellationToken);
        if (!success) return NotFound(new BaseResponse<bool>(false, "Nenhum documento encontrado para deletar"));

        return Ok(new BaseResponse<bool>(true, "Documentos deletados", true));
    }

    [HttpPost("count")]
    public async Task<ActionResult<BaseResponse<int>>> Count([FromBody] CountRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonDocument>();
        var total = await service.CountAsync(predicate, cancellationToken);

        return Ok(new BaseResponse<int>(true, "Contagem realizada", total));
    }
}