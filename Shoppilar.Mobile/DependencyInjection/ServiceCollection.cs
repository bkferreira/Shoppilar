using Shoppilar.Mobile.Shells.Auth.ViewModels;
using Shoppilar.Mobile.Shells.Auth.Views;

namespace Shoppilar.Mobile.DependencyInjection;

public static class ServiceCollection
{
    public static void AddProjectServices(this IServiceCollection services)
    {
        #region Services

        // services.AddScoped<IIndicadorService, ClientIndicadorService>();

        #endregion

        #region Views

        services.AddTransient<LoginView>();

        #endregion

        #region ViewModels

        services.AddTransient<LoginViewModel>();

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