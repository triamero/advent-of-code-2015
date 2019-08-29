using System;

namespace AdventOfCode2015
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var days = GetDays();

            foreach (var day in days)
            {
                Console.WriteLine(
                    "{0}. Answers are: part1={1} part2={2}",
                    day.GetType().Name,
                    day.GetAnswerPart1(day.Puzzle),
                    day.GetAnswerPart2(day.Puzzle));
            }

            Console.WriteLine("Press 'X' to win");
            Console.ReadKey();
        }

        private static IDay[] GetDays()
        {
            return new IDay[]
            {
                new Day1(),
                new Day2(),
                new Day3(),
                //new Day4()
                new Day5()
            };
        }
    }
}
