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

            var allRoutes = uniqueVertices.GetAllPermutations();

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

            var allRoutes = uniqueVertices.GetAllPermutations();

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

        private static List<Route> GetInputRoutes(string input)
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

        private class Route
        {
            public string From { get; set; }

            public string To { get; set; }

            public int Distance { get; set; }
        }
    }
}
