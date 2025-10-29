using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateController(IStateService service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<StateResponse?>>> GetAsync(
            [FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<State>();
            var includes = request.IncludeProperties;

            if (predicate == null)
                return NotFound(new BaseResponse<StateResponse>(false, Messages.NotFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<StateResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<StateResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<State>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<StateResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<StateResponse>>(true, Messages.Found, result));
        }

        [HttpPost("get-paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<StateResponse>>>> GetPaged(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression?.DeserializeLambdaExpression<State>();

            var result = await service.GetPagedAsync(
                predicate,
                page: request.Page,
                pageSize: request.PageSize,
                cancellationToken: cancellationToken
            );

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<StateResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<StateResponse>>(true, Messages.Found, result));
        }
    }
}