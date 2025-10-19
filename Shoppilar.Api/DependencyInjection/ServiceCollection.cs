using Shoppilar.Interfaces.App;
using Shoppilar.Interfaces.App.Service;
using Shoppilar.Services.App;

namespace Shoppilar.Api.DependencyInjection;

public static class ServiceCollection
{
    public static void AddServices(this IServiceCollection services)
    {
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