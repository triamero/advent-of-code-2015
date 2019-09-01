using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2015
{
    public class Day6 : IDay
    {
        public string Puzzle
        {
            get
            {
                return Resources.Day6;
            }
        }

        public object GetAnswerPart1(string input)
        {
            var matrix = new int[1000, 1000];

            foreach (var command in GetCommands(input))
            {
                int? newValue;

                switch (command.Operation)
                {
                    case "ton":
                        newValue = 1;
                        break;
                    case "tof":
                        newValue = 0;
                        break;
                    default:
                        newValue = null;
                        break;
                }

                for (int i = command.FromX; i <= command.ToX; i++)
                {
                    for (int j = command.FromY; j <= command.ToY; j++)
                    {
                        if (newValue.HasValue)
                        {
                            matrix[i, j] = newValue.Value;
                        }
                        else
                        {
                            if (matrix[i, j] == 1)
                            {
                                matrix[i, j] = 0;
                            }
                            else
                            {
                                matrix[i, j] = 1;
                            }
                        }
                    }
                }
            }

            int result = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result += matrix[i, j];
                }
            }

            return result;
        }

        public object GetAnswerPart2(string input)
        {
            var matrix = new int[1000, 1000];

            foreach (var command in GetCommands(input))
            {
                int? newValue;

                switch (command.Operation)
                {
                    case "ton":
                        newValue = 1;
                        break;
                    case "tof":
                        newValue = 0;
                        break;
                    default:
                        newValue = null;
                        break;
                }

                for (int i = command.FromX; i <= command.ToX; i++)
                {
                    for (int j = command.FromY; j <= command.ToY; j++)
                    {
                        if (newValue == 1)
                        {
                            matrix[i, j] = matrix[i, j] + 1;
                        }

                        if (newValue == 0)
                        {
                            if (matrix[i, j] > 0)
                            {
                                matrix[i, j] = matrix[i, j] - 1;
                            }
                        }

                        if (newValue == null)
                        {
                            matrix[i, j] = matrix[i, j] + 2;
                        }
                    }
                }
            }

            int result = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result += matrix[i, j];
                }
            }

            return result;
        }

        private static IEnumerable<Command> GetCommands(string input)
        {
            var commands = input.SplitLines();

            var alfabet = new Regex("[a-z]");

            foreach (var line in commands)
            {
                var cmd = new Command();

                if (line.StartsWith("turn on"))
                    cmd.Operation = "ton";
                if (line.StartsWith("turn off"))
                    cmd.Operation = "tof";
                if (line.StartsWith("toggle"))
                    cmd.Operation = "tog";

                var line1 = alfabet.Replace(line, "").Trim().Split(' ');

                var from = line1[0];
                var to = line1[2];

                cmd.FromX = @from.Split(',')[0].ToInt();
                cmd.FromY = @from.Split(',')[1].ToInt();

                cmd.ToX = to.Split(',')[0].ToInt();
                cmd.ToY = to.Split(',')[1].ToInt();

                yield return cmd;
            }
        }

        private class Command
        {
            public string Operation { get; set; }

            public int FromX { get; set; }

            public int FromY { get; set; }

            public int ToX { get; set; }

            public int ToY { get; set; }
        }
    }
}
