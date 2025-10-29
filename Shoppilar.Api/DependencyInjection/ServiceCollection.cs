using Shoppilar.Interfaces.App;
using Shoppilar.Interfaces.Ext;
using Shoppilar.Services.App;
using Shoppilar.Services.Ext;

namespace Shoppilar.Api.DependencyInjection;

public static class ServiceCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddHttpClient<ISmsService, SmsService>((sp, client) =>
        {
            var config = sp.GetRequiredService<IConfiguration>();
            client.BaseAddress = new Uri(config["Sms:BaseUrl"]!);
            client.DefaultRequestHeaders.Add("auth-key", config["Sms:AuthKey"]!);
            client.Timeout = TimeSpan.FromSeconds(10);
        });
        services.AddScoped<IAdFeaturedService, AdFeaturedService>();
        services.AddScoped<IAdLikeService, AdLikeService>();
        services.AddScoped<IAdPromotionService, AdPromotionService>();
        services.AddScoped<IAdService, AdService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IFavoriteService, FavoriteService>();
        services.AddScoped<IFeedbackService, FeedbackService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<IJobService, JobService>();
        services.AddScoped<IOccurrenceService, OccurrenceService>();
        services.AddScoped<IStateService, StateService>();
        services.AddScoped(typeof(ITypeService<>), typeof(TypeService<>));
        services.AddScoped<IPersonAddressService, PersonAddressService>();
        services.AddScoped<IPersonContactService, PersonContactService>();
        services.AddScoped<IPersonDocumentService, PersonDocumentService>();
        services.AddScoped<IPersonFollowerService, PersonFollowerService>();
        services.AddScoped<IPersonSearchHistoryService, PersonSearchHistoryService>();
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IPersonSocialMediaService, PersonSocialMediaService>();
    }
}