using System;
using System.Net.Mime;

namespace Neemo
{
    public static class StringExtensions
    {
        public static bool HasValue(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool NotEquals(this string value, string compareTo, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return !string.Equals(value, compareTo, comparison);
        }

        public static string WithoutFileExtension(this string fileName)
        {
            var index = fileName.LastIndexOf('.');

            if (index == -1 || index == 1)
                return fileName;

            return fileName.Substring(0, index);
        }

        public static string TruncateOnWordBoundary(this string content, int maxLength)
        {
            return content.TruncateOnWordBoundary(maxLength, "...");
        }

        public static string TruncateOnWordBoundary(this string content, int maxLength, string suffix)
        {
            if (content.IsNullOrEmpty())
                return String.Empty;

            content = content.StripLineBreaks();

            if (content.Length <= maxLength - 1)
                return content;

            int i = maxLength - 1;
            while (i > 0)
            {
                if (Char.IsWhiteSpace(content[i]))
                    break;
                i--;
            }

            if (i == 0)
            {
                return content;
            }

            return content.Truncate(i, suffix);
        }

        public static string StripLineBreaks(this string content)
        {
            return content.Replace("\n\r", " ").Replace('\n', ' ').Replace('\r', ' ');
        }

        public static string Truncate(this string content, int maxLength, string suffix)
        {
            if (maxLength < 1)
                throw new ArgumentOutOfRangeException("maxLength", maxLength, "MaxLength must be positive");

            if (content.IsNullOrEmpty())
                return String.Empty;

            return (content.Length <= maxLength)
                ? content
                : content.Substring(0, maxLength).TrimEnd() + suffix;
        }

        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static string ToDollarOrDefault(this decimal source, string defaultValue = "N/A")
        {
            if (source > 0)
            {
                return source.ToString("C");
            }
            return defaultValue;
        }

        public static int? ToIntOrNull(this string source)
        {
            int val;
            if (int.TryParse(source, out val))
            {
                return val;
            }
            return null;
        }
    }
}