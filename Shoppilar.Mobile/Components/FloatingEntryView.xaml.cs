using Shoppilar.Mobile.Utils;

namespace Shoppilar.Mobile.Components;

public partial class FloatingEntryView : ContentView
{
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(FloatingEntryView), default(string),
            BindingMode.TwoWay);

    public static readonly BindableProperty LabelProperty =
        BindableProperty.Create(nameof(Label), typeof(string), typeof(FloatingEntryView), string.Empty);

    public static readonly BindableProperty IsPasswordProperty =
        BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(FloatingEntryView), false);

    public static readonly BindableProperty KeyboardProperty =
        BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(FloatingEntryView), Keyboard.Default);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    public bool IsPassword
    {
        get => (bool)GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }

    public Keyboard Keyboard
    {
        get => (Keyboard)GetValue(KeyboardProperty);
        set => SetValue(KeyboardProperty, value);
    }

    private bool _isFloating;
    private bool _isPasswordVisible;

    public FloatingEntryView()
    {
        InitializeComponent();
    }

    private async void OnFocused(object sender, FocusEventArgs e)
    {
        await AnimateLabelUpAsync();
        AnimateBorderColor(true);
    }

    private async void OnUnfocused(object sender, FocusEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Text))
            await AnimateLabelDownAsync();

        AnimateBorderColor(false);
    }

    private async void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(Text))
            await AnimateLabelUpAsync();
        else if (!_isFloating)
            await AnimateLabelDownAsync();
    }

    private void OnCompleted(object sender, EventArgs e)
    {
        InputEntry.Unfocus();
    }

    // 🔹 Clique no ícone (Image com TapGesture)
    private async void OnPasswordIconTapped(object? sender, TappedEventArgs e)
    {
        _isPasswordVisible = !_isPasswordVisible;
        InputEntry.IsPassword = !_isPasswordVisible;

        var icon = _isPasswordVisible
            ? MaterialIcons.EyeOn
            : MaterialIcons.EyeOff;

        var color = Application.Current!.RequestedTheme == AppTheme.Dark
            ? Color.FromArgb("#2A2A2A")
            : Color.FromArgb("#D0D0D0");

        PasswordIcon.Source = new FontImageSource
        {
            FontFamily = MaterialIcons.TypeIcon,
            Glyph = icon,
            Color = color,
            Size = 25
        };

        // 💫 Pequena animação no clique
        await PasswordIcon.ScaleTo(0.85, 80, Easing.CubicOut);
        await PasswordIcon.ScaleTo(1.0, 80, Easing.CubicIn);
    }

    private async Task AnimateLabelUpAsync()
    {
        if (_isFloating) return;
        _isFloating = true;

        await Task.WhenAll(
            FloatingLabel.TranslateTo(0, -8, 160, Easing.CubicOut),
            FloatingLabel.ScaleTo(0.85, 160, Easing.CubicOut),
            FloatingLabel.FadeTo(0.9, 160)
        );
    }

    private async Task AnimateLabelDownAsync()
    {
        if (!_isFloating) return;
        _isFloating = false;

        await Task.WhenAll(
            FloatingLabel.TranslateTo(0, 14, 160, Easing.CubicOut),
            FloatingLabel.ScaleTo(1.0, 160, Easing.CubicOut),
            FloatingLabel.FadeTo(1, 160)
        );
    }

    private async void AnimateBorderColor(bool focused)
    {
        if (Content is not Border border)
            return;

        var from = (border.Stroke as SolidColorBrush)?.Color
                   ?? (Application.Current!.RequestedTheme == AppTheme.Dark
                       ? Color.FromArgb("#2A2A2A")
                       : Color.FromArgb("#D0D0D0"));

        var to = focused
            ? Color.FromArgb("#007BFF")
            : (Application.Current!.RequestedTheme == AppTheme.Dark
                ? Color.FromArgb("#2A2A2A")
                : Color.FromArgb("#D0D0D0"));

        double fromThickness = border.StrokeThickness;
        double toThickness = focused ? 1.5 : 0.5;

        await Task.WhenAll(
            this.ColorTo(from, to, c => border.Stroke = new SolidColorBrush(c), 120),
            border.AnimateThickness(fromThickness, toThickness, 120)
        );
    }
}

public static class ColorAnimationExtensions
{
    public static async Task ColorTo(this VisualElement element, Color from, Color to, Action<Color> callback,
        uint length = 250)
    {
        var animation = new Animation(v =>
        {
            var r = (float)(from.Red + (to.Red - from.Red) * v);
            var g = (float)(from.Green + (to.Green - from.Green) * v);
            var b = (float)(from.Blue + (to.Blue - from.Blue) * v);

            callback(new Color(r, g, b));
        });

        animation.Commit(element, "ColorTo", 16, length, Easing.CubicInOut);
        await Task.Delay((int)length);
    }

    public static async Task AnimateThickness(this Border border, double from, double to, uint duration)
    {
        var animation = new Animation(v => border.StrokeThickness = from + (to - from) * v);
        animation.Commit(border, "ThicknessTo", 16, duration, Easing.CubicInOut);
        await Task.Delay((int)duration);
    }
}