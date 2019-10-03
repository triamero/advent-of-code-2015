using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class Day17Tests
    {
        private const string Input = @"
20
15
10
5
5";

        [Test]
        public void GetCountOfCombinations_1()
        {
            var containers = new[] { 20, 15, 10, 5, 5 };

            var combinations = Day17.GetCountOfCombinations(25, containers);

            var totalCombinations = Enumerable
                .Range(0, containers.Length + 1)
                .Sum(x => combinations[25, x]);

            Assert.AreEqual(4, totalCombinations);
        }

        [Test]
        public void GetCountOfCombinations_2()
        {
            var containers = new[] {20, 15, 10, 5};

            var combinations = Day17.GetCountOfCombinations(25, containers);

            var totalCombinations = Enumerable
                .Range(0, containers.Length + 1)
                .Sum(x => combinations[25, x]);

            Assert.AreEqual(2, totalCombinations);
        }

        [Test(ExpectedResult = 5)]
        public object ParseContainers()
        {
            var result = Day17.ParseContainers(Input);

            return result.Length;
        }
    }
}
