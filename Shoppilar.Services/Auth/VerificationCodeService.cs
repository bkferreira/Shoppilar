using Microsoft.EntityFrameworkCore;
using Shoppilar.Data.Auth.Context;
using Shoppilar.Data.Auth.Models;
using System.Security.Cryptography;
using Shoppilar.Interfaces.Auth;

namespace Shoppilar.Services.Auth;

public class VerificationCodeService(AuthDbContext context) : IVerificationCodeService
{
    private static string Generate6DigitCode()
    {
        var bytes = new byte[4];
        RandomNumberGenerator.Fill(bytes);
        var value = BitConverter.ToUInt32(bytes, 0) % 1_000_000;
        return value.ToString("D6");
    }

    public async Task<string> GenerateAndSaveAsync(string phoneNumber, string type, TimeSpan ttl)
    {
        var code = Generate6DigitCode();

        var existing = await context.VerificationCodes
            .FirstOrDefaultAsync(vc => vc.PhoneNumber == phoneNumber && vc.Type == type && !vc.Used);

        if (existing != null)
        {
            existing.Code = code;
            existing.Expiry = DateTime.UtcNow.Add(ttl);
            existing.Attempts = 0;
            existing.CreatedAt = DateTime.UtcNow;
        }
        else
        {
            context.VerificationCodes.Add(new VerificationCode
            {
                PhoneNumber = phoneNumber,
                Type = type,
                Code = code,
                Expiry = DateTime.UtcNow.Add(ttl),
                Used = false,
                Attempts = 0,
                CreatedAt = DateTime.UtcNow
            });
        }

        await context.SaveChangesAsync();
        return code;
    }

    public async Task<bool> ValidateAsync(string phoneNumber, string type, string code, bool markAsUsed = false)
    {
        var record = await context.VerificationCodes
            .FirstOrDefaultAsync(vc => vc.PhoneNumber == phoneNumber && vc.Type == type && !vc.Used);

        if (record == null || record.Expiry < DateTime.UtcNow)
            return false;

        if (record.Code != code)
        {
            record.Attempts++;
            await context.SaveChangesAsync();
            return false;
        }

        if (markAsUsed)
        {
            record.Used = true;
            await context.SaveChangesAsync();
        }

        return true;
    }
}