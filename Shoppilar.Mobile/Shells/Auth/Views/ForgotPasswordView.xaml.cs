using Shoppilar.Mobile.Shells.Auth.ViewModels;

namespace Shoppilar.Mobile.Shells.Auth.Views;

public partial class ForgotPasswordView : ContentPage
{
    private List<Entry> _codeEntries = [];

    public ForgotPasswordView(ForgotPasswordViewModel viewModel)
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
            // 🔹 Avançou do celular → código  OU voltou da senha → código
            // Determina se veio do 1 ou do 3 para animar na direção certa
            var cameFromStep3 = Step3Container.Opacity > 0;

            if (cameFromStep3)
            {
                // Voltando do step 3 → step 2
                await Task.WhenAll(
                    Step3Container.TranslateTo(400, 0, duration, Easing.CubicIn),
                    Step3Container.FadeTo(0)
                );

                Step2Container.TranslationX = -400;
                Step2Container.Opacity = 0;

                await Task.WhenAll(
                    Step2Container.TranslateTo(0, 0, duration, Easing.CubicOut),
                    Step2Container.FadeTo(1)
                );
            }
            else
            {
                // Avançando do step 1 → step 2
                await Task.WhenAll(
                    Step1Container.TranslateTo(-400, 0, duration, Easing.CubicIn),
                    Step1Container.FadeTo(0)
                );

                Step2Container.TranslationX = 400;
                Step2Container.Opacity = 0;

                await Task.WhenAll(
                    Step2Container.TranslateTo(0, 0, duration, Easing.CubicOut),
                    Step2Container.FadeTo(1)
                );
            }

            await Task.Delay(100);
            Code1Entry.Focus();
        }
        else if (step == 1)
        {
            // 🔹 Voltar do código → celular
            await Task.WhenAll(
                Step2Container.TranslateTo(400, 0, duration, Easing.CubicIn),
                Step2Container.FadeTo(0)
            );

            Step1Container.TranslationX = -400;
            Step1Container.Opacity = 0;

            await Task.WhenAll(
                Step1Container.TranslateTo(0, 0, duration, Easing.CubicOut),
                Step1Container.FadeTo(1)
            );
        }
        else if (step == 3)
        {
            // 🔹 Avançar do código → nova senha
            await Task.WhenAll(
                Step2Container.TranslateTo(-400, 0, duration, Easing.CubicIn),
                Step2Container.FadeTo(0)
            );

            Step3Container.TranslationX = 400;
            Step3Container.Opacity = 0;

            await Task.WhenAll(
                Step3Container.TranslateTo(0, 0, duration, Easing.CubicOut),
                Step3Container.FadeTo(1)
            );
        }
        else if (step == 4)
        {
            // 🔹 Nova senha → sucesso
            await Task.WhenAll(
                Step3Container.TranslateTo(-400, 0, duration, Easing.CubicIn),
                Step3Container.FadeTo(0)
            );

            Step4Container.TranslationX = 400;
            Step4Container.Opacity = 0;

            await Task.WhenAll(
                Step4Container.TranslateTo(0, 0, duration, Easing.CubicOut),
                Step4Container.FadeTo(1)
            );
        }
    }
}
