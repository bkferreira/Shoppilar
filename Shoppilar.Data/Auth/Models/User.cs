using Microsoft.AspNetCore.Identity;

namespace Shoppilar.Data.Auth.Models;

public class User : IdentityUser<Guid>
{
    public required string FullName { get; set; }
    public ICollection<RefreshToken>? RefreshTokens { get; set; }
}