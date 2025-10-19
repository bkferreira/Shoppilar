using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shoppilar.Data.App.Models;
using Shoppilar.Data.Auth.Context;
using Shoppilar.Data.Auth.Models;
using Shoppilar.DTOs.App.Response;
using Shoppilar.DTOs.App.Util;
using Shoppilar.DTOs.Auth.Input;
using Shoppilar.DTOs.Auth.Response;
using Shoppilar.DTOs.Jwt;
using Shoppilar.Interfaces.App;
using Shoppilar.Interfaces.Auth;

namespace Shoppilar.Services.Auth;

public class AuthService(
    UserManager<User> UserManager,
    SignInManager<User> signInManager,
    IConfiguration configuration,
    IPersonService personService,
    AuthDbContext context)
    : IAuthService
{
    public async Task<AuthResponse?> RegisterAsync(RegisterInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Email))
            return null;

        await using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            var user = new User
            {
                UserName = input.Email,
                Email = input.Email,
                FullName = input.FullName
            };

            var userResult = await UserManager.CreateAsync(user, input.Password);
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
        var User = await UserManager.FindByEmailAsync(input.Email);
        if (User == null) return null;

        var result = await signInManager.CheckPasswordSignInAsync(User, input.Password, false);
        if (!result.Succeeded) return null;

        var include = IncludeHelper.GetIncludePaths<Person>(p => p.PersonType!, p => p.Image!);

        var person =
            await personService.GetAllAsync(e => e.CreatedById == User.Id, include, CancellationToken.None);

        return await GenerateJwtTokenAsync(User, person.First());
    }

    public async Task<AuthResponse?> RefreshTokenAsync(string token)
    {
        if (string.IsNullOrWhiteSpace(token)) return null;

        var refreshToken = await context.RefreshTokens
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Token == token && !t.IsRevoked);

        if (refreshToken == null || refreshToken.ExpiryDate < DateTime.UtcNow)
            return null;

        var User = await UserManager.FindByIdAsync(refreshToken.UserId.ToString());
        if (User != null) return await GenerateJwtTokenAsync(User);
        else return null;
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordInput input)
    {
        var User = await UserManager.FindByEmailAsync(input.Email);
        if (User == null) return false;

        var result = await UserManager.ChangePasswordAsync(User, input.CurrentPassword, input.NewPassword);
        return result.Succeeded;
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
        var expiryMinutes = configuration.GetValue("Jwt:AccessTokenMinutes", 15);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email ?? string.Empty),
            new(JwtClaims.FullName, Clean(user.FullName)),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        if (person is not null)
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

        // Refresh token
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
            if (category != UnicodeCategory.NonSpacingMark && c <= 127) // remove acentos e caracteres não ASCII
                sb.Append(c);
        }

        return sb.ToString();
    }
}