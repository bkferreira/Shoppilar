using Microsoft.AspNetCore.Mvc;
using Shoppilar.DTOs.Ext;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.Ext;

namespace Shoppilar.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class SmsController(ISmsService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<BaseResponse>> Send(SmsInput input, CancellationToken cancellationToken = default)
    {
        var result = await service.SendAsync(input, cancellationToken);
        if (!result.Success)
            return BadRequest(new BaseResponse<bool>(false, Messages.SendFailed));

        return Ok(new BaseResponse<bool>(true, Messages.SendedSuccess));
    }
}