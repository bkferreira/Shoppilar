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
    public class EventController(IEventService eventService) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BaseResponse<EventResponse?>>> GetById(Guid id, string? includeProperties,
            CancellationToken cancellationToken)
        {
            var ev = await eventService.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
            if (ev == null) return NotFound(new BaseResponse<EventResponse?>(false, Messages.NotFound));

            return Ok(new BaseResponse<EventResponse?>(true, Messages.Found, ev));
        }

        [HttpPost("all")]
        public async Task<ActionResult<BaseResponse<List<EventResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Event>();
            var includes = request.IncludeProperties;
            var result = await eventService.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<EventResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<EventResponse>>(true, Messages.Found, result));
        }

        [HttpPost("paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<EventResponse>>>> GetPaged(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Event>();
            var includes = request.IncludeProperties;
            var result = await eventService.GetPagedAsync(
                predicate,
                includes,
                request.Page,
                request.PageSize,
                cancellationToken
            );

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<EventResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<EventResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<EventResponse?>>> Insert([FromBody] EventInput input,
            CancellationToken cancellationToken)
        {
            var result = await eventService.InsertAsync(input, cancellationToken);
            if (!result.Success)
                return BadRequest(new BaseResponse<EventResponse?>(false, Messages.OperationFailed));

            return CreatedAtAction(nameof(GetById), new { id = result.Item?.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<EventResponse?>>> Update(Guid id, [FromBody] EventInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id)
                return BadRequest(new BaseResponse<EventResponse?>(false, Messages.OperationFailed));

            var result = await eventService.UpdateAsync(input, cancellationToken);
            if (!result.Success)
                return NotFound(new BaseResponse<EventResponse?>(false, result.Message ?? Messages.NotFound));

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await eventService.HardDeleteAsync(new EventInput { Id = id }, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NotFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpDelete("batch")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<EventInput> inputs,
            CancellationToken cancellationToken)
        {
            var success = await eventService.HardDeleteAsync(inputs, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NoneFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpPost("count")]
        public async Task<ActionResult<BaseResponse<int>>> Count(
            [FromBody] CountRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Event>();
            var total = await eventService.CountAsync(predicate, cancellationToken);

            return Ok(new BaseResponse<int>(true, Messages.Created, total));
        }
    }
}