using Shoppilar.DTOs.Auth.Input;
using Shoppilar.DTOs.Auth.Response;

namespace Shoppilar.Interfaces.Auth;

public interface IAuthService
{
    Task<AuthResponse?> RegisterAsync(RegisterInput input);
    Task<AuthResponse?> LoginAsync(LoginInput input);
    Task<AuthResponse?> RefreshTokenAsync(string token);
    Task<bool> ChangePasswordAsync(ChangePasswordInput input);
    Task<bool> RevokeRefreshTokenAsync(string token);
}