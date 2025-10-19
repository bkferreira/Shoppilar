using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces.App;


namespace Shoppilar.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController(IPersonService PersonService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PersonResponse?>> GetAsync(Guid id, string? includeProperties,
        CancellationToken cancellationToken)
    {
        var result = await PersonService.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
        if (result == null) return NotFound("Usuário não encontrado");
        return Ok(result);
    }

    [HttpPost("GetAll")]
    public async Task<ActionResult<List<PersonResponse>>> GetAll([FromBody] GetAllRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<Person>();
        var includes = request.IncludeProperties;
        var result = await PersonService.GetAllAsync(predicate, includes, cancellationToken);
        return Ok(result);
    }

    [HttpPost("GetPaged")]
    public async Task<ActionResult<PaginatedResponse<PersonResponse>>> GetPaged([FromBody] GetPagedRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<Person>();
        var includes = request.IncludeProperties;
        var result =
            await PersonService.GetPagedAsync(predicate, includes, request.Page, request.PageSize, cancellationToken);
        return Ok(result);
    }

    // [HttpPost]
    // public async Task<ActionResult<PersonResponse?>> Insert([FromBody] PersonInput input,
    //     CancellationToken cancellationToken)
    // {
    //     var result = await PersonService.InsertAsync(input, cancellationToken);
    //     return Ok(result);
    // }

    [HttpPut]
    public async Task<ActionResult<PersonResponse?>> Update([FromBody] PersonInput input,
        CancellationToken cancellationToken)
    {
        var result = await PersonService.UpdateAsync(input, cancellationToken);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<bool>> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await PersonService.DeleteAsync(new PersonInput { Id = id }, cancellationToken);
        return Ok(result);
    }

    [HttpPost("Count")]
    public async Task<ActionResult<int>> Count([FromBody] GetAllRequest request,
        CancellationToken cancellationToken)
    {
        var predicate = request.Expression.DeserializeLambdaExpression<Person>();
        var result = await PersonService.CountAsync(predicate, cancellationToken);
        return Ok(result);
    }
}