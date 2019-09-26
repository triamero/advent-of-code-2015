using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015
{
    public static class Extensions
    {
        public static string[] SplitLines(this string input)
        {
            return input
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
        }

        public static int ToInt(this string input)
        {
            if (int.TryParse(input, out var i))
            {
                return i;
            }

            return default(int);
        }

        public static ushort ToUshort(this object obj)
        {
            if (obj != null)
            {
                if (obj is ushort)
                {
                    return (ushort)obj;
                }

                if (ushort.TryParse(obj.ToString(), out var value))
                {
                    return value;
                }
            }
            return default(ushort);
        }

        public static TValue Get<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
        {
            dict.TryGetValue(key, out var value);
            return value;
        }
    }
}
