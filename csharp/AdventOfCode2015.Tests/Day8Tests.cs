using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class Day8Tests
    {
        [TestCase("\"\"", ExpectedResult = 2)]
        [TestCase("\"abc\"", ExpectedResult = 2)]
        [TestCase("\"aaa\\\"aaa\"", ExpectedResult = 3)]
        [TestCase("\"\\x27\"", ExpectedResult = 5)]
        public int GetAnswerPart1(string input)
        {
            var result = (int)new Day8().GetAnswerPart1(input);

            return result;
        }

        [TestCase("\"\"", ExpectedResult = 4)]
        [TestCase("\"abc\"", ExpectedResult = 4)]
        [TestCase("\"aaa\\\"aaa\"", ExpectedResult = 6)]
        [TestCase("\"\\x27\"", ExpectedResult = 5)]
        public int GetAnswerPart2(string input)
        {
            var result = (int)new Day8().GetAnswerPart2(input);

            return result;
        }
    }
}
