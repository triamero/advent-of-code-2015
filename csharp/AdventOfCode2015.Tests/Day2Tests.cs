using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class Day2Tests
    {
        [TestCase("2x3x4", ExpectedResult = 58)]
        [TestCase("1x1x10", ExpectedResult = 43)]
        public int GetAnswerPart1_Test(string input)
        {
            var target = new Day2();

            return target.GetAnswerPart1(input);
        }

        [TestCase("2x3x4", ExpectedResult = 34)]
        [TestCase("1x1x10", ExpectedResult = 14)]
        public int GetAnswerPart2_Test(string input)
        {
            var target = new Day2();

            return target.GetAnswerPart2(input);
        }
    }
}
