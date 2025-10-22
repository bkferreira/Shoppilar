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
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BaseResponse<CityResponse?>>> GetById(Guid id, string? includeProperties,
            CancellationToken cancellationToken)
        {
            var city = await service.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
            if (city == null)
                return NotFound(new BaseResponse<CityResponse?>(false, Messages.NotFound));

            return Ok(new BaseResponse<CityResponse?>(true, Messages.Found, city));
        }

        [HttpPost("paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<CityResponse>>>> GetPagedProjection(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression?.DeserializeLambdaExpression<City>();

            var result = await service.GetPagedProjectionAsync(
                predicate,
                page: request.Page,
                pageSize: request.PageSize,
                cancellationToken: cancellationToken
            );

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<CityResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<CityResponse>>(true, Messages.Found, result));
        }

        [HttpPost("all")]
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