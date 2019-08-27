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
            var target = CreateTarget();

            return target.GetAnswerPart1(input);
        }

        [TestCase(")", ExpectedResult = 1)]
        [TestCase("()())", ExpectedResult = 5)]
        public int GetAnswerPart2_Test(string input)
        {
            var target = CreateTarget();

            return target.GetAnswerPart2(input);
        }

        private Day1 CreateTarget()
        {
            return new Day1();
        }
    }
}
