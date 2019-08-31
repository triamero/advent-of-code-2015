namespace AdventOfCode2015
{
    public interface IDay
    {
        string Puzzle { get; }

        object GetAnswerPart1(string input);

        object GetAnswerPart2(string input);
    }
}
