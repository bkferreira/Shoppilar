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
    public class AdPromotionController(IAdPromotionService adPromotionService) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BaseResponse<AdPromotionResponse?>>> GetById(Guid id, string? includeProperties,
            CancellationToken cancellationToken)
        {
            var promotion = await adPromotionService.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
            if (promotion == null)
                return NotFound(new BaseResponse<AdPromotionResponse?>(false, Messages.NotFound));

            return Ok(new BaseResponse<AdPromotionResponse?>(true, Messages.Found, promotion));
        }

        [HttpPost("all")]
        public async Task<ActionResult<BaseResponse<List<AdPromotionResponse>>>> GetAll(
            [FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<AdPromotion>();
            var includes = request.IncludeProperties;
            var result = await adPromotionService.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<AdPromotionResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<AdPromotionResponse>>(true, Messages.Found, result));
        }

        [HttpPost("paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<AdPromotionResponse>>>> GetPaged(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<AdPromotion>();
            var includes = request.IncludeProperties;
            var result =
                await adPromotionService.GetPagedAsync(predicate, includes, request.Page, request.PageSize,
                    cancellationToken);

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<AdPromotionResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<AdPromotionResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<AdPromotionResponse?>>> Insert([FromBody] AdPromotionInput input,
            CancellationToken cancellationToken)
        {
            var result = await adPromotionService.InsertAsync(input, cancellationToken);
            if (!result.Success)
                return BadRequest(new BaseResponse<AdPromotionResponse?>(false, Messages.OperationFailed));

            return CreatedAtAction(nameof(GetById), new { id = result.Item?.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<AdPromotionResponse?>>> Update(Guid id,
            [FromBody] AdPromotionInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id)
                return BadRequest(new BaseResponse<AdPromotionResponse?>(false, Messages.OperationFailed));

            var result = await adPromotionService.UpdateAsync(input, cancellationToken);
            if (!result.Success)
                return NotFound(new BaseResponse<AdPromotionResponse?>(false, result.Message ?? Messages.NotFound));

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await adPromotionService.HardDeleteAsync(new AdPromotionInput { Id = id }, cancellationToken);
            if (!success)
                return NotFound(new BaseResponse<bool>(false, Messages.NotFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpDelete("batch")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<AdPromotionInput> inputs,
            CancellationToken cancellationToken)
        {
            var success = await adPromotionService.HardDeleteAsync(inputs, cancellationToken);
            if (!success)
                return NotFound(new BaseResponse<bool>(false, Messages.NoneFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpPost("count")]
        public async Task<ActionResult<BaseResponse<int>>> Count([FromBody] CountRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<AdPromotion>();
            var total = await adPromotionService.CountAsync(predicate, cancellationToken);

            return Ok(new BaseResponse<int>(true, Messages.Found, total));
        }
    }
}