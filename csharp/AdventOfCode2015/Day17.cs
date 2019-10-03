using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015
{
    public class Day17 : IDay
    {
        private const int Liters = 150;

        /// <inheritdoc />
        public string Puzzle
        {
            get { return Resources.Day17; }
        }

        /// <inheritdoc />
        public object GetAnswerPart1(string input)
        {
            var containers = ParseContainers(input);

            var counts = GetCountOfCombinations(Liters, containers);

            var totalCombinations = Enumerable
                .Range(0, containers.Length + 1)
                .Sum(n => counts[Liters, n]);

            return totalCombinations;
        }

        /// <inheritdoc />
        public object GetAnswerPart2(string input)
        {
            var containers = ParseContainers(input);

            var counts = GetCountOfCombinations(Liters, containers);

            var min = Enumerable.Range(0, containers.Length)
                .Where(i => counts[Liters, i] > 0)
                .Min();

            return counts[Liters, min];
        }

        internal static int[,] GetCountOfCombinations(int liters, int[] sizes)
        {
            var counts = new int [liters + 1, sizes.Length + 1];

            counts[0, 0] = 1;

            foreach (var size in sizes)
            {
                for (int v = liters - size; v >= 0; v--)
                {
                    for (int n = sizes.Length; n > 0; n--)
                    {
                        counts[v + size, n] += counts[v, n - 1];
                    }
                }
            }

            return counts;
        }

        internal static int[] ParseContainers(string input)
        {
            var result = new List<int>();

            foreach (var line in input.SplitLines())
            {
                result.Add(line.ToInt());
            }

            return result.ToArray();
        }
    }
}
