namespace Shoppilar.Data.Auth.Models;

public class RefreshToken
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Token { get; set; }
    public DateTime ExpiryDate { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public bool IsRevoked { get; set; }
}