namespace Shoppilar.DTOs.Auth.Input;

public class LoginInput
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}