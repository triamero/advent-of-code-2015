using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    public class Day16 : IDay
    {
        private static readonly Aunt _tape = new Aunt
        {
            Children = 3,
            Cats = 7,
            Samoyeds = 2,
            Pomeranians = 3,
            Akitas = 0,
            Vizslas = 0,
            Goldfish = 5,
            Trees = 3,
            Cars = 2,
            Perfumes = 1
        };

        /// <inheritdoc />
        public string Puzzle
        {
            get { return Resources.Day16; }
        }

        /// <inheritdoc />
        public object GetAnswerPart1(string input)
        {
            var aunts = ParseInput(input);

            double closestValue = double.MaxValue;
            int closestIndex = -1;

            for (int i = 0; i < aunts.Length; i++)
            {
                var aunt = aunts[i];

                var value = CalculateDistancePart1(_tape, aunt);

                if (value < closestValue)
                {
                    closestValue = value;
                    closestIndex = i;
                }
            }

            return closestIndex + 1;
        }

        /// <inheritdoc />
        public object GetAnswerPart2(string input)
        {
            var aunts = ParseInput(input);

            double closestValue = double.MaxValue;
            int closestIndex = -1;

            for (int i = 0; i < aunts.Length; i++)
            {
                var aunt = aunts[i];

                var value = CalculateDistancePart2(_tape, aunt);

                if (value < closestValue)
                {
                    closestValue = value;
                    closestIndex = i;
                }
            }

            return closestIndex + 1;
        }

        private static double CalculateDistancePart1(Aunt tape, Aunt aunt)
        {
            double sum = 0.0;

            int count = 0;

            if (aunt.Children.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Children);
                count++;
            }

            if (aunt.Cats.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Cats);
                count++;
            }

            if (aunt.Samoyeds.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Samoyeds);
                count++;
            }

            if (aunt.Pomeranians.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Pomeranians);
                count++;
            }

            if (aunt.Akitas.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Akitas);
                count++;
            }

            if (aunt.Vizslas.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Vizslas);
                count++;
            }

            if (aunt.Goldfish.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Goldfish);
                count++;
            }

            if (aunt.Trees.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Trees);
                count++;
            }

            if (aunt.Cars.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Cars);
                count++;
            }

            if (aunt.Perfumes.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Perfumes);
                count++;
            }

            return sum / count;
        }

        private static double CalculateDistancePart2(Aunt tape, Aunt aunt)
        {
            double sum = 0.0;

            int count = 0;

            if (aunt.Children.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Children);
                count++;
            }

            if (aunt.Cats.HasValue)
            {
                if (aunt.Cats > tape.Cats)
                {
                    sum -= 1;
                }
                else
                {
                    sum += 1;
                }

                count++;
            }

            if (aunt.Samoyeds.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Samoyeds);
                count++;
            }

            if (aunt.Pomeranians.HasValue)
            {
                if (aunt.Pomeranians < tape.Pomeranians)
                {
                    sum -= 1;
                }
                else
                {
                    sum += 1;
                }

                count++;
            }

            if (aunt.Akitas.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Akitas);
                count++;
            }

            if (aunt.Vizslas.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Vizslas);
                count++;
            }

            if (aunt.Goldfish.HasValue)
            {
                if (aunt.Goldfish < tape.Goldfish)
                {
                    sum -= 1;
                }
                else
                {
                    sum += 1;
                }

                count++;
            }

            if (aunt.Trees.HasValue)
            {
                if (aunt.Trees > tape.Trees)
                {
                    sum -= 1;
                }
                else
                {
                    sum += 1;
                }

                count++;
            }

            if (aunt.Cars.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Cars);
                count++;
            }

            if (aunt.Perfumes.HasValue)
            {
                sum += CalculateSingleDistance(tape, aunt, x => x.Perfumes);
                count++;
            }

            return sum / count;
        }

        private static double CalculateSingleDistance(Aunt tape, Aunt aunt, Func<Aunt, int?> selector)
        {
            var tapeValue = selector(tape);
            var auntValue = selector(aunt);

            return Math.Abs((double) (tapeValue - auntValue).GetValueOrDefault());
        }

        private static Aunt[] ParseInput(string input)
        {
            var result = new List<Aunt>();

            var numberRegex = new Regex("^Sue ([0-9]+):");

            foreach (var line in input.SplitLines())
            {
                var match = numberRegex.Matches(line)[0];

                var aunt = new Aunt();

                var parameters = line.Replace(match.Groups[0].Value, "");

                var splits = parameters.Split(',');

                foreach (var s in splits)
                {
                    var keyValue = s.Split(':');

                    var key = keyValue[0].Trim();
                    var value = keyValue[1].Trim().ToInt();

                    switch (key)
                    {
                        case "children":
                            aunt.Children = value;
                            break;
                        case "cats":
                            aunt.Cats = value;
                            break;
                        case "samoyeds":
                            aunt.Samoyeds = value;
                            break;
                        case "pomeranians":
                            aunt.Pomeranians = value;
                            break;
                        case "akitas":
                            aunt.Akitas = value;
                            break;
                        case "vizslas":
                            aunt.Vizslas = value;
                            break;
                        case "goldfish":
                            aunt.Goldfish = value;
                            break;
                        case "trees":
                            aunt.Trees = value;
                            break;
                        case "cars":
                            aunt.Cars = value;
                            break;
                        case "perfumes":
                            aunt.Perfumes = value;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(value), @"Unknown value");
                    }
                }

                result.Add(aunt);
            }

            return result.ToArray();
        }

        private class Aunt
        {
            public int? Children { get; set; }

            public int? Cats { get; set; }

            public int? Samoyeds { get; set; }

            public int? Pomeranians { get; set; }

            public int? Akitas { get; set; }

            public int? Vizslas { get; set; }

            public int? Goldfish { get; set; }

            public int? Trees { get; set; }

            public int? Cars { get; set; }

            public int? Perfumes { get; set; }
        }
    }
}
