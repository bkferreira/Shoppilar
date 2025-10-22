using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shoppilar.Data.Auth.Context;
using Shoppilar.Data.Auth.Models;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.Auth.Input;
using Shoppilar.DTOs.Auth.Response;
using Shoppilar.DTOs.Jwt;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.App;
using Shoppilar.Interfaces.Auth;

namespace Shoppilar.Services.Auth;

public class AuthService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    IConfiguration configuration,
    IPersonService personService,
    AuthDbContext context
) : IAuthService
{
    public async Task<AuthResponse?> RegisterAsync(RegisterInput input)
    {
        if (string.IsNullOrWhiteSpace(input.PhoneNumber) || string.IsNullOrWhiteSpace(input.Password))
            return null;

        await using var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            var user = new User
            {
                UserName = input.UserName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                Name = input.PersonInput.Name
            };

            if (await userManager.Users.AnyAsync(u =>
                    (u.UserName != null && u.UserName == user.UserName) ||
                    (u.Email != null && u.Email == user.Email) ||
                    (u.PhoneNumber != null && u.PhoneNumber == user.PhoneNumber)))
                return null;

            var userResult = await userManager.CreateAsync(user, input.Password);
            if (!userResult.Succeeded)
                return null;

            input.PersonInput.CreatedById = user.Id;
            var personResponse = await personService.InsertAsync(input.PersonInput);
            if (!personResponse.Success || personResponse.Item == null)
            {
                await transaction.RollbackAsync();
                return null;
            }

            await transaction.CommitAsync();

            return await GenerateJwtTokenAsync(user, personResponse.Item);
        }
        catch
        {
            await transaction.RollbackAsync();
            return null;
        }
    }

    public async Task<AuthResponse?> LoginAsync(LoginInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Login) || string.IsNullOrWhiteSpace(input.Password))
            return null;

        var normalizedLogin = input.Login.Trim().ToUpperInvariant();

        var user = await userManager.Users
            .FirstOrDefaultAsync(u =>
                (u.Email != null && u.Email.ToUpper() == normalizedLogin) ||
                (u.UserName != null && u.UserName.ToUpper() == normalizedLogin) ||
                (u.PhoneNumber != null && u.PhoneNumber == input.Login.Trim())
            );

        if (user == null)
            return null;

        var result = await signInManager.CheckPasswordSignInAsync(user, input.Password, false);
        if (!result.Succeeded)
            return null;

        var person = await personService.GetAsync(
            e => e.CreatedById == user.Id,
            Includes.PersonIncludeAuth,
            CancellationToken.None
        );

        return await GenerateJwtTokenAsync(user, person);
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordInput input)
    {
        var normalizedLogin = input.Login.Trim().ToUpperInvariant();
        var user = await userManager.Users
            .FirstOrDefaultAsync(u =>
                (u.Email != null && u.Email.ToUpper() == normalizedLogin) ||
                (u.UserName != null && u.UserName.ToUpper() == normalizedLogin) ||
                (u.PhoneNumber != null && u.PhoneNumber == input.Login.Trim())
            );

        if (user == null) return false;

        var result = await userManager.ChangePasswordAsync(user, input.CurrentPassword, input.NewPassword);
        return result.Succeeded;
    }

    public async Task<AuthResponse?> RefreshTokenAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token)) return null;

        var refreshToken = await context.RefreshTokens
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.Token == token && !t.IsRevoked);

        if (refreshToken == null || refreshToken.ExpiryDate < DateTime.UtcNow)
            return null;


        var person = await personService.GetAsync(
            e => e.CreatedById == refreshToken.User!.Id,
            Includes.PersonIncludeAuth,
            CancellationToken.None
        );

        return await GenerateJwtTokenAsync(refreshToken.User!, person);
    }

    public async Task<bool> RevokeRefreshTokenAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token)) return false;

        var refreshToken = await context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token);
        if (refreshToken == null) return false;

        refreshToken.IsRevoked = true;
        await context.SaveChangesAsync();
        return true;
    }

    private async Task<AuthResponse> GenerateJwtTokenAsync(User user, PersonResponse? person = null)
    {
        var jwtKey = configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key não configurado.");
        var jwtIssuer = configuration["Jwt:Issuer"];
        var jwtAudience = configuration["Jwt:Audience"];
        var expiryMinutes = configuration.GetValue("Jwt:AccessTokenMinutes", 60);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email ?? string.Empty),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        if (person != null)
        {
            if (!string.IsNullOrEmpty(person.Name))
                claims.Add(new Claim(JwtClaims.Name, Clean(person.Name)));
            if (!string.IsNullOrEmpty(person.PersonTypeDesc))
                claims.Add(new Claim(JwtClaims.PersonType, Clean(person.PersonTypeDesc)));
            if (!string.IsNullOrEmpty(person.Birth))
                claims.Add(new Claim(JwtClaims.Birth, Clean(person.Birth)));

            claims.Add(new Claim(JwtClaims.PersonId, person.Id.ToString()));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: creds
        );

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        var refreshToken = new RefreshToken
        {
            Token = Guid.NewGuid().ToString(),
            ExpiryDate = DateTime.UtcNow.AddDays(7),
            UserId = user.Id
        };

        context.RefreshTokens.Add(refreshToken);
        await context.SaveChangesAsync();

        return new AuthResponse
        {
            Token = jwtToken,
            RefreshToken = refreshToken.Token,
            ExpiryDate = token.ValidTo
        };
    }

    private string Clean(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) return string.Empty;

        var normalized = input.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();

        foreach (var c in normalized)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory(c);
            if (category != UnicodeCategory.NonSpacingMark && c <= 127)
                sb.Append(c);
        }

        return sb.ToString();
    }
}