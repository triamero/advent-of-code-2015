namespace AdventOfCode2015
{
    public interface IDay
    {
        string Puzzle { get; }

        int GetAnswerPart1(string input);

        int GetAnswerPart2(string input);
    }
}
