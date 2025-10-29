using System.Net.Http.Json;
using System.Text.Json;
using Shoppilar.DTOs.Auth.Input;
using Shoppilar.DTOs.Auth.Response;
using Shoppilar.DTOs.Util;
using Shoppilar.Interfaces.Auth;

namespace Shoppilar.Mobile.Clients.Auth;

public class ClientAuthService(IHttpClientFactory httpClientFactory) : IAuthService
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient(Utils.Constants.NameAuth);

    private static readonly JsonSerializerOptions ReadOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<bool> SendPhoneConfirmationCodeAsync(string phone)
    {
        var response =
            await _httpClient.PostAsJsonAsync(Routes.SendPhoneConfirmationCodeAsync,
                new SendTokenInput { PhoneNumber = phone });

        if (!response.IsSuccessStatusCode)
            return false;

        var result = await response.Content.ReadFromJsonAsync<BaseResponse<bool?>>(ReadOptions);

        if (result!.Success) return result.Item ?? false;
        else return false;
    }

    public async Task<AuthResponse?> RegisterAsync(RegisterInput input)
    {
        var response = await _httpClient.PostAsJsonAsync(Routes.RegisterAsync, input);
        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<BaseResponse<AuthResponse?>>(ReadOptions);

        if (result!.Success) return result.Item;
        else return null;
    }

    public async Task<AuthResponse?> LoginAsync(LoginInput input)
    {
        var response = await _httpClient.PostAsJsonAsync(Routes.LoginAsync, input);
        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<BaseResponse<AuthResponse>>(ReadOptions);

        if (result!.Success)
        {
            // await SecureStorage.SetAsync(Constants.TokenKey, loginResult.Token);
            // await SecureStorage.SetAsync(Constants.RefreshTokenKey, loginResult.RefreshToken);

            Preferences.Set(Constants.TokenKey, result.Item!.Token);
            Preferences.Set(Constants.RefreshTokenKey, result.Item!.RefreshToken);
            return result.Item;
        }
        else return null;
    }

    public async Task<bool> SendPasswordResetCodeAsync(string phone)
    {
        var response =
            await _httpClient.PostAsJsonAsync(Routes.SendPasswordResetCodeAsync,
                new SendTokenInput { PhoneNumber = phone });
        if (!response.IsSuccessStatusCode)
            return false;

        var result = await response.Content.ReadFromJsonAsync<BaseResponse<bool?>>(ReadOptions);

        if (result!.Success) return result.Item ?? false;
        else return false;
    }

    public async Task<bool> ResetPasswordWithCodeAsync(ResetPasswordInput input)
    {
        var response = await _httpClient.PostAsJsonAsync(Routes.ResetPasswordWithCodeAsync, input);
        if (!response.IsSuccessStatusCode)
            return false;

        var result = await response.Content.ReadFromJsonAsync<BaseResponse<bool?>>(ReadOptions);

        if (result!.Success) return result.Item ?? false;
        else return false;
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordInput input)
    {
        var response = await _httpClient.PostAsJsonAsync(Routes.ChangePasswordAsync, input);
        if (!response.IsSuccessStatusCode)
            return false;

        var result = await response.Content.ReadFromJsonAsync<BaseResponse<bool?>>(ReadOptions);

        if (result!.Success) return result.Item ?? false;
        else return false;
    }

    public async Task<AuthResponse?> RefreshTokenAsync(string token)
    {
        var response = await _httpClient.PostAsJsonAsync(Routes.RefreshTokenAsync, token);
        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<BaseResponse<AuthResponse?>>(ReadOptions);

        if (result!.Success) return result.Item;
        else return null;
    }

    public async Task<bool> RevokeRefreshTokenAsync(string token)
    {
        var response = await _httpClient.PostAsJsonAsync(Routes.RevokeRefreshTokenAsync, token);
        if (!response.IsSuccessStatusCode)
            return false;

        var result = await response.Content.ReadFromJsonAsync<BaseResponse<bool?>>(ReadOptions);

        if (result!.Success) return result.Item ?? false;
        else return false;
    }
}