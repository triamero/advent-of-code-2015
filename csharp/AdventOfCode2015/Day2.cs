using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015
{
    public class Day2 : IDay
    {
        public string Puzzle
        {
            get
            {
                return Resources.Day2;
            }
        }

        public object GetAnswerPart1(string input)
        {
            int answer = 0;

            foreach (var line in GetLines(input))
            {
                var side1 = line.Lenght * line.Width;
                var side2 = line.Width * line.Height;
                var side3 = line.Height * line.Lenght;

                var minSide = new[] { side1, side2, side3 }.Min();

                answer += 2 * (side1 + side2 + side3) + minSide;
            }

            return answer;
        }

        public object GetAnswerPart2(string input)
        {
            int answer = 0;

            foreach (var line in GetLines(input))
            {
                var perimiter1 = 2 * (line.Lenght + line.Width);
                var perimeter2 = 2 * (line.Width + line.Height);
                var perimeter3 = 2 * (line.Height + line.Lenght);

                var minPerimeter = new[] { perimiter1, perimeter2, perimeter3 }.Min();

                answer += line.Lenght * line.Width * line.Height + minPerimeter;
            }

            return answer;
        }

        private static IEnumerable<(int Lenght, int Width, int Height)> GetLines(string input)
        {
            foreach (var line in input.SplitLines())
            {
                var data = line.Trim().Split('x').Select(x => int.Parse(x)).ToArray();

                yield return (data[0], data[1], data[2]);
            }
        }
    }
}
