using Shoppilar.DTOs.App.Input;

namespace Shoppilar.DTOs.Auth.Input;

public class RegisterInput
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string FullName { get; set; }
    public required PersonInput PersonInput { get; set; }
}