namespace Shoppilar.DTOs.Auth.Input;

public class ConfirmPhoneInput
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}