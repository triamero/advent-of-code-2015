using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015
{
    public class Day5 : IDay
    {
        private static readonly char[] Vowels = new[] { 'a', 'e', 'i', 'o', 'u' };
        private static readonly string[] InvalidPairs = new[] { "ab", "cd", "pq", "xy" };

        public string Puzzle
        {
            get
            {
                return Resources.Day5;
            }
        }

        public object GetAnswerPart1(string input)
        {
            var lines = input.SplitLines();

            int result = 0;

            foreach (var line in lines)
            {
                int vowelCount = line.Count(x => Vowels.Contains(x));

                if (vowelCount < 3)
                {
                    continue;
                }

                if (InvalidPairs.Any(x => line.Contains(x)))
                {
                    continue;
                }

                bool hasTwin = false;

                var prevChar = line[0];

                for (int i = 1; i < line.Length; i++)
                {
                    if (line[i] == prevChar)
                    {
                        hasTwin = true;
                        break;
                    }

                    prevChar = line[i];
                }

                if (!hasTwin)
                {
                    continue;
                }

                result++;
            }

            return result;
        }

        public object GetAnswerPart2(string input)
        {
            var result = 0;

            foreach (var line in input.SplitLines())
            {
                bool firstCondition = false;
                bool secondCondition = false;

                for (int i = 0; i < line.Length - 2; i++)
                {
                    if (!firstCondition)
                    {
                        var str1 = line.Substring(i, 2);
                        var str2 = line.Substring(i + 2);

                        if (str2.Contains(str1))
                        {
                            firstCondition = true;
                        }
                    }

                    if (!secondCondition)
                    {
                        var char1 = line[i];
                        var char3 = line[i + 2];

                        if (char1 == char3)
                        {
                            secondCondition = true;
                        }
                    }

                    if (firstCondition && secondCondition)
                    {
                        result++;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
