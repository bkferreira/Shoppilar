namespace Shoppilar.DTOs.Util;

public class Routes
{
    #region Person

    private const string PersonRoute = "Person";
    public const string PersonGetAsync = $"{PersonRoute}/get";
    public const string PersonGetAllAsync = $"{PersonRoute}/get-all";
    public const string PersonGetPagedAsync = $"{PersonRoute}/get-paged";
    public const string PersonInsertAsync = $"{PersonRoute}";
    public const string PersonUpdateAsync = $"{PersonRoute}";
    public const string PersonDeleteAsync = $"{PersonRoute}";
    public const string PersonCountAsync = $"{PersonRoute}/count";

    #endregion

    #region Auth

    private const string AuthRoute = "Auth";
    public const string SendPhoneConfirmationCodeAsync = $"{AuthRoute}/send-phone-code";
    public const string RegisterAsync = $"{AuthRoute}/register";
    public const string LoginAsync = $"{AuthRoute}/login";
    public const string SendPasswordResetCodeAsync = $"{AuthRoute}/send-reset-code";
    public const string ResetPasswordWithCodeAsync = $"{AuthRoute}/reset-password";
    public const string ChangePasswordAsync = $"{AuthRoute}/change-password";
    public const string RefreshTokenAsync = $"{AuthRoute}/refresh-token";
    public const string RevokeRefreshTokenAsync = $"{AuthRoute}/revoke-token";

    #endregion
}