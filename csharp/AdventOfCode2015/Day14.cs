using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    public class Day14 : IDay
    {
        /// <inheritdoc />
        public string Puzzle
        {
            get { return Resources.Day14; }
        }

        /// <inheritdoc />
        public object GetAnswerPart1(string input)
        {
            var reindeers = ParseReindeers(input);

            int maxDistance = reindeers.Max(x => GetReindeerDistance(x, 2503));

            // > 2624
            // = 2655

            return maxDistance;
        }

        /// <inheritdoc />
        public object GetAnswerPart2(string input)
        {
            var reindeers = ParseReindeers(input).ToArray();

            var points = new Dictionary<string, int>();

            foreach (var reindeer in reindeers)
            {
                points[reindeer.Name] = 0;
            }

            for (int i = 1; i <= 2503; i++)
            {
                var distances = reindeers
                    .Select(x => new
                    {
                        x.Name,
                        Distance = GetReindeerDistance(x, i)
                    })
                    .ToArray();

                var maxDistance = distances.Max(x => x.Distance);

                var othersWithMaxDistance = distances.Where(x => x.Distance == maxDistance).ToArray();

                foreach (var reindeer in othersWithMaxDistance)
                {
                    points[reindeer.Name] += 1;
                }
            }

            return points.Max(x => x.Value);
        }

        internal static int GetReindeerDistance(Reindeer reindeer, int seconds)
        {
            int distance = 0;

            bool isFlying = true;

            int i = 0;

            while (i <= seconds)
            {
                if (isFlying)
                {
                    distance += reindeer.FlySpeed * Math.Min(reindeer.FlyTime, seconds - i);
                    i += reindeer.FlyTime;
                    isFlying = false;
                }
                else
                {
                    i += reindeer.RestTime;
                    isFlying = true;
                }
            }

            return distance;
        }

        private static IEnumerable<Reindeer> ParseReindeers(string input)
        {
            var result = new List<Reindeer>();

            var regex = new Regex("([A-Za-z]+) can fly ([0-9]+) km/s for ([0-9]+) seconds, but then must rest for ([0-9]+) seconds");

            foreach (var line in input.SplitLines())
            {
                var match = regex.Matches(line)[0];

                result.Add(new Reindeer
                {
                    Name = match.Groups[1].Value,
                    FlySpeed = match.Groups[2].Value.ToInt(),
                    FlyTime = match.Groups[3].Value.ToInt(),
                    RestTime = match.Groups[4].Value.ToInt()
                });
            }

            return result;
        }

        [DebuggerDisplay("{Name}")]
        internal class Reindeer
        {
            public string Name { get; set; }

            public int FlySpeed { get; set; }

            public int FlyTime { get; set; }

            public int RestTime { get; set; }
        }
    }
}
