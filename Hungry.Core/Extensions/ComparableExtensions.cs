using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hungry.Core.Extensions
{
    public static class ComparableExtensions
    {
        public static bool IsInList<T>(this T value, params T[] list) where T: IComparable
        {
            return list.Contains(value);
        }
    }
}
