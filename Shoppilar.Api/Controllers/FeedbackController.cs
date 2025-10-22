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
    public class FeedbackController(IFeedbackService service) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BaseResponse<FeedbackResponse?>>> GetById(Guid id, string? includeProperties,
            CancellationToken cancellationToken)
        {
            var feedback = await service.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
            if (feedback == null) return NotFound(new BaseResponse<FeedbackResponse?>(false, Messages.NotFound));

            return Ok(new BaseResponse<FeedbackResponse?>(true, Messages.Found, feedback));
        }

        [HttpPost("all")]
        public async Task<ActionResult<BaseResponse<List<FeedbackResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Feedback>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<FeedbackResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<FeedbackResponse>>(true, Messages.Found, result));
        }

        [HttpPost("paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<FeedbackResponse>>>> GetPagedProjection(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression?.DeserializeLambdaExpression<Feedback>();

            var result = await service.GetPagedProjectionAsync(
                predicate,
                page: request.Page,
                pageSize: request.PageSize,
                cancellationToken: cancellationToken
            );

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<FeedbackResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<FeedbackResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<FeedbackResponse?>>> Insert([FromBody] FeedbackInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (!result.Success)
                return BadRequest(new BaseResponse<FeedbackResponse?>(false, Messages.OperationFailed));

            return CreatedAtAction(nameof(GetById), new { id = result.Item?.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<FeedbackResponse?>>> Update(Guid id, [FromBody] FeedbackInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id)
                return BadRequest(new BaseResponse<FeedbackResponse?>(false, Messages.OperationFailed));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (!result.Success)
                return NotFound(new BaseResponse<FeedbackResponse?>(false, result.Message ?? Messages.NotFound));

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new FeedbackInput { Id = id }, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NotFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpPost("count")]
        public async Task<ActionResult<BaseResponse<int>>> Count(
            [FromBody] CountRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Feedback>();
            var total = await service.CountAsync(predicate, cancellationToken);

            return Ok(new BaseResponse<int>(true, Messages.Created, total));
        }
    }
}