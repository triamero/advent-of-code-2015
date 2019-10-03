using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    public class Day15 : IDay
    {
        private const int MaxSpoons = 100;

        /// <inheritdoc />
        public string Puzzle
        {
            get { return Resources.Day15; }
        }

        /// <inheritdoc />
        public object GetAnswerPart1(string input)
        {
            var ingredients = ParseIngredients(input);

            var counts = GenerateIngredientCounts(ingredients.Length)
                .Where(x => x.Sum() == 100);

            var first = counts.First();

            return 0;
        }

        /// <inheritdoc />
        public object GetAnswerPart2(string input)
        {
            return 0;
        }

        internal static IEnumerable<int[]> GenerateIngredientCounts(int count)
        {
            var max = MaxSpoons - count + 1;

            var counts = new int[count];

            counts[0] = max;

            for (int i = 1; i < count; i++)
            {
                counts[i] = 1;
            }

            yield return counts;

            int bufferSize = 1;
            int buffer = 1;

            var clone = (int[])counts.Clone();

            while (clone[count - 1] != max)
            {
                int i = 0;

                while (true)
                {
                    if (clone[i] > 1)
                    {
                        break;
                    }

                    i++;
                }

                //var clone = (int[])

                var beforeBufferClone = (int[])clone.Clone();

                clone[i] = clone[i] - bufferSize;
                buffer = bufferSize;
            }
        }

        private static Ingredient[] ParseIngredients(string input)
        {
            var result = new List<Ingredient>();

            var regex = new Regex("([A-Za-z]+): capacity ([-0-9]+), durability ([-0-9]+), flavor ([-0-9]+), texture ([-0-9]+), calories ([-0-9]+)");

            foreach (var line in input.SplitLines())
            {
                var match = regex.Matches(line)[0];

                var ingredient = new Ingredient
                {
                    Name = match.Groups[1].Value,
                    Capacity = match.Groups[2].Value.ToInt(),
                    Durability = match.Groups[3].Value.ToInt(),
                    Flavor = match.Groups[4].Value.ToInt(),
                    Texture = match.Groups[5].Value.ToInt(),
                    Calories = match.Groups[6].Value.ToInt()
                };

                result.Add(ingredient);
            }

            return result.ToArray();
        }

        private class Ingredient
        {
            public string Name { get; set; }

            public int Capacity { get; set; }

            public int Durability { get; set; }

            public int Flavor { get; set; }

            public int Texture { get; set; }

            public int Calories { get; set; }
        }
    }
}
