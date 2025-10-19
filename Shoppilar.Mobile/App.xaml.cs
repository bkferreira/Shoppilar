using Shoppilar.Mobile.Shells.Auth;

namespace Shoppilar.Mobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AuthShell());
    }
}