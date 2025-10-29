using Shoppilar.Interfaces.App;
using Shoppilar.Interfaces.Auth;
using Shoppilar.Mobile.Clients.App;
using Shoppilar.Mobile.Clients.Auth;
using Shoppilar.Mobile.Components;
using Shoppilar.Mobile.Handlers;
using Shoppilar.Mobile.Interfaces;
using Shoppilar.Mobile.Services;
using Shoppilar.Mobile.Shells.App.ViewModels;
using Shoppilar.Mobile.Shells.App.Views;
using Shoppilar.Mobile.Shells.Auth.ViewModels;
using Shoppilar.Mobile.Shells.Auth.Views;

namespace Shoppilar.Mobile.DependencyInjection;

public static class ServiceCollection
{
    public static void AddProjectServices(this IServiceCollection services)
    {
        #region Services

        services.AddTransient<AuthHandler>();
        services.AddScoped<IAuthService, ClientAuthService>();
        services.AddScoped<INavigationService, NavigationService>();
        services.AddScoped<IPersonService, ClientPersonService>();

        #endregion

        #region Views

        services.AddTransient<LoginView>();
        services.AddTransient<RegisterView>();
        services.AddTransient<ForgotPasswordView>();
        services.AddTransient<HomeView>();
        services.AddTransient<FloatingEntryView>();

        #endregion

        #region ViewModels

        services.AddTransient<LoginViewModel>();
        services.AddTransient<RegisterViewModel>();
        services.AddTransient<ForgotPasswordViewModel>();
        services.AddTransient<HomeViewModel>();

        #endregion

        #region ViewsWeb

        // services.AddTransient<VWDefault>();

        #endregion

        #region Popups

        // services.AddTransient<PContact>();

        #endregion

        #region Components

        // services.AddTransient<CCalled>();

        #endregion

        #region ComponentsModels

        // services.AddTransient<CMCalled>();

        #endregion
    }
}