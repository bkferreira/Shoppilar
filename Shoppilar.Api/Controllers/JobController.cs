using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.Interfaces.App.Service;


namespace Shoppilar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobController(IJobService jobService) : ControllerBase
    {
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BaseResponse<JobResponse?>>> GetById(Guid id, string? includeProperties,
            CancellationToken cancellationToken)
        {
            var job = await jobService.GetAsync(x => x.Id == id, includeProperties, cancellationToken);
            if (job == null) return NotFound(new BaseResponse<JobResponse?>(false, Messages.NotFound));

            return Ok(new BaseResponse<JobResponse?>(true, Messages.Found, job));
        }

        [HttpPost("all")]
        public async Task<ActionResult<BaseResponse<List<JobResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Job>();
            var includes = request.IncludeProperties;
            var result = await jobService.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<JobResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<JobResponse>>(true, Messages.Found, result));
        }

        [HttpPost("paged")]
        public async Task<ActionResult<BaseResponse<PaginatedResponse<JobResponse>>>> GetPaged(
            [FromBody] GetPagedRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Job>();
            var includes = request.IncludeProperties;
            var result = await jobService.GetPagedAsync(
                predicate,
                includes,
                request.Page,
                request.PageSize,
                cancellationToken
            );

            if (!result.Items.Any())
                return NotFound(new BaseResponse<PaginatedResponse<JobResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<PaginatedResponse<JobResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<JobResponse?>>> Insert([FromBody] JobInput input,
            CancellationToken cancellationToken)
        {
            var result = await jobService.InsertAsync(input, cancellationToken);
            if (!result.Success)
                return BadRequest(new BaseResponse<JobResponse?>(false, Messages.OperationFailed));

            return CreatedAtAction(nameof(GetById), new { id = result.Item?.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<JobResponse?>>> Update(Guid id, [FromBody] JobInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id)
                return BadRequest(new BaseResponse<JobResponse?>(false, Messages.OperationFailed));

            var result = await jobService.UpdateAsync(input, cancellationToken);
            if (!result.Success)
                return NotFound(new BaseResponse<JobResponse?>(false, result.Message ?? Messages.NotFound));

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await jobService.HardDeleteAsync(new JobInput { Id = id }, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NotFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpDelete("batch")]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteBatch([FromBody] List<JobInput> inputs,
            CancellationToken cancellationToken)
        {
            var success = await jobService.HardDeleteAsync(inputs, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NoneFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }

        [HttpPost("count")]
        public async Task<ActionResult<BaseResponse<int>>> Count(
            [FromBody] CountRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<Job>();
            var total = await jobService.CountAsync(predicate, cancellationToken);

            return Ok(new BaseResponse<int>(true, Messages.Created, total));
        }
    }
}