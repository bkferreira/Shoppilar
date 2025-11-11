using Shoppilar.Mobile.Shells.Auth.ViewModels;

namespace Shoppilar.Mobile.Shells.Auth.Views;

public partial class RegisterView : ContentPage
{
    private List<Entry> _codeEntries = [];

    public RegisterView(RegisterViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        viewModel.PropertyChanged += async (_, e) =>
        {
            if (e.PropertyName == nameof(viewModel.Step))
                await AnimateStepChange(viewModel.Step);
        };

        Loaded += RegisterCodeEntryBehavior;
    }
    
    private void RegisterCodeEntryBehavior(object? sender, EventArgs e)
    {
        _codeEntries = [Code1Entry, Code2Entry, Code3Entry, Code4Entry, Code5Entry, Code6Entry];

        for (var i = 0; i < _codeEntries.Count; i++)
        {
            var entry = _codeEntries[i];
            var index = i;

            entry.TextChanged += async (_, args) =>
            {
                if (string.IsNullOrEmpty(args.NewTextValue))
                {
                    if (index > 0)
                    {
                        var previous = _codeEntries[index - 1];
                        previous.Focus();

                        await Task.Delay(30);

                        previous.CursorPosition = previous.Text.Length;
                        previous.SelectionLength = 0;
                    }
                }
                else if (args.NewTextValue.Length == 1)
                {
                    if (index < _codeEntries.Count - 1)
                        _codeEntries[index + 1].Focus();
                    else
                        entry.Unfocus();
                }
            };

            entry.TextChanged += (_, args) =>
            {
                if (!string.IsNullOrEmpty(args.NewTextValue) &&
                    !char.IsDigit(args.NewTextValue.Last()))
                    entry.Text = new string(args.NewTextValue.Where(char.IsDigit).ToArray());
            };
        }
    }

    private async Task AnimateStepChange(int step)
    {
        const uint duration = 250;

        if (step == 2)
        {
            await Task.WhenAll(
                FormContainer.TranslateTo(-400, 0, duration, Easing.CubicIn),
                FormContainer.FadeTo(0)
            );

            CodeContainer.TranslationX = 400;
            CodeContainer.Opacity = 0;

            await Task.WhenAll(
                CodeContainer.TranslateTo(0, 0, duration, Easing.CubicOut),
                CodeContainer.FadeTo(1)
            );

            await Task.Delay(100);
            Code1Entry.Focus();
        }
        else if (step == 1)
        {
            await Task.WhenAll(
                CodeContainer.TranslateTo(400, 0, duration, Easing.CubicIn),
                CodeContainer.FadeTo(0)
            );

            FormContainer.TranslationX = -400;
            FormContainer.Opacity = 0;

            await Task.WhenAll(
                FormContainer.TranslateTo(0, 0, duration, Easing.CubicOut),
                FormContainer.FadeTo(1)
            );
        }
        else if (step == 3)
        {
            await Task.WhenAll(
                CodeContainer.TranslateTo(-400, 0, duration, Easing.CubicIn),
                CodeContainer.FadeTo(0)
            );

            SuccessContainer.TranslationX = 400;
            SuccessContainer.Opacity = 0;

            await Task.WhenAll(
                SuccessContainer.TranslateTo(0, 0, duration, Easing.CubicOut),
                SuccessContainer.FadeTo(1)
            );
        }
    }
}