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
    public class AdController(IAdService service) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BaseResponse<AdResponse?>>> GetById(Guid id, string? includeProperties,
            CancellationToken cancellationToken)
        {
            var ad = await service.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
            if (ad == null) return NotFound(new BaseResponse<AdResponse?>(false, Messages.NotFound));

            return Ok(new BaseResponse<AdResponse?>(true, Messages.Found, ad));
        }

        [HttpPost("all")]
        public async Task<ActionResult<BaseResponse<List<AdResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Ad>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<AdResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<AdResponse>>(true, Messages.Found, result));
        }

        [HttpPost("paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<AdResponse>>>> GetPagedProjection(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression?.DeserializeLambdaExpression<Ad>();

            var result = await service.GetPagedProjectionAsync(
                predicate,
                page: request.Page,
                pageSize: request.PageSize,
                cancellationToken: cancellationToken
            );

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<AdResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<AdResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<AdResponse?>>> Insert([FromBody] AdInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (!result.Success)
                return BadRequest(new BaseResponse<AdResponse?>(false, Messages.OperationFailed));

            return CreatedAtAction(nameof(GetById), new { id = result.Item?.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<AdResponse?>>> Update(Guid id, [FromBody] AdInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id)
                return BadRequest(new BaseResponse<AdResponse?>(false, Messages.OperationFailed));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (!result.Success)
                return NotFound(new BaseResponse<AdResponse?>(false, result.Message ?? Messages.NotFound));

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.DeleteAsync(new AdInput { Id = id }, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NotFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpDelete("batch")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<AdInput> inputs,
            CancellationToken cancellationToken)
        {
            var success = await service.DeleteAsync(inputs, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NoneFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpPost("count")]
        public async Task<ActionResult<BaseResponse<int>>> Count(
            [FromBody] CountRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Ad>();
            var total = await service.CountAsync(predicate, cancellationToken);

            return Ok(new BaseResponse<int>(true, Messages.Created, total));
        }
    }
}