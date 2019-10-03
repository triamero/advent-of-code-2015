using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class Day18Tests
    {
        [Test]
        public void ParseInput_()
        {

            var input = @"
.#.#.#
...##.
#....#
..#...
#.#..#";

            var result = Day18.ParseInput(input);

            Assert.AreEqual(5, result.GetLength(0));
            Assert.AreEqual(6, result.GetLength(1));

            Assert.AreEqual(0, result[0, 0]);
            Assert.AreEqual(1, result[0, 1]);
            Assert.AreEqual(0, result[0, 2]);
            Assert.AreEqual(1, result[0, 3]);
            Assert.AreEqual(0, result[0, 4]);
            Assert.AreEqual(1, result[0, 5]);

            Assert.AreEqual(1, result[4, 0]);
            Assert.AreEqual(0, result[4, 1]);
            Assert.AreEqual(1, result[4, 2]);
            Assert.AreEqual(0, result[4, 3]);
            Assert.AreEqual(0, result[4, 4]);
            Assert.AreEqual(1, result[4, 5]);
        }

        [Test]
        public void Mutate_1()
        {
            var input = @"
.#.#.#
...##.
#....#
..#...
#.#..#
####..";

            var deck = Day18.ParseInput(input);

            var mutant = Day18.Mutate(deck);

            Assert.AreEqual(0, mutant[0, 0]);
            Assert.AreEqual(0, mutant[0, 1]);
            Assert.AreEqual(1, mutant[0, 2]);
            Assert.AreEqual(1, mutant[0, 3]);
            Assert.AreEqual(0, mutant[0, 4]);
            Assert.AreEqual(0, mutant[0, 5]);

            mutant = Day18.Mutate(mutant);

            Assert.AreEqual(0, mutant[0, 0]);
            Assert.AreEqual(0, mutant[0, 1]);
            Assert.AreEqual(1, mutant[0, 2]);
            Assert.AreEqual(1, mutant[0, 3]);
            Assert.AreEqual(1, mutant[0, 4]);
            Assert.AreEqual(0, mutant[0, 5]);
        }
    }
}
