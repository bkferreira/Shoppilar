using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shoppilar.DTOs.Auth.Input;
using Shoppilar.Mobile.Interfaces;

namespace Shoppilar.Mobile.Shells.Auth.ViewModels;

public partial class ForgotPasswordViewModel(INavigationService navigationService) : ObservableObject
{
    [ObservableProperty] private int step = 1;
    [ObservableProperty] private ResetPasswordInput _input = new();

    [ObservableProperty] private string code1 = string.Empty;
    [ObservableProperty] private string code2 = string.Empty;
    [ObservableProperty] private string code3 = string.Empty;
    [ObservableProperty] private string code4 = string.Empty;
    [ObservableProperty] private string code5 = string.Empty;
    [ObservableProperty] private string code6 = string.Empty;
    [ObservableProperty] private string confirmPassword = string.Empty;

    [RelayCommand]
    private async Task SendCodeAsync()
    {
        if (string.IsNullOrWhiteSpace(Input.PhoneNumber))
        {
            await Shell.Current.DisplayAlert("Error", "Please enter your phone number.", "OK");
            return;
        }

        // TODO: call AuthService to send code
        Step = 2;
    }

    [RelayCommand]
    private async Task VerifyCodeAsync()
    {
        var code = $"{Code1}{Code2}{Code3}{Code4}{Code5}{Code6}";
        if (code.Length != 6)
        {
            await Shell.Current.DisplayAlert("Error", "Enter all 6 digits.", "OK");
            return;
        }

        // TODO: validate code with API
        Step = 3;
    }

    [RelayCommand]
    private async Task ChangePasswordAsync()
    {
        if (string.IsNullOrWhiteSpace(Input.NewPassword) || string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            await Shell.Current.DisplayAlert("Error", "Fill all fields.", "OK");
            return;
        }

        if (Input.NewPassword != ConfirmPassword)
        {
            await Shell.Current.DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        // TODO: send password change to API
        Step = 4;
    }

    [RelayCommand]
    private void GoBack() => Step = 1;

    [RelayCommand]
    private void GoBackToCode() => Step = 2;

    [RelayCommand]
    private async Task GoToLoginAsync()
    {
        await navigationService.GoBackAsync();
    }
}