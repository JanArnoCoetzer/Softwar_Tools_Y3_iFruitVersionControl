namespace SmoothieTruckApp.Services;

internal static class InputValidator
{
    public const int MaxTextLength = 40;

    //returns an error message, or null if the text is safe to save
    public static string? CheckText(string? value, string field)
    {
        if (string.IsNullOrWhiteSpace(value)) return $"Enter a {field}.";

        string text = value.Trim();

        if (text.Length > MaxTextLength) return $"The {field} must be {MaxTextLength} characters or less.";
        if (text.Any(char.IsControl)) return $"The {field} cannot contain line breaks or tabs.";

        return null;
    }
}
