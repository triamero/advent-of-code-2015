using System;
using System.Collections.Generic;
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

            int maxTotal = int.MinValue;

            int max = MaxSpoons;

            for (int a = 0; a < max; a++)
            {
                for (int b = 0; b < max; b++)
                {
                    for (int c = 0; c < max; c++)
                    {
                        for (int d = 0; d < max; d++)
                        {
                            if (a + b + c + d != 100)
                            {
                                continue;
                            }

                            var totalCapacity = a * ingredients[0].Capacity
                                            + b * ingredients[1].Capacity
                                            + c * ingredients[2].Capacity
                                            + d * ingredients[3].Capacity;

                            var totalDurability = a * ingredients[0].Durability
                                              + b * ingredients[1].Durability
                                              + c * ingredients[2].Durability
                                              + d * ingredients[3].Durability;

                            var totalFlavor = a * ingredients[0].Flavor
                                              + b * ingredients[1].Flavor
                                              + c * ingredients[2].Flavor
                                              + d * ingredients[3].Flavor;

                            var totalTexture = a * ingredients[0].Texture
                                          + b * ingredients[1].Texture
                                          + c * ingredients[2].Texture
                                          + d * ingredients[3].Texture;


                            var total = Math.Max(totalCapacity, 0)
                                        * Math.Max(totalDurability, 0)
                                        * Math.Max(totalFlavor, 0)
                                        * Math.Max(totalTexture, 0);

                            if (total > maxTotal)
                            {
                                maxTotal = total;
                            }
                        }
                    }
                }
            }

            return maxTotal;
        }

        /// <inheritdoc />
        public object GetAnswerPart2(string input)
        {
            var ingredients = ParseIngredients(input);

            int maxTotal = int.MinValue;

            int max = MaxSpoons;

            for (int a = 0; a < max; a++)
            {
                for (int b = 0; b < max; b++)
                {
                    for (int c = 0; c < max; c++)
                    {
                        for (int d = 0; d < max; d++)
                        {
                            if (a + b + c + d != 100)
                            {
                                continue;
                            }

                            var calories = a * ingredients[0].Calories
                                           + b * ingredients[1].Calories
                                           + c * ingredients[2].Calories
                                           + d * ingredients[3].Calories;

                            if (calories != 500)
                            {
                                continue;
                            }

                            var totalCapacity = a * ingredients[0].Capacity
                                            + b * ingredients[1].Capacity
                                            + c * ingredients[2].Capacity
                                            + d * ingredients[3].Capacity;

                            var totalDurability = a * ingredients[0].Durability
                                              + b * ingredients[1].Durability
                                              + c * ingredients[2].Durability
                                              + d * ingredients[3].Durability;

                            var totalFlavor = a * ingredients[0].Flavor
                                              + b * ingredients[1].Flavor
                                              + c * ingredients[2].Flavor
                                              + d * ingredients[3].Flavor;

                            var totalTexture = a * ingredients[0].Texture
                                          + b * ingredients[1].Texture
                                          + c * ingredients[2].Texture
                                          + d * ingredients[3].Texture;


                            var total = Math.Max(totalCapacity, 0)
                                        * Math.Max(totalDurability, 0)
                                        * Math.Max(totalFlavor, 0)
                                        * Math.Max(totalTexture, 0);

                            if (total > maxTotal)
                            {
                                maxTotal = total;
                            }
                        }
                    }
                }
            }

            return maxTotal;
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

        internal class Ingredient
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
