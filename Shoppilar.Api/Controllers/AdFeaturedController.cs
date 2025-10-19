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
    public class AdFeaturedController(IAdFeaturedService adFeaturedService) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BaseResponse<AdFeaturedResponse?>>> GetById(Guid id,
            string? includeProperties,
            CancellationToken cancellationToken)
        {
            var adFeatured = await adFeaturedService.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
            if (adFeatured == null)
                return NotFound(new BaseResponse<AdFeaturedResponse?>(false, Messages.NotFound));

            return Ok(new BaseResponse<AdFeaturedResponse?>(true, Messages.Found, adFeatured));
        }

        [HttpPost("all")]
        public async Task<ActionResult<BaseResponse<List<AdFeaturedResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<AdFeatured>();
            var includes = request.IncludeProperties;
            var result = await adFeaturedService.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<AdFeaturedResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<AdFeaturedResponse>>(true, Messages.Found, result));
        }

        [HttpPost("paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<AdFeaturedResponse>>>> GetPaged(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<AdFeatured>();
            var includes = request.IncludeProperties;
            var result =
                await adFeaturedService.GetPagedAsync(predicate, includes, request.Page, request.PageSize,
                    cancellationToken);

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<AdFeaturedResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<AdFeaturedResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<AdFeaturedResponse?>>> Insert([FromBody] AdFeaturedInput input,
            CancellationToken cancellationToken)
        {
            var result = await adFeaturedService.InsertAsync(input, cancellationToken);
            if (!result.Success)
                return BadRequest(new BaseResponse<AdFeaturedResponse?>(false, Messages.OperationFailed));

            return CreatedAtAction(nameof(GetById), new { id = result.Item?.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<AdFeaturedResponse?>>> Update(Guid id,
            [FromBody] AdFeaturedInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id)
                return BadRequest(new BaseResponse<AdFeaturedResponse?>(false, Messages.OperationFailed));

            var result = await adFeaturedService.UpdateAsync(input, cancellationToken);
            if (!result.Success)
                return NotFound(new BaseResponse<AdFeaturedResponse?>(false, result.Message ?? Messages.NotFound));

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await adFeaturedService.HardDeleteAsync(new AdFeaturedInput { Id = id }, cancellationToken);
            if (!success)
                return NotFound(new BaseResponse<bool>(false, Messages.NotFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpDelete("batch")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<AdFeaturedInput> inputs,
            CancellationToken cancellationToken)
        {
            var success = await adFeaturedService.HardDeleteAsync(inputs, cancellationToken);
            if (!success)
                return NotFound(new BaseResponse<bool>(false, Messages.NoneFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpPost("count")]
        public async Task<ActionResult<BaseResponse<int>>> Count([FromBody] CountRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<AdFeatured>();
            var total = await adFeaturedService.CountAsync(predicate, cancellationToken);

            return Ok(new BaseResponse<int>(true, Messages.Found, total));
        }
    }
}