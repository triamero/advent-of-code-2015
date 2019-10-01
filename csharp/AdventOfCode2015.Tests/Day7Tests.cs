using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class Day7Tests
    {
        private const string Input = @"
123 -> x
456 -> y
x AND y -> d
x OR y -> e
x LSHIFT 2 -> f
y RSHIFT 2 -> g
NOT x -> h
NOT y -> i";

        [TestCase("d", ExpectedResult = 72)]
        [TestCase("e", ExpectedResult = 507)]
        [TestCase("f", ExpectedResult = 492)]
        [TestCase("g", ExpectedResult = 114)]
        [TestCase("h", ExpectedResult = 65412)]
        [TestCase("i", ExpectedResult = 65079)]
        [TestCase("x", ExpectedResult = 123)]
        [TestCase("y", ExpectedResult = 456)]
        public object GetResultSignals(string key)
        {
            var commands = Day7.GetCommands(Input);

            var result = Day7.GetResultSignals(commands, key);

            return result[key];
        }

    }
}
