using System;

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
    }
}