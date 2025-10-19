using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces.App;


namespace Shoppilar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonSocialMediaController(IPersonSocialMediaService PersonSocialMediaService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PersonSocialMediaResponse?>> GetAsync(Guid id, string? includeProperties,
        CancellationToken cancellationToken)
    {
        var result = await PersonSocialMediaService.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
        if (result == null) return NotFound("Rede social não encontrada");
        return Ok(result);
    }

    [HttpPost("GetAll")]
    public async Task<ActionResult<List<PersonSocialMediaResponse>>> GetAll([FromBody] GetAllRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonSocialMedia>();
        var includes = request.IncludeProperties;
        var result = await PersonSocialMediaService.GetAllAsync(predicate, includes, cancellationToken);
        return Ok(result);
    }

    [HttpPost("GetPaged")]
    public async Task<ActionResult<PaginatedResponse<PersonSocialMediaResponse>>> GetPaged(
        [FromBody] GetPagedRequest request, CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonSocialMedia>();
        var includes = request.IncludeProperties;
        var result =
            await PersonSocialMediaService.GetPagedAsync(predicate, includes, request.Page, request.PageSize,
                cancellationToken);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PersonSocialMediaResponse?>> Insert([FromBody] PersonSocialMediaInput input,
        CancellationToken cancellationToken)
    {
        var result = await PersonSocialMediaService.InsertAsync(input, cancellationToken);
        return Ok(result);
    }

    [HttpPost("BatchInsert")]
    public async Task<ActionResult<List<PersonSocialMediaResponse>>> InsertBatch(
        [FromBody] List<PersonSocialMediaInput> inputs,
        CancellationToken cancellationToken)
    {
        var result = await PersonSocialMediaService.InsertAsync(inputs, cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<PersonSocialMediaResponse?>> Update([FromBody] PersonSocialMediaInput input,
        CancellationToken cancellationToken)
    {
        var result = await PersonSocialMediaService.UpdateAsync(input, cancellationToken);
        return Ok(result);
    }

    [HttpPut("BatchUpdate")]
    public async Task<ActionResult<List<PersonSocialMediaResponse>>> UpdateBatch(
        [FromBody] List<PersonSocialMediaInput> inputs,
        CancellationToken cancellationToken)
    {
        var result = await PersonSocialMediaService.UpdateAsync(inputs, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<bool>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result =
            await PersonSocialMediaService.HardDeleteAsync(new PersonSocialMediaInput { Id = id }, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("BatchDelete")]
    public async Task<ActionResult<bool>> DeleteBatch([FromBody] List<PersonSocialMediaInput> inputs,
        CancellationToken cancellationToken)
    {
        var result = await PersonSocialMediaService.HardDeleteAsync(inputs, cancellationToken);
        return Ok(result);
    }

    [HttpPost("Count")]
    public async Task<ActionResult<int>> Count([FromBody] GetAllRequest request, CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<PersonSocialMedia>();
        var result = await PersonSocialMediaService.CountAsync(predicate, cancellationToken);
        return Ok(result);
    }
}