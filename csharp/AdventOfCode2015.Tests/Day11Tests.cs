using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class Day11Tests
    {
        [TestCase("hijklmmn", ExpectedResult = null)]
        [TestCase("abbceffg", ExpectedResult = null)]
        [TestCase("abbcegjk", ExpectedResult = null)]
        [TestCase("abcdefgh", ExpectedResult = "abcdffaa")]
        [TestCase("ghijklmn", ExpectedResult = "ghjaabcc")]
        public object GetAnswerPart1_Test(string input)
        {
            return new Day11().GetAnswerPart1(input);
        }

        [TestCase("abc", ExpectedResult = "abd")]
        [TestCase("bz", ExpectedResult = "ca")]
        [TestCase("aaaaazz", ExpectedResult = "aaaabaa")]
        [TestCase("zzz", ExpectedResult = "aaa")]
        public string Increment_Test(string input)
        {
            var array = input.ToCharArray();

            Day11.Increment(array);

            return new string(array);
        }

        [TestCase("vzbxxwvv", ExpectedResult = 1)]
        public int FindMaxStraightSubsequence_Test(string input)
        {
            var array = input.ToCharArray();

            return Day11.FindMaxStraightSubsequence(array);
        }
    }
}
