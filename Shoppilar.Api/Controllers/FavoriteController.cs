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
    public class FavoriteController(IFavoriteService favoriteService) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BaseResponse<FavoriteResponse?>>> GetById(Guid id, string? includeProperties,
            CancellationToken cancellationToken)
        {
            var favorite = await favoriteService.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
            if (favorite == null) return NotFound(new BaseResponse<FavoriteResponse?>(false, Messages.NotFound));

            return Ok(new BaseResponse<FavoriteResponse?>(true, Messages.Found, favorite));
        }

        [HttpPost("all")]
        public async Task<ActionResult<BaseResponse<List<FavoriteResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Favorite>();
            var includes = request.IncludeProperties;
            var result = await favoriteService.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<FavoriteResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<FavoriteResponse>>(true, Messages.Found, result));
        }

        [HttpPost("paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<FavoriteResponse>>>> GetPaged(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Favorite>();
            var includes = request.IncludeProperties;
            var result = await favoriteService.GetPagedAsync(
                predicate,
                includes,
                request.Page,
                request.PageSize,
                cancellationToken
            );

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<FavoriteResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<FavoriteResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<FavoriteResponse?>>> Insert([FromBody] FavoriteInput input,
            CancellationToken cancellationToken)
        {
            var result = await favoriteService.InsertAsync(input, cancellationToken);
            if (!result.Success)
                return BadRequest(new BaseResponse<FavoriteResponse?>(false, Messages.OperationFailed));

            return CreatedAtAction(nameof(GetById), new { id = result.Item?.Id }, result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await favoriteService.HardDeleteAsync(new FavoriteInput { Id = id }, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NotFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpDelete("batch")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<FavoriteInput> inputs,
            CancellationToken cancellationToken)
        {
            var success = await favoriteService.HardDeleteAsync(inputs, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NoneFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpPost("count")]
        public async Task<ActionResult<BaseResponse<int>>> Count(
            [FromBody] CountRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Favorite>();
            var total = await favoriteService.CountAsync(predicate, cancellationToken);

            return Ok(new BaseResponse<int>(true, Messages.Created, total));
        }
    }
}