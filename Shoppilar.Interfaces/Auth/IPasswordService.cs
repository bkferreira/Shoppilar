using Shoppilar.DTOs.Auth.Input;

namespace Shoppilar.Interfaces.Auth;

public interface IPasswordService
{
    Task<bool> ChangePasswordAsync(ChangePasswordInput input);
    Task<bool> ResetWithCodeAsync(ResetPasswordInput input);
}