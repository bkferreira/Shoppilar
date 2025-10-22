using Microsoft.AspNetCore.Mvc;

namespace Shoppilar.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("resultJwt")]
    public IActionResult ResultJwt()
    {
        var claims = HttpContext.User.Claims.Select(c => new { c.Type, c.Value }).ToList();
        return Ok(claims);
    }
}