using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class Day1Tests
    {
        [TestCase("(())", ExpectedResult = 0)]
        [TestCase("()()", ExpectedResult = 0)]

        [TestCase("(((", ExpectedResult = 3)]
        [TestCase("(()(()(", ExpectedResult = 3)]
        [TestCase("))(((((", ExpectedResult = 3)]

        [TestCase("())", ExpectedResult = -1)]
        [TestCase("))(", ExpectedResult = -1)]

        [TestCase(")))", ExpectedResult = -3)]
        [TestCase(")())())", ExpectedResult = -3)]
        public int GetAnswerPart1_Test(string input)
        {
            return new Day1().GetAnswerPart1(input);
        }

        [TestCase(")", ExpectedResult = 1)]
        [TestCase("()())", ExpectedResult = 5)]
        public int GetAnswerPart2_Test(string input)
        {
            return new Day1().GetAnswerPart2(input);
        }
    }
}
