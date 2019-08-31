using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class Day12Tests
    {
        [TestCase("[1,2,3]", ExpectedResult = 6)]
        [TestCase("{\"a\":2,\"b\":4}", ExpectedResult = 6)]
        [TestCase("[[[3]]]", ExpectedResult = 3)]
        [TestCase("{\"a\":{\"b\":4},\"c\":-1}", ExpectedResult = 3)]
        [TestCase("{\"a\":[-1,1]}", ExpectedResult = 0)]
        [TestCase("[-1,{\"a\":1}]", ExpectedResult = 0)]
        [TestCase("[]", ExpectedResult = 0)]
        [TestCase("{}", ExpectedResult = 0)]
        public object GetAnswerPart1_Test(string input)
        {
            return new Day12().GetAnswerPart1(input);
        }
    }
}
