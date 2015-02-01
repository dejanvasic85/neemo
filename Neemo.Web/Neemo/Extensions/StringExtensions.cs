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
    }
}