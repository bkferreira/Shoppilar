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
    public class ImageController(IImageService imageService) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BaseResponse<ImageResponse?>>> GetById(Guid id, string? includeProperties,
            CancellationToken cancellationToken)
        {
            var image = await imageService.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
            if (image == null) return NotFound(new BaseResponse<ImageResponse?>(false, Messages.NotFound));

            return Ok(new BaseResponse<ImageResponse?>(true, Messages.Found, image));
        }

        [HttpPost("all")]
        public async Task<ActionResult<BaseResponse<List<ImageResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Image>();
            var includes = request.IncludeProperties;
            var result = await imageService.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<ImageResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<ImageResponse>>(true, Messages.Found, result));
        }

        [HttpPost("paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<ImageResponse>>>> GetPaged(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Image>();
            var includes = request.IncludeProperties;
            var result = await imageService.GetPagedAsync(
                predicate,
                includes,
                request.Page,
                request.PageSize,
                cancellationToken
            );

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<ImageResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<ImageResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<ImageResponse?>>> Insert([FromBody] ImageInput input,
            CancellationToken cancellationToken)
        {
            var result = await imageService.InsertAsync(input, cancellationToken);
            if (!result.Success)
                return BadRequest(new BaseResponse<ImageResponse?>(false, Messages.OperationFailed));

            return CreatedAtAction(nameof(GetById), new { id = result.Item?.Id }, result);
        }

        [HttpPost("batch")]
        public async Task<ActionResult<BaseResponse<List<ImageResponse>?>>> CreateBatch(
            [FromBody] List<ImageInput> inputs,
            CancellationToken cancellationToken)
        {
            var result = await imageService.InsertAsync(inputs, cancellationToken);
            if (!result.Success)
                return BadRequest(new BaseResponse<List<ImageResponse>?>(false, Messages.OperationFailed));

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse<ImageResponse?>>> Update([FromBody] ImageInput input,
            CancellationToken cancellationToken)
        {
            var result = await imageService.UpdateAsync(input, cancellationToken);
            if (!result.Success)
                return NotFound(new BaseResponse<ImageResponse?>(false, result.Message ?? Messages.NotFound));

            return Ok(result);
        }

        [HttpPut("batch")]
        public async Task<ActionResult<BaseResponse<List<ImageResponse>>>> UpdateBatch(
            [FromBody] List<ImageInput> inputs,
            CancellationToken cancellationToken)
        {
            var result = await imageService.UpdateAsync(inputs, cancellationToken);
            if (!result.Success)
                return NotFound(new BaseResponse<List<ImageResponse>>(false, result.Message ?? Messages.NotFound));

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await imageService.HardDeleteAsync(new ImageInput { Id = id }, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NotFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpDelete("batch")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<ImageInput> inputs,
            CancellationToken cancellationToken)
        {
            var success = await imageService.HardDeleteAsync(inputs, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NoneFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpPost("count")]
        public async Task<ActionResult<BaseResponse<int>>> Count(
            [FromBody] CountRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Image>();
            var total = await imageService.CountAsync(predicate, cancellationToken);

            return Ok(new BaseResponse<int>(true, Messages.Created, total));
        }
    }
}