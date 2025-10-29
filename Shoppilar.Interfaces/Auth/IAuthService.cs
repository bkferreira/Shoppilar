using Shoppilar.DTOs.Auth.Input;
using Shoppilar.DTOs.Auth.Response;

namespace Shoppilar.Interfaces.Auth;

public interface IAuthService
{
    Task<bool> SendPhoneConfirmationCodeAsync(string phoneNumber);
    Task<AuthResponse?> RegisterAsync(RegisterInput input);
    Task<AuthResponse?> LoginAsync(LoginInput input);
    Task<bool> SendPasswordResetCodeAsync(string login);
    Task<bool> ResetPasswordWithCodeAsync(ResetPasswordInput input);
    Task<bool> ChangePasswordAsync(ChangePasswordInput input);
    Task<AuthResponse?> RefreshTokenAsync(string refreshToken);
    Task<bool> RevokeRefreshTokenAsync(string refreshToken);
}