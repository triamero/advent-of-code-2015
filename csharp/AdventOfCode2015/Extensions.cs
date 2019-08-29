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
    }
}
