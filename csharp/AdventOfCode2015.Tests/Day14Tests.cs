using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class Day14Tests
    {
        private const string Input = @"
Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.";

        [TestCase(1, ExpectedResult = 14)]
        [TestCase(10, ExpectedResult = 140)]
        [TestCase(11, ExpectedResult = 140)]
        [TestCase(12, ExpectedResult = 140)]
        [TestCase(138, ExpectedResult = 154)]
        [TestCase(139, ExpectedResult = 168)]
        [TestCase(1000, ExpectedResult = 1120)]
        public int GetReindeerDistance_1(int second)
        {
            var reindeer = new Day14.Reindeer
            {
                Name = "Comet",
                FlySpeed = 14,
                FlyTime = 10,
                RestTime = 127
            };

            return Day14.GetReindeerDistance(reindeer, second);
        }

        [TestCase(1, ExpectedResult = 16)]
        [TestCase(10, ExpectedResult = 160)]
        [TestCase(11, ExpectedResult = 176)]
        [TestCase(12, ExpectedResult = 176)]
        [TestCase(138, ExpectedResult = 176)]
        [TestCase(174, ExpectedResult = 192)]
        [TestCase(175, ExpectedResult = 208)]
        [TestCase(1000, ExpectedResult = 1056)]
        public int GetReindeerDistance_2(int second)
        {
            var reindeer = new Day14.Reindeer
            {
                Name = "Dancer",
                FlySpeed = 16,
                FlyTime = 11,
                RestTime = 162
            };

            return Day14.GetReindeerDistance(reindeer, second);
        }
    }
}
