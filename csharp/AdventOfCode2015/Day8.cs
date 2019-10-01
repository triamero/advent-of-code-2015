using System.Text;

namespace AdventOfCode2015
{
    public class Day8 : IDay
    {
        /// <inheritdoc />
        public string Puzzle
        {
            get { return Resources.Day8; }
        }

        /// <inheritdoc />
        public object GetAnswerPart1(string input)
        {
            int result = 0;

            foreach (var line in input.SplitLines())
            {
                int charCount = 0;

                var length = line.Length;

                for (int i = 0; i < length; i++)
                {
                    var symbol = line[i];

                    if (symbol == '\\')
                    {
                        if (i < length - 1)
                        {
                            if (line[i + 1] == '\\' || line[i + 1] == '"')
                            {
                                charCount++;
                                i++;
                                continue;
                            }

                            if (i < length - 3 && line[i + 1] == 'x')
                            {
                                charCount++;
                                i += 3;
                                continue;
                            }
                        }
                    }

                    if (char.IsLetter(symbol))
                    {
                        charCount++;
                    }
                }

                result += line.Length - charCount;
            }

            return result;
        }

        /// <inheritdoc />
        public object GetAnswerPart2(string input)
        {
            int result = 0;

            foreach (var line in input.SplitLines())
            {
                var encoded = Encode(line);

                result += encoded.Length - line.Length;
            }

            return result;
        }

        private static string Encode(string line)
        {
            var sb = new StringBuilder();

            sb.Append('"');

            for (int i = 0; i < line.Length; i++)
            {
                var symbol = line[i];

                if (char.IsLetterOrDigit(symbol))
                {
                    sb.Append(symbol);
                    continue;
                }

                if (symbol == '"')
                {
                    sb.Append("\\\"");
                    continue;
                }

                if (symbol == '\\')
                {
                    sb.Append("\\\\");
                }
            }

            sb.Append('"');

            return sb.ToString();
        }
    }
}
