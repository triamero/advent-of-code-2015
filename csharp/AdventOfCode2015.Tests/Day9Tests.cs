using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class Day9Tests
    {
        private const string TestData =
            @"
London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141";

        [Test(ExpectedResult = 605)]
        public int GetAnswerPart1_Test()
        {
            return new Day9().GetAnswerPart1(TestData);
        }
    }
}
