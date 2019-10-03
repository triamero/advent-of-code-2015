using NUnit.Framework;

namespace AdventOfCode2015.Tests
{
    public class Day15Tests
    {
        private const string Input = @"
Butterscotch: capacity -1, durability -2, flavor 6, texture 3, calories 8
Cinnamon: capacity 2, durability 3, flavor -2, texture -1, calories 3";

        [Test(ExpectedResult = 62842880)]
        public int GetAnswerPart1_()
        {
            var result = (int)new Day15().GetAnswerPart1(Input);

            return result;
        }
    }
}
