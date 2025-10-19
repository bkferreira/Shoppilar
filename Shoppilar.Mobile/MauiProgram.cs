using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Shoppilar.Mobile.DependencyInjection;
using Shoppilar.Mobile.Handlers;
using Shoppilar.Mobile.Utils;

namespace Shoppilar.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("MaterialSymbolsRounded.ttf", "MaterialSymbolsRounded-Regular");
            });

        CustomHandlers.Configure();

        builder.Services.AddProjectServices();

        builder.Services.AddHttpClient("OS.Api", client => { client.BaseAddress = new Uri(Constants.RouteApi); });
        // .AddHttpMessageHandler<AuthenticationDelegatingHandler>();

        builder.Services.AddHttpClient("OS.Auth",
            options => { options.BaseAddress = new Uri(Constants.RouteAuth); });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}