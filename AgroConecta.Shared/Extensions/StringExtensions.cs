namespace AgroConecta.Shared.Extensions;

public static class StringExtensions
{
    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value))
            return value;
        return value.Length > maxLength ? value.Substring(0, maxLength) : value;
    }
}