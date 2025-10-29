using System.Net;
using System.Net.Http.Headers;
using Shoppilar.Interfaces.Auth;
using Shoppilar.Mobile.Utils;

namespace Shoppilar.Mobile.Handlers;

public class AuthHandler(IAuthService authService) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await Constants.Token;
        var refreshToken = await Constants.RefreshToken;

        if (!string.IsNullOrWhiteSpace(token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized && !string.IsNullOrWhiteSpace(refreshToken))
        {
            var newAuth = await authService.RefreshTokenAsync(refreshToken);

            if (!string.IsNullOrWhiteSpace(newAuth?.Token))
            {
                await SecureStorage.SetAsync(DTOs.Util.Constants.TokenKey, newAuth.Token);
                if (!string.IsNullOrWhiteSpace(newAuth.RefreshToken))
                    await SecureStorage.SetAsync(DTOs.Util.Constants.RefreshTokenKey, newAuth.RefreshToken);

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", newAuth.Token);
                response.Dispose();
                response = await base.SendAsync(request, cancellationToken);
            }
        }

        return response;
    }
}