namespace Shoppilar.DTOs.Auth.Input;

public class ChangePasswordInput
{
    public string Login { get; set; } = null!;
    public string CurrentPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}