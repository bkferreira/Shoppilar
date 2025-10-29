using CommunityToolkit.Maui;
using FFImageLoading.Maui;
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
            .UseFFImageLoading()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("MaterialSymbolsRounded.ttf", "MaterialSymbolsRounded-Regular");
            });

        CustomHandlers.Configure();

        builder.Services.AddProjectServices();
        builder.Services.AddCacheServices();

        builder.Services.AddHttpClient(Constants.NameApi,
                client => { client.BaseAddress = new Uri(Constants.RouteApi); })
            .AddHttpMessageHandler<AuthHandler>();

        builder.Services.AddHttpClient(Constants.NameAuth,
            options => { options.BaseAddress = new Uri(Constants.RouteAuth); });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}