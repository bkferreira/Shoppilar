using System.Diagnostics;
using Shoppilar.Mobile.Interfaces;

namespace Shoppilar.Mobile.Services;

public class NavigationService : INavigationService
{
    public async Task GoToAsync(string route, bool animate = true)
    {
        try
        {
            await Shell.Current.GoToAsync(route, animate);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[NavigationService] Error navigating to {route}: {ex.Message}");
        }
    }

    public async Task GoToAsync(string route, IDictionary<string, object>? parameters, bool animate = true)
    {
        try
        {
            await Shell.Current.GoToAsync(route, animate, parameters);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[NavigationService] Error navigating to {route}: {ex.Message}");
        }
    }

    public async Task GoBackAsync(bool animate = true)
    {
        try
        {
            await Shell.Current.GoToAsync("..", animate);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[NavigationService] Error going back: {ex.Message}");
        }
    }

    public async Task GoToRootAsync()
    {
        try
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[NavigationService] Error going to root: {ex.Message}");
        }
    }
}