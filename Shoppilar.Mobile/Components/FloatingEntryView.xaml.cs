using Shoppilar.Mobile.Utils;

namespace Shoppilar.Mobile.Components;

public partial class FloatingEntryView : ContentView
{
    // 🔹 Texto principal
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(FloatingEntryView), default(string),
            BindingMode.TwoWay);

    // 🔹 Label flutuante
    public static readonly BindableProperty LabelProperty =
        BindableProperty.Create(nameof(Label), typeof(string), typeof(FloatingEntryView), string.Empty);

    // 🔹 Campo de senha
    public static readonly BindableProperty IsPasswordProperty =
        BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(FloatingEntryView), false);

    // 🔹 Tipo de teclado
    public static readonly BindableProperty KeyboardProperty =
        BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(FloatingEntryView), Keyboard.Default);

    // 🔹 Modo data (ativa DatePicker)
    public static readonly BindableProperty IsDateModeProperty =
        BindableProperty.Create(nameof(IsDateMode), typeof(bool), typeof(FloatingEntryView), false);

    // 🔹 Valor de data
    public static readonly BindableProperty DateValueProperty =
        BindableProperty.Create(nameof(DateValue), typeof(DateTime), typeof(FloatingEntryView),
            DateTime.Today, BindingMode.TwoWay);

    public bool IsDateMode
    {
        get => (bool)GetValue(IsDateModeProperty);
        set => SetValue(IsDateModeProperty, value);
    }

    public DateTime DateValue
    {
        get => (DateTime)GetValue(DateValueProperty);
        set => SetValue(DateValueProperty, value);
    }

    // 🔹 Behaviors dinâmicos
    public static readonly BindableProperty InputBehaviorsProperty =
        BindableProperty.Create(
            nameof(InputBehaviors),
            typeof(IList<Behavior<Entry>>),
            typeof(FloatingEntryView),
            defaultValueCreator: _ => new List<Behavior<Entry>>(),
            propertyChanged: OnInputBehaviorsChanged);

    public IList<Behavior<Entry>> InputBehaviors
    {
        get => (IList<Behavior<Entry>>)GetValue(InputBehaviorsProperty);
        set => SetValue(InputBehaviorsProperty, value);
    }

    private static void OnInputBehaviorsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not FloatingEntryView view)
            return;

        if (view.InputEntry == null)
        {
            view.Loaded += (_, _) => ApplyBehaviors(view);
            return;
        }

        ApplyBehaviors(view);
    }

    private static void ApplyBehaviors(FloatingEntryView view)
    {
        view.InputEntry.Behaviors.Clear();

        // 🔹 Campos de senha nunca recebem behaviors
        if (view.IsPassword)
            return;

        if (view.InputBehaviors is { Count: > 0 })
        {
            foreach (var behavior in view.InputBehaviors)
                view.InputEntry.Behaviors.Add(behavior);
        }
    }

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
        Loaded += (_, _) => ApplyBehaviors(this);
    }

    // 🔹 Eventos gerais
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

    // 🔹 Alternar senha
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

        await PasswordIcon.ScaleTo(0.85, 80, Easing.CubicOut);
        await PasswordIcon.ScaleTo(1.0, 80, Easing.CubicIn);
    }

    // 🔹 DatePicker handlers
    private async void OnPickDateClicked(object sender, EventArgs e)
    {
        await Task.Delay(50);
        HiddenDatePicker.Focus();
    }

    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        Text = e.NewDate.ToString("dd/MM/yyyy");
        DateValue = e.NewDate;
    }

    // 🔹 Animações
    private async Task AnimateLabelUpAsync()
    {
        if (_isFloating) return;
        _isFloating = true;

        var x = FloatingLabel.TranslationX;
        await Task.WhenAll(
            FloatingLabel.TranslateTo(x, -18, 160, Easing.CubicOut),
            FloatingLabel.ScaleTo(0.85, 160, Easing.CubicOut),
            FloatingLabel.FadeTo(0.9, 160)
        );
    }

    private async Task AnimateLabelDownAsync()
    {
        if (!_isFloating) return;
        _isFloating = false;

        var x = FloatingLabel.TranslationX;
        await Task.WhenAll(
            FloatingLabel.TranslateTo(x, 0, 160, Easing.CubicOut),
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
            ? Color.FromArgb("#255E77")
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

// 🔹 Animações auxiliares
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
