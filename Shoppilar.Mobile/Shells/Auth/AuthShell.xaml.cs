using Shoppilar.Mobile.Shells.Auth.Views;

namespace Shoppilar.Mobile.Shells.Auth;

public partial class AuthShell : Shell
{
    public AuthShell()
    {
        InitializeComponent();
        RegisterRoutes();
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute(nameof(LoginView), typeof(LoginView));
    }
}