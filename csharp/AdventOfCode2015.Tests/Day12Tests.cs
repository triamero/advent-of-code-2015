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

        [TestCase("[1,2,3]", ExpectedResult = 6)]
        [TestCase("[1,{\"c\":\"red\",\"b\":2},3]", ExpectedResult = 4)]
        [TestCase("{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}", ExpectedResult = 0)]
        [TestCase("[1,\"red\",5]", ExpectedResult = 6)]
        [TestCase("[\"violet\",{\"e\":\"blue\",\"a\":187,\"c\":119,\"h\":\"yellow\",\"g\":\"red\",\"f\":74,\"i\":25},\"orange\",0,-17,\"yellow\",-23]", ExpectedResult = -40)]
        [TestCase("[\"violet\",{\"a\":187,\"c\":119,\"g\":\"red\",\"f\":74,\"i\":25},\"orange\",{\"a\":12,\"b\":{\"aa\":3,\"bb\":\"red\"}},-17,\"yellow\",-23]", ExpectedResult = -28)]
        public object GetAnswerPart2_Test(string input)
        {
            return new Day12().GetAnswerPart2(input);
        }
    }
}
