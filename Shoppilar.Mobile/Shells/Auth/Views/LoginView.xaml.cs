using Shoppilar.Mobile.Shells.Auth.ViewModels;

namespace Shoppilar.Mobile.Shells.Auth.Views;

public partial class LoginView : ContentPage
{
    public LoginView(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}