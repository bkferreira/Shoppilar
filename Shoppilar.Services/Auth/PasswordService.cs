using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shoppilar.Data.Auth.Models;
using Shoppilar.DTOs.Auth.Input;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.Auth;

namespace Shoppilar.Services.Auth;

public class PasswordService(
    UserManager<User> userManager,
    IVerificationCodeService verificationService
) : IPasswordService
{
    private async Task<User?> FindUserAsync(string login)
    {
        return await userManager.FindByNameAsync(login)
               ?? await userManager.FindByEmailAsync(login)
               ?? await userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == login);
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordInput input)
    {
        var user = await FindUserAsync(input.Login);
        if (user == null) return false;

        var result = await userManager.ChangePasswordAsync(user, input.CurrentPassword, input.NewPassword);
        return result.Succeeded;
    }

    public async Task<bool> ResetWithCodeAsync(ResetPasswordInput input)
    {
        var user = await FindUserAsync(input.PhoneNumber);
        if (user == null) return false;

        var valid = await verificationService.ValidateAsync(input.PhoneNumber, Constants.ResetPasswordPurpose,
            input.Code, true);
        if (!valid) return false;

        var token = await userManager.GeneratePasswordResetTokenAsync(user);
        var result = await userManager.ResetPasswordAsync(user, token, input.NewPassword);
        return result.Succeeded;
    }
}