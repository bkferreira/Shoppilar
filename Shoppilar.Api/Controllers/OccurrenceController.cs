using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces.App;


namespace Shoppilar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OccurrenceController(IOccurrenceService service) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BaseResponse<OccurrenceResponse?>>> GetById(Guid id, string? includeProperties,
            CancellationToken cancellationToken)
        {
            var occurrence = await service.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
            if (occurrence == null) return NotFound(new BaseResponse<OccurrenceResponse?>(false, Messages.NotFound));

            return Ok(new BaseResponse<OccurrenceResponse?>(true, Messages.Found, occurrence));
        }

        [HttpPost("all")]
        public async Task<ActionResult<BaseResponse<List<OccurrenceResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Occurrence>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<OccurrenceResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<OccurrenceResponse>>(true, Messages.Found, result));
        }

        [HttpPost("paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<OccurrenceResponse>>>> GetPagedProjection(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression?.DeserializeLambdaExpression<Occurrence>();

            var result = await service.GetPagedProjectionAsync(
                predicate,
                page: request.Page,
                pageSize: request.PageSize,
                cancellationToken: cancellationToken
            );

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<OccurrenceResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<OccurrenceResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<OccurrenceResponse?>>> Insert([FromBody] OccurrenceInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (!result.Success)
                return BadRequest(new BaseResponse<OccurrenceResponse?>(false, Messages.OperationFailed));

            return CreatedAtAction(nameof(GetById), new { id = result.Item?.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<OccurrenceResponse?>>> Update(Guid id,
            [FromBody] OccurrenceInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id)
                return BadRequest(new BaseResponse<OccurrenceResponse?>(false, Messages.OperationFailed));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (!result.Success)
                return NotFound(new BaseResponse<OccurrenceResponse?>(false, result.Message ?? Messages.NotFound));

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new OccurrenceInput { Id = id }, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NotFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpDelete("batch")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<OccurrenceInput> inputs,
            CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(inputs, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NoneFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpPost("count")]
        public async Task<ActionResult<BaseResponse<int>>> Count(
            [FromBody] CountRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Occurrence>();
            var total = await service.CountAsync(predicate, cancellationToken);

            return Ok(new BaseResponse<int>(true, Messages.Created, total));
        }
    }
}