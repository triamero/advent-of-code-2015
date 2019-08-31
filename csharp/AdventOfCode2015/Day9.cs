using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015
{
    public class Day9 : IDay
    {
        public string Puzzle
        {
            get
            {
                return Resources.Day9;
            }
        }

        public object GetAnswerPart1(string input)
        {
            var routes = GetInputRoutes(input);

            var uniqueVertices = routes
                .SelectMany(x => new[] { x.From, x.To })
                .Distinct()
                .ToArray();

            var allRoutes = GetAllRoutes(uniqueVertices);

            int minDistance = int.MaxValue;

            foreach (var route in allRoutes)
            {
                var from = route[0];
                var distance = 0;

                for (int i = 1; i < route.Length; i++)
                {
                    var to = route[i];

                    var rd = routes.FirstOrDefault(x => x.From == from && x.To == to);

                    if (rd == null)
                    {
                        distance = -1;
                        break;
                    }

                    distance += rd.Distance;
                    from = to;

                    if (distance > minDistance)
                    {
                        distance = -1;
                        break;
                    }
                }

                if (distance > 0 && distance < minDistance)
                {
                    minDistance = distance;
                }
            }

            return minDistance;
        }

        public object GetAnswerPart2(string input)
        {
            var routes = GetInputRoutes(input);

            var uniqueVertices = routes
                .SelectMany(x => new[] { x.From, x.To })
                .Distinct()
                .ToArray();

            var allRoutes = GetAllRoutes(uniqueVertices);

            int maxDistance = int.MinValue;

            foreach (var route in allRoutes)
            {
                var from = route[0];
                var distance = 0;

                for (int i = 1; i < route.Length; i++)
                {
                    var to = route[i];

                    var rd = routes.FirstOrDefault(x => x.From == from && x.To == to);

                    if (rd == null)
                    {
                        distance = -1;
                        break;
                    }

                    distance += rd.Distance;
                    from = to;
                }

                if (distance > 0 && distance > maxDistance)
                {
                    maxDistance = distance;
                }
            }

            return maxDistance;
        }

        private List<Route> GetInputRoutes(string input)
        {
            var routes = new List<Route>();

            foreach (var line in input.SplitLines())
            {
                var splits1 = line.Split('=');
                var splits = splits1[0].Split(" to ");

                routes.Add(new Route
                {
                    Distance = splits1[1].ToInt(),
                    From = splits[0].Trim(),
                    To = splits[1].Trim()
                });

                routes.Add(new Route
                {
                    Distance = splits1[1].ToInt(),
                    From = splits[1].Trim(),
                    To = splits[0].Trim()
                });
            }

            return routes;
        }

        private IEnumerable<string[]> GetAllRoutes(string[] uniqueVertices)
        {
            var allRoutes = GenerateValues(uniqueVertices)
                .Where(x => x.Length == x.Distinct().Count())
                .ToArray();

            return allRoutes;
        }

        private IEnumerable<string[]> GenerateValues(string[] uniqueVertices)
        {
            var totalCount = Math.Pow(uniqueVertices.Length, uniqueVertices.Length);

            for (var i = 0; i < totalCount; i++)
            {
                var accum = i;

                var result = new string[uniqueVertices.Length];

                for (var j = uniqueVertices.Length - 1; j >= 0; j--)
                {
                    result[j] = uniqueVertices[accum % uniqueVertices.Length];
                    accum /= uniqueVertices.Length;
                }

                yield return result;
            }
        }

        private class Route
        {
            public string From { get; set; }

            public string To { get; set; }

            public int Distance { get; set; }
        }
    }
}
