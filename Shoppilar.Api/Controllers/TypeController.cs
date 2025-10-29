using Microsoft.AspNetCore.Mvc;
using Shoppilar.Data.App.Models;
using Shoppilar.DTOs.App.Input;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.App;

namespace Shoppilar.Api.Controllers
{
    #region DocumentTypeController

    [ApiController]
    [Route("[controller]")]
    public class DocumentTypeController(ITypeService<DocumentType> service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> GetAsync(
            [FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<DocumentType>();
            var includes = request.IncludeProperties;

            if (predicate == null)
                return NotFound(new BaseResponse<TypeResponse>(false, Messages.NoneFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<TypeResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<TypeResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<DocumentType>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);

            if (!result.Any())
                return NotFound(new BaseResponse<List<TypeResponse>>(false, Messages.NoneFound));

            return Ok(new BaseResponse<List<TypeResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Insert([FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null) return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Update(Guid id, [FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id) return NotFound(new BaseResponse<TypeResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new TypeInput { Id = id }, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NotFound));

            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }
    }

    #endregion

    #region ContactTypeController

    [ApiController]
    [Route("[controller]")]
    public class ContactTypeController(ITypeService<ContactType> service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> GetAsync(
            [FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<ContactType>();
            var includes = request.IncludeProperties;

            if (predicate == null)
                return NotFound(new BaseResponse<TypeResponse>(false, Messages.NoneFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<TypeResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<TypeResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<ContactType>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);
            if (!result.Any()) return NotFound(new BaseResponse<List<TypeResponse>>(false, Messages.NoneFound));
            return Ok(new BaseResponse<List<TypeResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Insert([FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null) return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Update(Guid id, [FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id) return NotFound(new BaseResponse<TypeResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new TypeInput { Id = id }, cancellationToken);
            if (!success) return NotFound(new BaseResponse<bool>(false, Messages.NotFound));
            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }
    }

    #endregion

    #region OccurrenceTypeController

    [ApiController]
    [Route("[controller]")]
    public class OccurrenceTypeController(ITypeService<OccurrenceType> service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> GetAsync(
            [FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<OccurrenceType>();
            var includes = request.IncludeProperties;

            if (predicate == null)
                return NotFound(new BaseResponse<TypeResponse>(false, Messages.NoneFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<TypeResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<TypeResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<OccurrenceType>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);
            if (!result.Any()) return NotFound(new BaseResponse<List<TypeResponse>>(false, Messages.NoneFound));
            return Ok(new BaseResponse<List<TypeResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Insert([FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null) return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Update(Guid id, [FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id) return NotFound(new BaseResponse<TypeResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new TypeInput { Id = id }, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));
            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }
    }

    #endregion

    #region TargetTypeController

    [ApiController]
    [Route("[controller]")]
    public class TargetTypeController(ITypeService<TargetType> service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> GetAsync(
            [FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<TargetType>();
            var includes = request.IncludeProperties;

            if (predicate == null)
                return NotFound(new BaseResponse<TypeResponse>(false, Messages.NoneFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<TypeResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<TypeResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<TargetType>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);
            if (!result.Any()) return NotFound(new BaseResponse<List<TypeResponse>>(false, Messages.NoneFound));
            return Ok(new BaseResponse<List<TypeResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Insert([FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null) return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Update(Guid id, [FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id) return NotFound(new BaseResponse<TypeResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new TypeInput { Id = id }, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));
            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }
    }

    #endregion

    #region CategoryTypeController

    [ApiController]
    [Route("[controller]")]
    public class CategoryTypeController(ITypeService<CategoryType> service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> GetAsync(
            [FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<CategoryType>();
            var includes = request.IncludeProperties;

            if (predicate == null)
                return NotFound(new BaseResponse<TypeResponse>(false, Messages.NoneFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<TypeResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<TypeResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<CategoryType>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);
            if (!result.Any()) return NotFound(new BaseResponse<List<TypeResponse>>(false, Messages.NoneFound));
            return Ok(new BaseResponse<List<TypeResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Insert([FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null) return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Update(Guid id, [FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id) return NotFound(new BaseResponse<TypeResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new TypeInput { Id = id }, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));
            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }
    }

    #endregion

    #region PersonTypeController

    [ApiController]
    [Route("[controller]")]
    public class PersonTypeController(ITypeService<PersonType> service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> GetAsync(
            [FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<PersonType>();
            var includes = request.IncludeProperties;

            if (predicate == null)
                return NotFound(new BaseResponse<TypeResponse>(false, Messages.NoneFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<TypeResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<TypeResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<PersonType>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);
            if (!result.Any()) return NotFound(new BaseResponse<List<TypeResponse>>(false, Messages.NoneFound));
            return Ok(new BaseResponse<List<TypeResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Insert([FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null) return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Update(Guid id, [FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id) return NotFound(new BaseResponse<TypeResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new TypeInput { Id = id }, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));
            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }
    }

    #endregion

    #region ImageTypeController

    [ApiController]
    [Route("[controller]")]
    public class ImageTypeController(ITypeService<ImageType> service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> GetAsync(
            [FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<ImageType>();
            var includes = request.IncludeProperties;

            if (predicate == null)
                return NotFound(new BaseResponse<TypeResponse>(false, Messages.NoneFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<TypeResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<TypeResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<ImageType>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);
            if (!result.Any()) return NotFound(new BaseResponse<List<TypeResponse>>(false, Messages.NoneFound));
            return Ok(new BaseResponse<List<TypeResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Insert([FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null) return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Update(Guid id, [FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id) return NotFound(new BaseResponse<TypeResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new TypeInput { Id = id }, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));
            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }
    }

    #endregion

    #region JobTypeController

    [ApiController]
    [Route("[controller]")]
    public class JobTypeController(ITypeService<JobType> service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> GetAsync(
            [FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<JobType>();
            var includes = request.IncludeProperties;

            if (predicate == null)
                return NotFound(new BaseResponse<TypeResponse>(false, Messages.NoneFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<TypeResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<TypeResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<JobType>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);
            if (!result.Any()) return NotFound(new BaseResponse<List<TypeResponse>>(false, Messages.NoneFound));
            return Ok(new BaseResponse<List<TypeResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Insert([FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null) return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Update(Guid id, [FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id) return NotFound(new BaseResponse<TypeResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new TypeInput { Id = id }, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));
            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }
    }

    #endregion

    #region EventTypeController

    [ApiController]
    [Route("[controller]")]
    public class EventTypeController(ITypeService<EventType> service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> GetAsync(
            [FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<EventType>();
            var includes = request.IncludeProperties;

            if (predicate == null)
                return NotFound(new BaseResponse<TypeResponse>(false, Messages.NoneFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<TypeResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<TypeResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<EventType>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);
            if (!result.Any()) return NotFound(new BaseResponse<List<TypeResponse>>(false, Messages.NoneFound));
            return Ok(new BaseResponse<List<TypeResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Insert([FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null) return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Update(Guid id, [FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id) return NotFound(new BaseResponse<TypeResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new TypeInput { Id = id }, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));
            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }
    }

    #endregion

    #region SocialMediaTypeController

    [ApiController]
    [Route("[controller]")]
    public class SocialMediaTypeController(ITypeService<SocialMediaType> service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> GetAsync(
            [FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<SocialMediaType>();
            var includes = request.IncludeProperties;

            if (predicate == null)
                return NotFound(new BaseResponse<TypeResponse>(false, Messages.NoneFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<TypeResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<TypeResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<SocialMediaType>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);
            if (!result.Any()) return NotFound(new BaseResponse<List<TypeResponse>>(false, Messages.NoneFound));
            return Ok(new BaseResponse<List<TypeResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Insert([FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null) return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Update(Guid id, [FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id) return NotFound(new BaseResponse<TypeResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new TypeInput { Id = id }, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));
            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }
    }

    #endregion

    #region AdTypeController

    [ApiController]
    [Route("[controller]")]
    public class AdTypeController(ITypeService<AdType> service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> GetAsync(
            [FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<AdType>();
            var includes = request.IncludeProperties;

            if (predicate == null)
                return NotFound(new BaseResponse<TypeResponse>(false, Messages.NoneFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<TypeResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<TypeResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<AdType>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);
            if (!result.Any()) return NotFound(new BaseResponse<List<TypeResponse>>(false, Messages.NoneFound));
            return Ok(new BaseResponse<List<TypeResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Insert([FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null) return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Update(Guid id, [FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id) return NotFound(new BaseResponse<TypeResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new TypeInput { Id = id }, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));
            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }
    }

    #endregion

    #region AdSubTypeController

    [ApiController]
    [Route("[controller]")]
    public class AdSubTypeController(ITypeService<AdSubType> service) : ControllerBase
    {
        [HttpPost("get")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> GetAsync(
            [FromBody] GetAllRequest request)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<AdSubType>();
            var includes = request.IncludeProperties;

            if (predicate == null)
                return NotFound(new BaseResponse<TypeResponse>(false, Messages.NoneFound));

            var response = await service.GetAsync(predicate, includes);
            return Ok(new BaseResponse<TypeResponse>(true, Messages.Found, response));
        }

        [HttpPost("get-all")]
        public async Task<ActionResult<BaseResponse<List<TypeResponse>>>> GetAll([FromBody] GetAllRequest request,
            CancellationToken cancellationToken)
        {
            var predicate = request.Expression.DeserializeLambdaExpression<AdSubType>();
            var includes = request.IncludeProperties;
            var result = await service.GetAllAsync(predicate, includes, cancellationToken);
            if (!result.Any()) return NotFound(new BaseResponse<List<TypeResponse>>(false, Messages.NoneFound));
            return Ok(new BaseResponse<List<TypeResponse>>(true, Messages.Found, result));
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Insert([FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            var result = await service.InsertAsync(input, cancellationToken);
            if (result == null) return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<BaseResponse<TypeResponse?>>> Update(Guid id, [FromBody] TypeInput input,
            CancellationToken cancellationToken)
        {
            if (id != input.Id) return NotFound(new BaseResponse<TypeResponse?>(false, Messages.NotFound));

            var result = await service.UpdateAsync(input, cancellationToken);
            if (result == null)
                return BadRequest(new BaseResponse<TypeResponse?>(false, Messages.OperationFailed));

            return Ok(new BaseResponse<TypeResponse?>(true, Messages.Found, result));
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var success = await service.HardDeleteAsync(new TypeInput { Id = id }, cancellationToken);
            if (!success) return BadRequest(new BaseResponse<bool>(false, Messages.OperationFailed));
            return Ok(new BaseResponse<bool>(true, Messages.Deleted, true));
        }
    }

    #endregion
}