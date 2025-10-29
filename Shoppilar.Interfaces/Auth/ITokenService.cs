using Shoppilar.Data.Auth.Models;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Auth.Response;

namespace Shoppilar.Interfaces.Auth;

public interface ITokenService
{
    Task<AuthResponse> GenerateAsync(User user, PersonResponse? person = null);
    Task<AuthResponse?> RefreshAsync(string refreshToken);
    Task<bool> RevokeAsync(string refreshToken);
}