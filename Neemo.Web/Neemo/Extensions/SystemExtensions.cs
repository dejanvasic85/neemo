using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Neemo
{
    public static class SystemExtensions
    {
        public static void CloneInTo(this object source, object target)
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

        public static IDictionary<string, object> ToDictionary(this object source)
        {
            return source.ToDictionary<object>();
        }

        public static IDictionary<string, T> ToDictionary<T>(this object source)
        {
            Guard.NotNull(source);

            var dictionary = new Dictionary<string, T>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                var value = property.GetValue(source);
                if (value.IsOfType<T>())
                {
                    dictionary.Add(property.Name.Replace('_', '-'), (T)value);
                } 
            }
            return dictionary;
        }

        public static bool IsOfType<T>(this object value)
        {
            return value is T;
        }

    }
}