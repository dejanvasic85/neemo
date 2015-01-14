using System;
using System.Collections.Generic;
using System.Reflection;

namespace Neemo
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var i in items)
            {
                action(i);
            }
        }
    }

    public static class SystemExtensions
    {
        public static void CopyPropertiesIfNotSet(this object source, object target)
        {
            var propertiesToSet = source.GetType().GetProperties();

            foreach (var propertyInfo in propertiesToSet)
            {
                var value = propertyInfo.GetValue(target);
                if (value == null)
                {
                    propertyInfo.SetValue(target, propertyInfo.GetValue(source));
                }
            }
        }
    }
}
