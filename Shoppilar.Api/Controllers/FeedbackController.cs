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
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<FeedbackResponse?>>> GetAsync([FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Feedback>();
            var includes = request.IncludeProperties;

            if (predicate == null) return NotFound(new BaseResponse<FeedbackResponse>(false, Messages.NotFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<FeedbackResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
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

        [HttpPost("get-paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<FeedbackResponse>>>> GetPaged(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression?.DeserializeLambdaExpression<Feedback>();

            var result = await service.GetPagedAsync(
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
            if (result == null)
                return BadRequest(new BaseResponse<FeedbackResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<FeedbackResponse?>(true, Messages.Found, result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<FeedbackResponse?>>> Update(Guid id, [FromBody] FeedbackInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id)
                return NotFound(new BaseResponse<FeedbackResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<FeedbackResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<FeedbackResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new FeedbackInput { Id = id }, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpPost("count")]
        public async Task<ActionResult<BaseResponse<int>>> Count(
            [FromBody] CountRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Feedback>();
            var total = await service.CountAsync(predicate, cancellationToken);

            return Ok(new BaseResponse<int>(true, Messages.Counted, total));
        }
    }
}