using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shoppilar.DTOs.Auth.Input;
using Shoppilar.Mobile.Interfaces;

namespace Shoppilar.Mobile.Shells.Auth.ViewModels;

public partial class RegisterViewModel(INavigationService navigationService) : ObservableObject
{
    [ObservableProperty] private int step = 1;
    [ObservableProperty] private RegisterInput _input = new();
    [ObservableProperty] private string _confirmPassword = string.Empty;
    [ObservableProperty] private string _birthDisplay = string.Empty;
    [ObservableProperty] private string code1 = string.Empty;
    [ObservableProperty] private string code2 = string.Empty;
    [ObservableProperty] private string code3 = string.Empty;
    [ObservableProperty] private string code4 = string.Empty;
    [ObservableProperty] private string code5 = string.Empty;
    [ObservableProperty] private string code6 = string.Empty;

    [RelayCommand]
    private Task ContinueAsync()
    {
        Step = 2;
        return Task.CompletedTask;
    }

    [RelayCommand]
    private void GoBack() => Step = 1;

    [RelayCommand]
    private async Task VerifyCodeAsync()
    {
        var code = $"{Code1}{Code2}{Code3}{Code4}{Code5}{Code6}";
        if (code.Length != 6)
        {
            await Shell.Current.DisplayAlert("Error", "Enter all 6 digits.", "OK");
            return;
        }

        // Aqui você validaria o código com sua API.
        // Se sucesso:
        Step = 3;
    }

    [RelayCommand]
    private async Task GoToLoginAsync()
    {
        // Volta para a tela de Login (AuthShell)
        await navigationService.GoBackAsync();
    }
}