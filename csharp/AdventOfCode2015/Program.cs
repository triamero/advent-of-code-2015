using System;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("AdventOfCode2015.Tests")]

namespace AdventOfCode2015
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var days = GetDays();

            foreach (var day in days)
            {
                Console.Write(@"{0}. Answers: ", day.GetType().Name);

                Console.Write(@"part1={0}", day.GetAnswerPart1(day.Puzzle));

                Console.Write(@" ");

                Console.WriteLine(@"part2={0}", day.GetAnswerPart2(day.Puzzle));
            }

            Console.WriteLine(@"Press 'X' to win");
            Console.ReadKey();
        }

        private static IDay[] GetDays()
        {
            return new IDay[]
            {
                new Day7(),
            };
        }
    }
}
