using Microsoft.AspNetCore.Identity;

namespace Shoppilar.Data.Auth.Models;

public class User : IdentityUser<Guid>
{
    public required string Name { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
}