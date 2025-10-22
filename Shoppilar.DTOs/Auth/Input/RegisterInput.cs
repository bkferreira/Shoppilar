using Shoppilar.DTOs.App.Input;

namespace Shoppilar.DTOs.Auth.Input;

public class RegisterInput
{
    public string? Email { get; set; }
    public required string PhoneNumber { get; set; }
    public string? UserName { get; set; }
    public required string Password { get; set; }
    public required PersonInput PersonInput { get; set; }
}