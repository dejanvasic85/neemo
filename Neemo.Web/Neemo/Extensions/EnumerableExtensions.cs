﻿using System;
using System.Collections.Generic;

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
}
