using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015
{
    public class Day18 : IDay
    {
        /// <inheritdoc />
        public string Puzzle
        {
            get { return Resources.Day18; }
        }

        /// <inheritdoc />
        public object GetAnswerPart1(string input)
        {
            var deck = ParseInput(input);

            for (int i = 0; i < 100; i++)
            {
                deck = Mutate(deck);
            }

            int sum = deck.EnumerateMatrix().Count(x => x.Value > 0);

            return sum;
        }

        /// <inheritdoc />
        public object GetAnswerPart2(string input)
        {
            var deck = ParseInput(input);

            var maxX = deck.GetLength(1) - 1;
            var maxY = deck.GetLength(0) - 1;

            for (int i = 0; i < 100; i++)
            {
                deck[0, 0] = 1;
                deck[0, maxX] = 1;
                deck[maxY, 0] = 1;
                deck[maxX, maxY] = 1;

                deck = Mutate(deck);
            }

            deck[0, 0] = 1;
            deck[0, maxX] = 1;
            deck[maxY, 0] = 1;
            deck[maxX, maxY] = 1;

            int sum = deck.EnumerateMatrix().Count(x => x.Value > 0);

            return sum;
        }

        internal static int[,] Mutate(int[,] deck)
        {
            var clone = new int[deck.GetLength(0), deck.GetLength(1)];

            foreach (var tuple in deck.EnumerateMatrix())
            {
                var currentState = tuple.Value;

                var neighbors = GetNeighbors(deck, tuple.X, tuple.Y);

                var neighborsOn = neighbors.Count(x => x > 0);

                int newState;

                if (currentState == 0)
                {
                    newState = neighborsOn == 3
                        ? 1
                        : 0;
                }
                else
                {
                    newState = neighborsOn == 2 || neighborsOn == 3
                        ? 1
                        : 0;
                }

                clone[tuple.X, tuple.Y] = newState;
            }

            return clone;
        }

        private static int[] GetNeighbors(int[,] deck, int x, int y)
        {
            var minX = Math.Max(0, x - 1);
            var minY = Math.Max(0, y - 1);

            var maxX = Math.Min(deck.GetLength(0), x + 2);
            var maxY = Math.Min(deck.GetLength(1), y + 2);

            var result = new List<int>();

            for (int y1 = minY; y1 < maxY; y1++)
            {
                for (int x1 = minX; x1 < maxX; x1++)
                {
                    if (x1 == x && y1 == y)
                    {
                        continue;
                    }

                    result.Add(deck[x1, y1]);
                }
            }

            return result.ToArray();
        }

        internal static int[,] ParseInput(string input)
        {
            var lines = input.SplitLines();

            var width = lines[0].Length;
            var height = lines.Length;

            int[,] result = new int[height, width];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var symbol = lines[y][x];

                    if (symbol == '#')
                    {
                        result[y, x] = 1;
                    }
                    else if (symbol == '.')
                    {
                        result[y, x] = 0;
                    }
                }
            }

            return result;
        }
    }
}
