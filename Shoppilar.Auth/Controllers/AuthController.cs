using Microsoft.AspNetCore.Mvc;
using Shoppilar.DTOs.Auth.Input;
using Shoppilar.DTOs.Auth.Response;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.Auth;

namespace Shoppilar.Auth.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthService auth) : ControllerBase
{
    [HttpPost("send-phone-code")]
    public async Task<ActionResult<BaseResponse<bool>>> SendPhoneCode([FromBody] SendTokenInput input)
    {
        var result = await auth.SendPhoneConfirmationCodeAsync(input.PhoneNumber);

        if (!result)
            return BadRequest(new BaseResponse<bool>(false, "Falha ao enviar código (talvez já registrado)"));

        return Ok(new BaseResponse<bool>(true, "Código enviado"));
    }

    [HttpPost("register")]
    public async Task<ActionResult<BaseResponse<AuthResponse>>> Register([FromBody] RegisterInput input)
    {
        var result = await auth.RegisterAsync(input);
        if (result == null)
            return BadRequest(new BaseResponse<AuthResponse>(false,
                "Não foi possível registrar (verifique código de telefone / dados)", result));

        return Ok(new BaseResponse<AuthResponse>(true, "Código enviado", result));
    }

    [HttpPost("login")]
    public async Task<ActionResult<BaseResponse<AuthResponse>>> Login([FromBody] LoginInput input)
    {
        var result = await auth.LoginAsync(input);
        if (result == null)
            return BadRequest(new BaseResponse<AuthResponse>(false, "Login inválido", result));

        return Ok(new BaseResponse<AuthResponse>(true, "Ok", result));
    }

    [HttpPost("send-reset-code")]
    public async Task<ActionResult<BaseResponse<bool>>> SendReset([FromBody] SendTokenInput input)
    {
        var result = await auth.SendPasswordResetCodeAsync(input.PhoneNumber);

        if (!result)
            return BadRequest(new BaseResponse<bool>(false, "Usuário não encontrado"));

        return Ok(new BaseResponse<bool>(true, "Código de redefinição enviado"));
    }

    [HttpPost("reset-password")]
    public async Task<ActionResult<BaseResponse<bool>>> ResetPassword([FromBody] ResetPasswordInput input)
    {
        var result = await auth.ResetPasswordWithCodeAsync(input);

        if (!result)
            return BadRequest(new BaseResponse<bool>(false, "Código inválido ou expirado"));

        return Ok(new BaseResponse<bool>(true, "Senha redefinida"));
    }

    [HttpPost("change-password")]
    public async Task<ActionResult<BaseResponse<bool>>> ChangePassword([FromBody] ChangePasswordInput input)
    {
        var result = await auth.ChangePasswordAsync(input);

        if (!result)
            return BadRequest(new BaseResponse<bool>(false, "Falha ao alterar senha"));

        return Ok(new BaseResponse<bool>(true, "Senha alterada"));
    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult<BaseResponse<AuthResponse>>> Refresh([FromBody] string token)
    {
        var result = await auth.RefreshTokenAsync(token);
        if (result == null)
            return BadRequest(new BaseResponse<AuthResponse>(false, "Token inválido", result));

        return Ok(new BaseResponse<AuthResponse>(true, "Ok", result));
    }

    [HttpPost("revoke-token")]
    public async Task<ActionResult<BaseResponse<bool>>> Revoke([FromBody] string token)
    {
        var result = await auth.RevokeRefreshTokenAsync(token);

        if (!result)
            return BadRequest(new BaseResponse<bool>(false, "Token inválido"));

        return Ok(new BaseResponse<bool>(true, "Ok"));
    }
}