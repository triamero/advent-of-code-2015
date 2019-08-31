using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class Day4Tests
    {
        [Ignore("Too long")]
        [TestCase("abcdef", ExpectedResult = 609043)]
        [TestCase("pqrstuv", ExpectedResult = 1048970)]
        public object GetAnswerPart1_Test(string input)
        {
            return new Day4().GetAnswerPart1(input);
        }

        [Ignore("Too long")]
        [TestCase("abcdef", ExpectedResult = 6742839)]
        [TestCase("pqrstuv", ExpectedResult = 5714438)]
        public object GetAnswerPart2_Test(string input)
        {
            return new Day4().GetAnswerPart2(input);
        }
    }
}
