using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class Day10Tests
    {
        [TestCase("1", ExpectedResult = 82350)]
        [TestCase("11", ExpectedResult = 107312)]
        [TestCase("21", ExpectedResult = 139984)]
        [TestCase("1211", ExpectedResult = 182376)]
        public int GetAnswerPart1_(string input)
        {
            var result = (int)new Day10().GetAnswerPart1(input);

            return result;
        }

        [TestCase("1", ExpectedResult = 1166642)]
        [TestCase("11", ExpectedResult = 1520986)]
        [TestCase("21", ExpectedResult = 1982710)]
        [TestCase("1211", ExpectedResult = 2584304)]
        public int GetAnswerPart2_(string input)
        {
            var result = (int)new Day10().GetAnswerPart2(input);

            return result;
        }
    }
}
