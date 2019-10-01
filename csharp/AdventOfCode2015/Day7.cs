using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015
{
    public class Day7 : IDay
    {
        private const string ResultKey = "a";

        /// <inheritdoc />
        public string Puzzle
        {
            get { return Resources.Day7; }
        }

        /// <inheritdoc />
        public object GetAnswerPart1(string input)
        {
            var dict = new Dictionary<string, ushort?>();

            var commands = GetCommands(input);

            while (!dict.Get(ResultKey).HasValue)
            {
                foreach (var command in commands)
                {
                    dict[command.To] = ExecuteCommand(command, dict, false);
                }
            }

            return dict[ResultKey];
        }

        /// <inheritdoc />
        public object GetAnswerPart2(string input)
        {
            var dict = new Dictionary<string, ushort?>();

            var commands = GetCommands(input);

            while (!dict.Get(ResultKey).HasValue)
            {
                foreach (var command in commands)
                {
                    dict[command.To] = ExecuteCommand(command, dict, true);
                }
            }

            return dict[ResultKey];
        }

        internal static Dictionary<string, ushort?> GetResultSignals(Command[] commands, string key)
        {
            var dict = new Dictionary<string, ushort?>();

            while (!dict.Get(key).HasValue)
            {
                foreach (var command in commands)
                {
                    dict[command.To] = ExecuteCommand(command, dict, false);
                }
            }

            return dict;
        }

        private static ushort? ExecuteCommand(Command command, Dictionary<string, ushort?> dict, bool @override)
        {
            if (!dict.ContainsKey(command.To))
            {
                dict[command.To] = null;
            }

            ushort? value = dict.Get(command.To);

            switch (command.Operator)
            {
                case "assign":
                    {
                        if (@override && command.To == "b")
                        {
                            value = 46065;
                        }
                        else
                        {
                            value = GetLeftValue(command, dict);
                        }

                        break;
                    }

                case "not":
                    {
                        ushort? curValue = GetRightValue(command, dict);

                        if (curValue.HasValue)
                        {
                            value = (ushort)(ushort.MaxValue - curValue);
                        }

                        break;
                    }

                case "or":
                case "and":
                case "lshift":
                case "rshift":
                    {
                        ushort? leftValue = GetLeftValue(command, dict);
                        ushort? rightValue = GetRightValue(command, dict);

                        if (leftValue.HasValue && rightValue.HasValue)
                        {
                            if (command.Operator.Equals("or"))
                            {
                                value = (ushort)(leftValue | rightValue);
                            }

                            if (command.Operator.Equals("and"))
                            {
                                value = (ushort)(leftValue & rightValue);
                            }

                            if (command.Operator.Equals("lshift"))
                            {
                                value = (ushort)(leftValue << rightValue);
                            }

                            if (command.Operator.Equals("rshift"))
                            {
                                value = (ushort)(leftValue >> rightValue);
                            }
                        }

                        break;
                    }
            }

            return value;
        }

        private static ushort? GetLeftValue(Command command, Dictionary<string, ushort?> dict)
        {
            if (command.Left.IsNumber())
            {
                return command.Left.ToUshort();
            }
            return dict.Get(command.Left);
        }

        private static ushort? GetRightValue(Command command, Dictionary<string, ushort?> dict)
        {
            if (command.Right.IsNumber())
            {
                return command.Right.ToUshort();
            }
            return dict.Get(command.Right);
        }

        internal static Command[] GetCommands(string input)
        {
            var commands = new List<Command>();

            foreach (var line in input.SplitLines())
            {
                var command = new Command();

                var splited = line.Replace("->", "|")
                    .Split('|')
                    .Select(x => x.Trim())
                    .ToArray();

                var line1 = splited[0];
                command.To = splited[1];

                if (line1.IsNumber() || splited.Length == 2)
                {
                    command.Operator = "assign";
                    command.Left = line1;
                }

                if (line1.StartsWith("NOT"))
                {
                    command.Operator = "not";
                    command.Right = line1.Replace("NOT", "").Trim();
                }

                if (line1.Contains("OR")
                    || line1.Contains("AND")
                    || line1.Contains("LSHIFT")
                    || line1.Contains("RSHIFT"))
                {
                    var cSplited = line1.Split(' ');

                    command.Left = cSplited[0];
                    command.Operator = cSplited[1].ToLower();
                    command.Right = cSplited[2];
                }

                commands.Add(command);
            }

            return commands.ToArray();
        }

        internal class Command
        {
            public string Operator { get; set; }

            public string Left { get; set; }

            public string Right { get; set; }

            public string To { get; set; }
        }
    }
}
