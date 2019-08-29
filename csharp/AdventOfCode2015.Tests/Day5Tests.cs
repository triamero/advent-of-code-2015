using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    class Day5Tests
    {
        [TestCase("ugknbfddgicrmopn", ExpectedResult = 1)]
        [TestCase("aaa", ExpectedResult = 1)]
        [TestCase("jchzalrnumimnmhp", ExpectedResult = 0)]
        [TestCase("haegwjzuvuyypxyu", ExpectedResult = 0)]
        [TestCase("dvszwmarrgswjxmb", ExpectedResult = 0)]
        public int GetAnswerPart1_Test(string input)
        {
            return new Day5().GetAnswerPart1(input);
        }

        [TestCase("qjhvhtzxzqqjkmpb", ExpectedResult = 1)]
        [TestCase("xxyxx", ExpectedResult = 1)]
        [TestCase("ieodomkazucvgmuy", ExpectedResult = 0)]
        [TestCase("uurcxstgmygtbstg", ExpectedResult = 0)]
        public int GetAnswerPart2_Test(string input)
        {
            return new Day5().GetAnswerPart2(input);
        }
    }
}
