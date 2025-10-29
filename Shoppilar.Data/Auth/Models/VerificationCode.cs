namespace Shoppilar.Data.Auth.Models;

public class VerificationCode
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public DateTime Expiry { get; set; }
    public bool Used { get; set; }
    public int Attempts { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}