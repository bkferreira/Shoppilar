using Microsoft.AspNetCore.Mvc;
using Shoppilar.DTOs.Auth.Input;
using Shoppilar.Interfaces.Auth;

namespace Shoppilar.Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterInput input)
        {
            var result = await authService.RegisterAsync(input);

            if (result == null)
                return BadRequest("Não foi possível registrar o usuário.");

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginInput input)
        {
            var result = await authService.LoginAsync(input);

            if (result == null)
                return Unauthorized("Email ou senha inválidos.");

            return Ok(result);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Login)
                || string.IsNullOrWhiteSpace(input.CurrentPassword)
                || string.IsNullOrWhiteSpace(input.NewPassword))
            {
                return BadRequest("Dados incompletos para alterar a senha.");
            }

            var success = await authService.ChangePasswordAsync(input);

            if (!success)
                return BadRequest("Falha ao alterar a senha. Usuário ou senha atual inválidos.");

            return Ok("Senha alterada com sucesso.");
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