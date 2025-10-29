namespace Shoppilar.Interfaces.Auth;

public interface IVerificationCodeService
{
    Task<string> GenerateAndSaveAsync(string phoneNumber, string type, TimeSpan ttl);
    Task<bool> ValidateAsync(string phoneNumber, string type, string code, bool markAsUsed = false);
}