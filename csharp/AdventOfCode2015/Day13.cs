using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    public class Day13 : IDay
    {
        /// <inheritdoc />
        public string Puzzle
        {
            get { return Resources.Day13; }
        }

        /// <inheritdoc />
        public object GetAnswerPart1(string input)
        {
            var humans = GetHumans(input);

            var bestHappiness = humans
                .ToArray()
                .GetAllPermutations()
                .Max(CalculateHappiness);

            return bestHappiness;
        }

        /// <inheritdoc />
        public object GetAnswerPart2(string input)
        {
            var humans = GetHumans(input);

            var me = new Human
            {
                Name = "Me"
            };

            humans.ForEach(x =>
            {
                x.Relations.Add((me.Name, 0));

                me.Relations.Add((x.Name, 0));
            });

            humans.Add(me);

            var bestHappiness = humans
                .ToArray()
                .GetAllPermutations()
                .Max(CalculateHappiness);

            return bestHappiness;
        }

        private static int CalculateHappiness(Human[] permutation)
        {
            int currentHappiness = 0;

            for (int i = 0; i < permutation.Length; i++)
            {
                var me = permutation[i];

                var prev = i == 0 ? permutation[permutation.Length - 1] : permutation[i - 1];
                var happinessWithPrev = me.Relations.First(x => x.Name == prev.Name).Happiness;
                currentHappiness += happinessWithPrev;

                var next = i == permutation.Length - 1 ? permutation[0] : permutation[i + 1];
                var happinessWithNext = me.Relations.First(x => x.Name == next.Name).Happiness;
                currentHappiness += happinessWithNext;
            }

            return currentHappiness;
        }

        private static List<Human> GetHumans(string input)
        {
            var list = new List<Human>();

            var regex = new Regex("([A-Za-z]+) would ([a-z]+) ([0-9]+) happiness units by sitting next to ([A-Za-z]+)");

            foreach (var line in input.SplitLines())
            {
                var matches = regex.Matches(line);

                var match = matches[0];

                var name = match.Groups[1].Value;
                var action = match.Groups[2].Value;
                var happiness = match.Groups[3].Value;
                var to = match.Groups[4].Value;

                var human = list.FirstOrDefault(x => x.Name == name);

                if (human == null)
                {
                    human = new Human
                    {
                        Name = name
                    };

                    list.Add(human);
                }

                var multiplier = action == "gain" ? 1 : -1;

                human.Relations.Add((to, happiness.ToInt() * multiplier));
            }

            return list;
        }

        [DebuggerDisplay("{Name}")]
        private class Human : IComparable<Human>
        {
            /// <summary>
            /// Создает новый экземпляр <see cref="Human"/>
            /// </summary>
            public Human()
            {
                Relations = new List<(string Name, int Happiness)>();
            }


            public string Name { get; set; }

            public List<(string Name, int Happiness)> Relations { get; private set; }

            /// <inheritdoc />
            public int CompareTo(Human other)
            {
                if (ReferenceEquals(this, other)) return 0;
                if (ReferenceEquals(null, other)) return 1;
                return string.Compare(Name, other.Name, StringComparison.Ordinal);
            }
        }
    }
}
