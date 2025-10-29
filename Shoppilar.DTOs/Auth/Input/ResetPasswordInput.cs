namespace Shoppilar.DTOs.Auth.Input;

public class ResetPasswordInput
{
    public string PhoneNumber { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}