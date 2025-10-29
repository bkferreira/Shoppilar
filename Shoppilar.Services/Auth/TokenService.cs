using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shoppilar.Data.Auth.Context;
using Shoppilar.Data.Auth.Models;
using Shoppilar.DTOs.Auth.Response;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Jwt;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.App;
using Shoppilar.Interfaces.Auth;

namespace Shoppilar.Services.Auth;

public class TokenService(
    AuthDbContext context,
    IConfiguration configuration,
    IPersonService personService
) : ITokenService
{
    public async Task<AuthResponse> GenerateAsync(User user, PersonResponse? person = null)
    {
        var jwtKey = configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key não configurado.");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email ?? string.Empty),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        if (person != null)
        {
            claims.Add(new Claim(JwtClaims.Name, person.Name));
            claims.Add(new Claim(JwtClaims.PersonId, person.Id.ToString()));
        }

        var expiryMinutes = configuration.GetValue("Jwt:AccessTokenMinutes", 60);
        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        var refresh = new RefreshToken
        {
            Token = Guid.NewGuid().ToString(),
            UserId = user.Id,
            ExpiryDate = DateTime.UtcNow.AddDays(7)
        };

        context.RefreshTokens.Add(refresh);
        await context.SaveChangesAsync();

        return new AuthResponse
        {
            Token = jwt,
            RefreshToken = refresh.Token,
            ExpiryDate = token.ValidTo
        };
    }

    public async Task<AuthResponse?> RefreshAsync(string refreshToken)
    {
        var token = await context.RefreshTokens
            .Include(r => r.User)
            .FirstOrDefaultAsync(r => r.Token == refreshToken && !r.IsRevoked);

        if (token == null || token.ExpiryDate < DateTime.UtcNow)
            return null;

        token.IsRevoked = true; // rotaciona token!
        await context.SaveChangesAsync();

        var person = await personService.GetAsync(e => e.CreatedById == token.User!.Id, Includes.PersonIncludeAuth);
        return await GenerateAsync(token.User!, person);
    }

    public async Task<bool> RevokeAsync(string refreshToken)
    {
        var token = await context.RefreshTokens.FirstOrDefaultAsync(r => r.Token == refreshToken);
        if (token == null) return false;
        token.IsRevoked = true;
        await context.SaveChangesAsync();
        return true;
    }
}