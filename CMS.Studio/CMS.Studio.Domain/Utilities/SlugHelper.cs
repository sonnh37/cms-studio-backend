using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace CMS.Studio.Domain.Utilities;

public static class SlugHelper
{
    public static string ToSlug(string? title)
    {
        if (string.IsNullOrWhiteSpace(title)) return string.Empty;

        // Convert to lowercase
        var slug = title.ToLowerInvariant();
        Console.WriteLine($"Lowercase: {slug}");

        // Remove accents
        slug = RemoveAccents(slug);
        Console.WriteLine($"Without accents: {slug}");

        // Replace spaces and other characters with hyphens
        slug = Regex.Replace(slug, @"[^a-z0-9\s-]", string.Empty); // Remove non-alphanumeric characters
        Console.WriteLine($"After removing non-alphanumeric characters: {slug}");

        slug = Regex.Replace(slug, @"\s+", " "); // Convert multiple spaces to a single space
        Console.WriteLine($"After converting multiple spaces: {slug}");

        slug = Regex.Replace(slug, @"\s", "-"); // Replace spaces with hyphens
        Console.WriteLine($"Before trimming final slug: {slug}");

        // Remove trailing hyphen if exists
        slug = slug.Trim('-');
        Console.WriteLine($"Final slug: {slug}");

        return slug;
    }

    private static string RemoveAccents(string text)
    {
        if (string.IsNullOrEmpty(text)) return text;

        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                // Special handling for 'đ'
                if (c == 'đ')
                    stringBuilder.Append('d');
                else
                    stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
}