using Shoppilar.Mobile.Shells.App.Views;
using Shoppilar.Mobile.Shells.Auth.Views;

namespace Shoppilar.Mobile.Shells.App;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(HomeView), typeof(HomeView));
    }
}