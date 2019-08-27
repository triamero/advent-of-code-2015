using System;
using System.Collections.Generic;

namespace AdventOfCode2015
{
    public class Day3 : IDay
    {
        public string Puzzle
        {
            get
            {
                return Resources.Day3;
            }
        }

        public int GetAnswerPart1(string input)
        {
            var uniquePoints = WalkByInstructions(input, 0, 1);

            return uniquePoints.Count;
        }

        public int GetAnswerPart2(string input)
        {
            var uniquePoints1 = WalkByInstructions(input, 0, 2);
            var uniquePoints2 = WalkByInstructions(input, 1, 2);

            uniquePoints1.UnionWith(uniquePoints2);

            return uniquePoints1.Count;
        }

        private HashSet<(int X, int Y)> WalkByInstructions(string input, int startIndex, int increment)
        {
            var uniquePoints = CreateSet();

            int x = 0, y = 0;

            for (int i = startIndex; i < input.Length; i+= increment)
            {
                var @char = input[i];

                if (@char == 'v')
                {
                    y++;
                }
                else if (@char == '>')
                {
                    x++;
                }
                else if (@char == '^')
                {
                    y--;
                }
                else if (@char == '<')
                {
                    x--;
                }

                uniquePoints.Add((x, y));
            }

            return uniquePoints;
        }

        private static HashSet<(int X, int Y)> CreateSet()
        {
            return new HashSet<(int X, int Y)>
            {
                (0, 0)
            };
        }
    }
}
