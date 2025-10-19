using Microsoft.AspNetCore.Mvc;
using Shoppilar.DTOs.Auth.Input;
using Shoppilar.Interfaces.Auth;

namespace Shoppilar.Auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterInput input)
        {
            var result = await authService.RegisterAsync(input);

            if (result == null)
                return BadRequest("Não foi possível registrar o usuário.");

            return Ok(result); // Retorna JWT + RefreshToken
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginInput input)
        {
            var result = await authService.LoginAsync(input);

            if (result == null)
                return Unauthorized("Email ou senha inválidos.");

            return Ok(result); // Retorna JWT + RefreshToken
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody] string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return BadRequest("Token inválido.");

            var result = await authService.RefreshTokenAsync(token);

            if (result == null)
                return Unauthorized("Token expirado ou inválido.");

            return Ok(result);
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> Revoke([FromBody] string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return BadRequest("Token inválido.");

            var revoked = await authService.RevokeRefreshTokenAsync(token);

            if (!revoked)
                return NotFound("Refresh token não encontrado ou já revogado.");

            return NoContent();
        }
    }
}