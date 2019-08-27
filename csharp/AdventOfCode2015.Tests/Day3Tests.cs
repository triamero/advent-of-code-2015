using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class Day3Tests
    {
        [TestCase(">", ExpectedResult = 2)]
        [TestCase("^>v<", ExpectedResult = 4)]
        [TestCase("^v^v^v^v^v", ExpectedResult = 2)]
        public int GetAnswerPart1_Test(string input)
        {
            return new Day3().GetAnswerPart1(input);
        }

        [TestCase("^v", ExpectedResult = 3)]
        [TestCase("^>v<", ExpectedResult = 3)]
        [TestCase("^v^v^v^v^v", ExpectedResult = 11)]
        public int GetAnswerPart2_Test(string input)
        {
            return new Day3().GetAnswerPart2(input);
        }
    }
}
