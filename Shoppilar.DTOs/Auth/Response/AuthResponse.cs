namespace Shoppilar.DTOs.Auth.Response;

public class AuthResponse
{
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
    public DateTime ExpiryDate { get; set; }
}