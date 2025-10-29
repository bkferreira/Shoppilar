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
    public class PersonAddressController(IPersonAddressService service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<PersonAddressResponse?>>> GetAsync([FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<PersonAddress>();
            var includes = request.IncludeProperties;

            if (predicate == null) return NotFound(new BaseResponse<PersonAddressResponse>(false, Messages.NotFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<PersonAddressResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<PersonAddressResponse>>>> GetAll(
            [FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<PersonAddress>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<PersonAddressResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<PersonAddressResponse>>(true, Messages.Found, result));
        }

        [HttpPost("get-paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<PersonAddressResponse>>>> GetPaged(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression?.DeserializeLambdaExpression<PersonAddress>();

            var result = await service.GetPagedAsync(
                predicate,
                page: request.Page,
                pageSize: request.PageSize,
                cancellationToken: cancellationToken
            );

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<PersonAddressResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<PersonAddressResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<PersonAddressResponse?>>> Insert(
            [FromBody] PersonAddressInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<PersonAddressResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<PersonAddressResponse?>(true, Messages.Found, result));
        }

        [HttpPost("insert-batch")]
        public async Task<ActionResult<BaseResponse<List<PersonAddressResponse>>>> InsertBatch(
            [FromBody] List<PersonAddressInput> inputs,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(inputs, cancellationToken);
            if (!result.Any())
                return BadRequest(new BaseResponse<List<PersonAddressResponse>>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<List<PersonAddressResponse?>>(true, Messages.Found, result!));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<PersonAddressResponse?>>> Update(Guid id,
            [FromBody] PersonAddressInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id)
                return NotFound(new BaseResponse<PersonAddressResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<PersonAddressResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<PersonAddressResponse?>(true, Messages.Found, result));
        }

        [HttpPut("update-batch")]
        public async Task<ActionResult<BaseResponse<List<PersonAddressResponse>>>> UpdateBatch(
            [FromBody] List<PersonAddressInput> inputs,
            CancellationToken cancellationToken)
        {
            var result = await service.UpdateAsync(inputs, cancellationToken);
            if (!result.Any())
                return NotFound(
                    new BaseResponse<List<PersonAddressResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<PersonAddressResponse?>>(true, Messages.Found, result!));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new PersonAddressInput { Id = id }, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpDelete("delete-batch")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<PersonAddressInput> inputs,
            CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(inputs, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpPost("count")]
        public async Task<ActionResult<BaseResponse<int>>> Count([FromBody] CountRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<PersonAddress>();
            var total = await service.CountAsync(predicate, cancellationToken);

            return Ok(new BaseResponse<int>(true, Messages.Counted, total));
        }
    }
}