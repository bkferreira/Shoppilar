using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController(ICityService service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<CityResponse?>>> GetAsync([FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<City>();
            var includes = request.IncludeProperties;

            if (predicate == null) return NotFound(new BaseResponse<CityResponse>(false, Messages.NotFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<CityResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<CityResponse>>>> GetPaged(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression?.DeserializeLambdaExpression<City>();

            var result = await service.GetPagedAsync(
                predicate,
                page: request.Page,
                pageSize: request.PageSize,
                cancellationToken: cancellationToken
            );

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<CityResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<CityResponse>>(true, Messages.Found, result));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<CityResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<City>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<CityResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<CityResponse>>(true, Messages.Found, result));
        }
    }
}