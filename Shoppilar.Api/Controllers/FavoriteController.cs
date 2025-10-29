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
    public class FavoriteController(IFavoriteService service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<FavoriteResponse?>>> GetAsync([FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Favorite>();
            var includes = request.IncludeProperties;

            if (predicate == null) return NotFound(new BaseResponse<FavoriteResponse>(false, Messages.NotFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<FavoriteResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<FavoriteResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Favorite>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<FavoriteResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<FavoriteResponse>>(true, Messages.Found, result));
        }

        [HttpPost("get-paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<FavoriteResponse>>>> GetPaged(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression?.DeserializeLambdaExpression<Favorite>();

            var result = await service.GetPagedAsync(
                predicate,
                page: request.Page,
                pageSize: request.PageSize,
                cancellationToken: cancellationToken
            );

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<FavoriteResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<FavoriteResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<FavoriteResponse?>>> Insert([FromBody] FavoriteInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<FavoriteResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<FavoriteResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new FavoriteInput { Id = id }, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpDelete("delete-batch")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<FavoriteInput> inputs,
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
            var predicate = request.Expression.DeserializeLambdaExpression<Favorite>();
            var total = await service.CountAsync(predicate, cancellationToken);

            return Ok(new BaseResponse<int>(true, Messages.Counted, total));
        }
    }
}