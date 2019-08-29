using System;
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
                .ToArray();
        }
    }
}
