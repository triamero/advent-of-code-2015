using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class ExtensionsTests
    {
        [Test]
        public void GetAllPermitations_Simple()
        {
            var value = new[] { 1, 2, 3, 4 };

            var permutations = value.GetAllPermutations().ToArray();

            Assert.AreEqual(24, permutations.Length);

            Assert.IsTrue(Contains(permutations, new[] { 1, 2, 3, 4 }));
            Assert.IsTrue(Contains(permutations, new[] { 1, 2, 4, 3 }));
            Assert.IsTrue(Contains(permutations, new[] { 1, 3, 2, 4 }));
            Assert.IsTrue(Contains(permutations, new[] { 1, 3, 4, 2 }));
            Assert.IsTrue(Contains(permutations, new[] { 1, 4, 2, 3 }));
            Assert.IsTrue(Contains(permutations, new[] { 1, 4, 3, 2 }));

            Assert.IsTrue(Contains(permutations, new[] { 2, 1, 3, 4 }));
            Assert.IsTrue(Contains(permutations, new[] { 2, 1, 4, 3 }));
            Assert.IsTrue(Contains(permutations, new[] { 2, 3, 1, 4 }));
            Assert.IsTrue(Contains(permutations, new[] { 2, 3, 4, 1 }));
            Assert.IsTrue(Contains(permutations, new[] { 2, 4, 1, 3 }));
            Assert.IsTrue(Contains(permutations, new[] { 2, 4, 3, 1 }));

            Assert.IsTrue(Contains(permutations, new[] { 3, 1, 2, 4 }));
            Assert.IsTrue(Contains(permutations, new[] { 3, 1, 4, 2 }));
            Assert.IsTrue(Contains(permutations, new[] { 3, 2, 1, 4 }));
            Assert.IsTrue(Contains(permutations, new[] { 3, 2, 4, 1 }));
            Assert.IsTrue(Contains(permutations, new[] { 3, 4, 1, 2 }));
            Assert.IsTrue(Contains(permutations, new[] { 3, 4, 2, 1 }));

            Assert.IsTrue(Contains(permutations, new[] { 4, 1, 2, 3 }));
            Assert.IsTrue(Contains(permutations, new[] { 4, 1, 3, 2 }));
            Assert.IsTrue(Contains(permutations, new[] { 4, 2, 1, 3 }));
            Assert.IsTrue(Contains(permutations, new[] { 4, 2, 3, 1 }));
            Assert.IsTrue(Contains(permutations, new[] { 4, 3, 1, 2 }));
            Assert.IsTrue(Contains(permutations, new[] { 4, 3, 2, 1 }));
        }

        [TestCase(1, 1, ExpectedResult = 0)]
        [TestCase(2, 1, ExpectedResult = 1)]
        [TestCase(5, 11, ExpectedResult = -1)]
        public int CompareTo_Int(int first, int second)
        {
            return first.CompareTo(second);
        }

        private static bool Contains<T>(IEnumerable<T[]> collection, T[] shouldBeInCollection) where T : IComparable<T>
        {
            foreach (var item in collection)
            {
                if (item.Length != shouldBeInCollection.Length)
                {
                    continue;
                }

                bool allEqual = true;

                for (int i = 0; i < item.Length; i++)
                {
                    if (item[i].CompareTo(shouldBeInCollection[i]) != 0)
                    {
                        allEqual = false;
                        break;
                    }
                }

                if (!allEqual)
                {
                    continue;
                }

                return true;
            }

            return false;
        }
    }
}
