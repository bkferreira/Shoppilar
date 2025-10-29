using Shoppilar.DTOs.App.Input;

namespace Shoppilar.DTOs.Auth.Input;

public class RegisterInput
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PhoneCode { get; set; } = string.Empty;
    public PersonInput PersonInput { get; set; } = new();
}