namespace Shoppilar.Mobile.Interfaces;

public interface INavigationService
{
    Task GoToAsync(string route, bool animate = true);
    Task GoToAsync(string route, IDictionary<string, object>? parameters, bool animate = true);
    Task GoBackAsync(bool animate = true);
    Task GoToRootAsync();
}