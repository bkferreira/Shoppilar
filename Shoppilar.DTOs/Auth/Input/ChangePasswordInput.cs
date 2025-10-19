namespace Shoppilar.DTOs.Auth.Input;

public class ChangePasswordInput
{
    public required string Email { get; set; }
    public required string CurrentPassword { get; set; }
    public required string NewPassword { get; set; }
}