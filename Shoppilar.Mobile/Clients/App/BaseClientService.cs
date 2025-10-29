using Shoppilar.Mobile.Utils;

namespace Shoppilar.Mobile.Clients.App;

public class BaseClientService(IHttpClientFactory httpClientFactory)
{
    protected readonly HttpClient HttpClient = httpClientFactory.CreateClient(Constants.NameApi);
}