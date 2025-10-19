using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces.App;


namespace Shoppilar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StateController(IStateService service) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BaseResponse<StateResponse?>>> GetById(Guid id, string? includeProperties,
            CancellationToken cancellationToken)
        {
            var state = await service.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
            if (state == null) return NotFound(new BaseResponse<StateResponse?>(false, Messages.NotFound));

            return Ok(new BaseResponse<StateResponse?>(true, Messages.Found, state));
        }

        [HttpPost("all")]
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

        [HttpPost("paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<StateResponse>>>> GetPagedProjection(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression?.DeserializeLambdaExpression<State>();

            var result = await service.GetPagedProjectionAsync(
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