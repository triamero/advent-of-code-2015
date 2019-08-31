using System.Linq;

namespace AdventOfCode2015
{
    public class Day11 : IDay
    {
        private static readonly char[] Alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        private static readonly char[] InvalidChars = new[] { 'i', 'o', 'l' };

        public string Puzzle
        {
            get
            {
                return Resources.Day11;
            }
        }

        public object GetAnswerPart1(string input)
        {
            var array = input.ToCharArray();

            while (true)
            {
                Increment(array);

                if (FindMaxStraightSubsequence(array) < 3)
                {
                    continue;
                }

                if (HasInvalidChar(array))
                {
                    continue;
                }

                if (!HasPairs(array))
                {
                    continue;
                }

                break;
            }

            return new string(array);
        }

        public object GetAnswerPart2(string input)
        {
            var first = (string)GetAnswerPart1(input);

            var second = GetAnswerPart1(first);

            return second;
        }

        public static void Increment(char[] array)
        {
            int index = array.Length - 1;

            while (index >= 0)
            {
                var @char = array[index];

                if (@char != 'z')
                {
                    break;
                }

                index--;
            }

            if (index < 0)
            {
                array[0] = 'a';
                index = 0;
            }
            else
            {
                array[index] = (char)(array[index] + 1);
            }

            for (int i = index + 1; i < array.Length; i++)
            {
                array[i] = 'a';
            }
        }

        private static bool HasPairs(char[] array)
        {
            int pairsCount = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                {
                    pairsCount++;
                    i++;
                }
            }

            return pairsCount >= 2;
        }

        private static bool HasInvalidChar(char[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (InvalidChars.Contains(array[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public static int FindMaxStraightSubsequence(char[] array)
        {
            int maxSubsequenceLength = 1;

            int currentSubsequenceLength = 1;
            int prev = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (prev + 1 == array[i])
                {
                    currentSubsequenceLength++;
                }
                else
                {
                    currentSubsequenceLength = 1;
                }

                prev = array[i];

                if (maxSubsequenceLength < currentSubsequenceLength)
                {
                    maxSubsequenceLength = currentSubsequenceLength;
                }

                if (maxSubsequenceLength >= 3)
                {
                    break;
                }
            }

            return maxSubsequenceLength;
        }
    }
}
