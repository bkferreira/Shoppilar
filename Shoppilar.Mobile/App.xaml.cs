using Shoppilar.Mobile.Interfaces;
using Shoppilar.Mobile.Shells.Auth;

namespace Shoppilar.Mobile;

public partial class App : Application
{
    private readonly IDatabaseService _databaseService;

    public App(IDatabaseService databaseService)
    {
        InitializeComponent();
        _databaseService = databaseService;
    }

    protected override async void OnStart()
    {
        try
        {
            await _databaseService.InitAsync();
        }
        catch
        {
            // ignored
        }
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AuthShell());
    }
}