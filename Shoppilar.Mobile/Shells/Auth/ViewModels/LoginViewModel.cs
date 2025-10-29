using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shoppilar.DTOs.Auth.Input;
using Shoppilar.Interfaces.Auth;
using Shoppilar.Mobile.Interfaces;
using Shoppilar.Mobile.Shells.App;
using Shoppilar.Mobile.Shells.Auth.Views;

namespace Shoppilar.Mobile.Shells.Auth.ViewModels;

public partial class LoginViewModel(
    IAuthService authService,
    INavigationService navigationService)
    : ObservableObject
{
    [ObservableProperty] private LoginInput _input = new();

    [RelayCommand]
    public async Task Entrar()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Input.Login) || string.IsNullOrWhiteSpace(Input.Password))
            {
                await Shell.Current.DisplayAlert("Erro", "Preencha e-mail e senha.", "OK");
                return;
            }

            var ret = await authService.LoginAsync(Input);
            if (ret == null)
            {
                await Shell.Current.DisplayAlert("Erro", "Login inválido.", "OK");
                return;
            }

            await MainThread.InvokeOnMainThreadAsync(() => { Application.Current!.Windows[0].Page = new AppShell(); });
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Erro", $"Falha ao entrar: {ex.Message}", "OK");
        }
    }

    [RelayCommand]
    public async Task Register()
    {
        try
        {
            await navigationService.GoToAsync(nameof(RegisterView));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Erro", $"Falha ao entrar: {ex.Message}", "OK");
        }
    }

    [RelayCommand]
    public async Task ForgotPassword()
    {
        try
        {
            await navigationService.GoToAsync(nameof(ForgotPasswordView));
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Erro", $"Falha ao entrar: {ex.Message}", "OK");
        }
    }
}