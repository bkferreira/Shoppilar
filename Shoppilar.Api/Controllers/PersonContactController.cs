using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces.App;


namespace Shoppilar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonContactController(IPersonContactService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BaseResponse<PersonContactResponse?>>> GetById(Guid id, string? includeProperties,
        CancellationToken cancellationToken)
    {
        var contact = await service.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
        if (contact == null) return NotFound(new BaseResponse<PersonContactResponse?>(false, "Contato não encontrado"));

        return Ok(new BaseResponse<PersonContactResponse?>(true, "Contato encontrado", contact));
    }

    [HttpPost("all")]
    public async Task<ActionResult<BaseResponse<List<PersonContactResponse>>>> GetAll([FromBody] GetAllRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonContact>();
        var includes = request.IncludeProperties;
        var result = await service.GetAllAsync(predicate, includes, cancellationToken);

        if (!result.Any())
            return NotFound(new BaseResponse<List<PersonContactResponse>>(false, "Nenhum contato encontrado"));

        return Ok(new BaseResponse<List<PersonContactResponse>>(true, "Contatos encontrados", result));
    }

    [HttpPost("paged")]
    public async Task<ActionResult<BaseResponse<PaginatedResponse<PersonContactResponse>>>> GetPagedProjection(
        [FromBody] GetPagedRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression?.DeserializeLambdaExpression<PersonContact>();

        var result = await service.GetPagedProjectionAsync(
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
        if (!result.Success)
            return BadRequest(new BaseResponse<PersonContactResponse?>(false, "Falha ao criar contato"));

        return CreatedAtAction(nameof(GetById), new { id = result.Item?.Id }, result);
    }

    [HttpPost("batch")]
    public async Task<ActionResult<BaseResponse<List<PersonContactResponse>>>> InsertBatch(
        [FromBody] List<PersonContactInput> inputs,
        CancellationToken cancellationToken)
    {
        var result = await service.InsertAsync(inputs, cancellationToken);
        if (!result.Success)
            return BadRequest(new BaseResponse<List<PersonContactResponse>>(false, "Falha ao criar contatos"));

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<BaseResponse<PersonContactResponse?>>> Update(Guid id,
        [FromBody] PersonContactInput input,
        CancellationToken cancellationToken)
    {
        if (id != input.Id)
            return BadRequest(new BaseResponse<PersonContactResponse?>(false, "ID inválido"));

        var result = await service.UpdateAsync(input, cancellationToken);
        if (!result.Success)
            return NotFound(
                new BaseResponse<PersonContactResponse?>(false, result.Message ?? "Contato não encontrado"));

        return Ok(result);
    }

    [HttpPut("batch")]
    public async Task<ActionResult<BaseResponse<List<PersonContactResponse>>>> UpdateBatch(
        [FromBody] List<PersonContactInput> inputs,
        CancellationToken cancellationToken)
    {
        var result = await service.UpdateAsync(inputs, cancellationToken);
        if (!result.Success)
            return NotFound(
                new BaseResponse<List<PersonContactResponse>>(false, result.Message ?? "Nenhum contato encontrado"));

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var success = await service.HardDeleteAsync(new PersonContactInput { Id = id }, cancellationToken);
        if (!success) return NotFound(new BaseResponse<bool>(false, "Contato não encontrado"));

        return Ok(new BaseResponse<bool>(true, "Contato deletado", true));
    }

    [HttpDelete("batch")]
    public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<PersonContactInput> inputs,
        CancellationToken cancellationToken)
    {
        var success = await service.HardDeleteAsync(inputs, cancellationToken);
        if (!success) return NotFound(new BaseResponse<bool>(false, "Nenhum contato encontrado para deletar"));

        return Ok(new BaseResponse<bool>(true, "Contatos deletados", true));
    }

    [HttpPost("count")]
    public async Task<ActionResult<BaseResponse<int>>> Count([FromBody] CountRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonContact>();
        var total = await service.CountAsync(predicate, cancellationToken);

        return Ok(new BaseResponse<int>(true, "Contagem realizada", total));
    }
}