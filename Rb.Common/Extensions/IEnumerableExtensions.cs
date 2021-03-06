﻿using System;
using System.Collections.Generic;

namespace Rb.Common
{
    public static class IEnumerableExtensions
    {
        public static void Foreach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    action(item);
                }
            }
        }
    }
}