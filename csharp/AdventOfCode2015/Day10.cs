using System.Text;

namespace AdventOfCode2015
{
    public class Day10 : IDay
    {
        /// <inheritdoc />
        public string Puzzle
        {
            get { return Resources.Day10; }
        }

        /// <inheritdoc />
        public object GetAnswerPart1(string input)
        {
            var line = input;

            for (int i = 0; i < 40; i++)
            {
                line = IterateString(line);
            }

            return line.Length;
        }

        /// <inheritdoc />
        public object GetAnswerPart2(string input)
        {
            var line = input;

            for (int i = 0; i < 50; i++)
            {
                line = IterateString(line);
            }

            return line.Length;
        }

        private static string IterateString(string line)
        {
            var newResult = new StringBuilder();

            int i = 1;

            char symbol = line[0];
            int count = 1;

            while (i < line.Length)
            {
                if (line[i] == symbol)
                {
                    count++;
                }
                else
                {
                    newResult.Append(count).Append(symbol);
                    symbol = line[i];
                    count = 1;
                }

                i++;
            }

            newResult.Append(count).Append(symbol);

            return newResult.ToString();
        }
    }
}
