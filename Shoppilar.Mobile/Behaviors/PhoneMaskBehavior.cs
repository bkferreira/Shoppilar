
namespace Shoppilar.Mobile.Behaviors;

public class PhoneMaskBehavior : Behavior<Entry>
{
    private bool _isUpdating;

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
        if (_isUpdating || sender is not Entry entry)
            return;

        var newText = e.NewTextValue ?? string.Empty;

        var numbers = new string(newText.Where(char.IsDigit).ToArray());
        if (numbers.Length == 0)
        {
            entry.Text = string.Empty;
            return;
        }

        if (numbers.Length > 11)
            numbers = numbers[..11];

        var formatted = numbers.Length switch
        {
            <= 2 => numbers,
            <= 6 => $"({numbers[..2]}) {numbers[2..]}",
            <= 10 => $"({numbers[..2]}) {numbers[2..6]}-{numbers[6..]}",
            _ => $"({numbers[..2]}) {numbers[2..7]}-{numbers[7..]}"
        };

        _isUpdating = true;
        entry.Text = formatted;
        entry.CursorPosition = formatted.Length;
        _isUpdating = false;
    }
}