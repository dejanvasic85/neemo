using System;
using System.Collections.Generic;

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

        public static Dictionary<string, string> ToDictionary(this object source, bool useEmptyProperties = false)
        {
            var propertiesToSet = source.GetType().GetProperties();
            var dictionary = new Dictionary<string, string>();

            foreach (var propertyInfo in propertiesToSet)
            {
                var value = propertyInfo.GetValue(source);
                if (!useEmptyProperties && string.IsNullOrEmpty(value.ToString()))
                {
                    continue;
                }

                dictionary.Add(propertyInfo.Name, value.ToString());
            }
            return dictionary;
        }
    }
}