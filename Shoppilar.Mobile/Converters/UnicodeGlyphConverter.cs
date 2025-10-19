using System.Globalization;

namespace Shoppilar.Mobile.Converters
{
    public class UnicodeGlyphConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string unicodeHex && int.TryParse(unicodeHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int unicode))
            {
                return char.ConvertFromUtf32(unicode); // Converte para caractere literal
            }
            return string.Empty;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
