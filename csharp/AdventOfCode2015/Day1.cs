namespace AdventOfCode2015
{
    public class Day1 : IDay
    {
        public string Puzzle
        {
            get
            {
                return Resources.Day1;
            }
        }

        public object GetAnswerPart1(string input)
        {
            int position = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var @char = input[i];

                if (@char == '(')
                {
                    position++;
                }
                else if (@char == ')')
                {
                    position--;
                }
            }

            return position;
        }

        public object GetAnswerPart2(string input)
        {
            int position = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var @char = input[i];

                if (@char == '(')
                {
                    position++;
                }
                else if (@char == ')')
                {
                    position--;
                }

                if(position < 0)
                {
                    return i + 1;
                }
            }

            return 0;
        }
    }
}
