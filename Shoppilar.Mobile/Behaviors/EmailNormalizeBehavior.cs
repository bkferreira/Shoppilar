namespace Shoppilar.Mobile.Behaviors;

public class EmailNormalizeBehavior : Behavior<Entry>
{
    protected override void OnAttachedTo(Entry entry)
    {
        entry.TextChanged += OnTextChanged;
        base.OnAttachedTo(entry);
    }

    protected override void OnDetachingFrom(Entry entry)
    {
        entry.TextChanged -= OnTextChanged;
        base.OnDetachingFrom(entry);
    }

    private void OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        if (sender is not Entry entry)
            return;

        var text = e.NewTextValue?.Trim().ToLowerInvariant() ?? string.Empty;

        if (text.Contains(" "))
            text = text.Replace(" ", "");

        if (entry.Text != text)
        {
            entry.Text = text;
            entry.CursorPosition = text.Length;
        }
    }
}