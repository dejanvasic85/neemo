using System;

namespace Neemo
{
    public static class EnumExtensions
    {
        public static TTarget ToEnum<TTarget>(this string value)
        {
            object parsed = Enum.Parse(typeof (TTarget), value);
            return (TTarget) parsed;
        }
    }
}
