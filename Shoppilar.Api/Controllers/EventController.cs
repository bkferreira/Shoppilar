using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController(IEventService service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<EventResponse?>>> GetAsync([FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Event>();
            var includes = request.IncludeProperties;

            if (predicate == null) return NotFound(new BaseResponse<EventResponse>(false, Messages.NotFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<EventResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<EventResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Event>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<EventResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<EventResponse>>(true, Messages.Found, result));
        }

        [HttpPost("get-paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<EventResponse>>>> GetPaged(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression?.DeserializeLambdaExpression<Event>();

            var result = await service.GetPagedAsync(
                predicate,
                page: request.Page,
                pageSize: request.PageSize,
                cancellationToken: cancellationToken
            );

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<EventResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<EventResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<EventResponse?>>> Insert([FromBody] EventInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<EventResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<EventResponse?>(true, Messages.Found, result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<EventResponse?>>> Update(Guid id, [FromBody] EventInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id)
                return NotFound(new BaseResponse<EventResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<EventResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<EventResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new EventInput { Id = id }, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpDelete("delete-batch")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<EventInput> inputs,
            CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(inputs, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpPost("count")]
        public async Task<ActionResult<BaseResponse<int>>> Count(
            [FromBody] CountRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Event>();
            var total = await service.CountAsync(predicate, cancellationToken);

            return Ok(new BaseResponse<int>(true, Messages.Counted, total));
        }
    }
}