#if __IOS__
using Foundation;

// Para NSBundle no iOS
#endif

namespace Shoppilar.Mobile.Utils
{
    public static class Constants
    {
#if DEBUG
        public const string NameApi = "Shoppilar.Api";
        public const string RouteApi = "http://192.168.100.192:5296";
        // public const string RouteApi = "http://192.168.199.171:5296";
        public const string NameAuth = "Shoppilar.Auth";
        public const string RouteAuth = "http://192.168.100.192:5254";
        // public const string RouteAuth = "http://192.168.199.171:5254";
#else
        public const string RouteApi = "";
        public const string RouteAuth = "";
#endif

        public static double DisplayWidth => GetDisplayWidth();
        public static double DisplayHeight => GetDisplayHeight();
        public static string ApplicationDisplayVersion => GetApplicationDisplayVersion();
        public static Task<string> Token => GetToken();
        public static Task<string> RefreshToken => GetRefreshToken();

        private static double GetDisplayWidth()
        {
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            return Math.Round(displayInfo.Width / displayInfo.Density, 0);
        }

        private static double GetDisplayHeight()
        {
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            return Math.Round(displayInfo.Height / displayInfo.Density, 0);
        }

        private static async Task<string> GetToken()
        {
            // return await SecureStorage.GetAsync(DTOs.Util.Constants.TokenKey) ?? string.Empty;
            return Preferences.Get(DTOs.Util.Constants.TokenKey, "");
        }

        private static async Task<string> GetRefreshToken()
        {
            // return await SecureStorage.GetAsync(DTOs.Util.Constants.RefreshTokenKey) ?? string.Empty;
            return Preferences.Get(DTOs.Util.Constants.RefreshTokenKey, "");
        }


        private static string GetApplicationDisplayVersion()
        {
#if __IOS__
            var version =
                NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString() ?? "0";
            return $"v{version}";
#elif __ANDROID__
            var context = Android.App.Application.Context;
            var packageInfo = context.PackageManager?.GetPackageInfo(context.PackageName ?? string.Empty, 0);
            return $"v{packageInfo?.VersionName ?? "0"}";
#endif
        }

        public const string MaterialSymbolsRounded = "MaterialSymbolsRounded-Regular";
    }
}