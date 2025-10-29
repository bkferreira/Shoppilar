using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shoppilar.Data.Auth.Context;
using Shoppilar.Data.Auth.Models;
using Shoppilar.DTOs.Auth.Input;
using Shoppilar.DTOs.Auth.Response;
using Shoppilar.DTOs.Ext;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.App;
using Shoppilar.Interfaces.Auth;
using Shoppilar.Interfaces.Ext;

namespace Shoppilar.Services.Auth;

public class AuthService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    IVerificationCodeService codeService,
    ITokenService tokenService,
    IPasswordService passwordService,
    IPersonService personService,
    ISmsService smsService,
    AuthDbContext context
) : IAuthService
{
    private static readonly TimeSpan PhoneCodeExpiry = TimeSpan.FromMinutes(Constants.PhoneCodeExpiryTime);
    private static readonly TimeSpan ResetCodeExpiry = TimeSpan.FromMinutes(Constants.ResetCodeExpiryTime);

    public async Task<bool> SendPhoneConfirmationCodeAsync(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone)) return false;

        var exists = await userManager.Users.AnyAsync(u => u.PhoneNumber == phone);
        if (exists) return false;

        var code = await codeService.GenerateAndSaveAsync(phone, Constants.PhoneConfirmationPurpose, PhoneCodeExpiry);
        await smsService.SendAsync(new SmsInput(phone,
            Constants.MessagePhoneConfirmationPurpose.Replace("{codigo}", code)
                .Replace("{tempo}", Constants.PhoneCodeExpiryTime.ToString())));
        return true;
    }

    public async Task<bool> SendPasswordResetCodeAsync(string login)
    {
        if (string.IsNullOrWhiteSpace(login)) return false;

        var user = await userManager.FindByNameAsync(login)
                   ?? await userManager.FindByEmailAsync(login)
                   ?? await userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == login);

        if (user == null) return false;

        var code = await codeService.GenerateAndSaveAsync(login, Constants.ResetPasswordPurpose, ResetCodeExpiry);
        await smsService.SendAsync(new SmsInput(login,
            Constants.MessageResetPasswordPurpose.Replace("{codigo}", code)
                .Replace("{tempo}", Constants.ResetCodeExpiryTime.ToString())));

        return true;
    }

    public async Task<AuthResponse?> RegisterAsync(RegisterInput input)
    {
        var valid = await codeService.ValidateAsync(input.PhoneNumber, Constants.PhoneConfirmationPurpose,
            input.PhoneCode, true);
        if (!valid) return null;

        if (await userManager.Users.AnyAsync(u =>
                u.UserName == input.UserName || u.Email == input.Email || u.PhoneNumber == input.PhoneNumber))
            return null;

        await using var trx = await context.Database.BeginTransactionAsync();
        try
        {
            var user = new User
            {
                UserName = input.UserName,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                Name = input.PersonInput.Name,
                PhoneNumberConfirmed = true
            };

            var createResult = await userManager.CreateAsync(user, input.Password);
            if (!createResult.Succeeded)
            {
                await trx.RollbackAsync();
                return null;
            }

            input.PersonInput.CreatedById = user.Id;
            var person = await personService.InsertAsync(input.PersonInput);
            if (person == null)
            {
                await trx.RollbackAsync();
                return null;
            }

            await trx.CommitAsync();
            return await tokenService.GenerateAsync(user, person);
        }
        catch
        {
            await trx.RollbackAsync();
            return null;
        }
    }

    public async Task<AuthResponse?> LoginAsync(LoginInput input)
    {
        var user = await userManager.FindByNameAsync(input.Login)
                   ?? await userManager.FindByEmailAsync(input.Login)
                   ?? await userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == input.Login);

        if (user == null) return null;

        var sign = await signInManager.CheckPasswordSignInAsync(user, input.Password, false);
        if (!sign.Succeeded) return null;

        var person = await personService.GetAsync(e => e.CreatedById == user.Id, Includes.PersonIncludeAuth);
        return await tokenService.GenerateAsync(user, person);
    }

    public Task<bool> ChangePasswordAsync(ChangePasswordInput input)
        => passwordService.ChangePasswordAsync(input);

    public Task<bool> ResetPasswordWithCodeAsync(ResetPasswordInput input)
        => passwordService.ResetWithCodeAsync(input);

    public Task<AuthResponse?> RefreshTokenAsync(string refreshToken)
        => tokenService.RefreshAsync(refreshToken);

    public Task<bool> RevokeRefreshTokenAsync(string refreshToken)
        => tokenService.RevokeAsync(refreshToken);
}