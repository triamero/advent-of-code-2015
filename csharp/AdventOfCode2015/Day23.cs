using System.Linq;

namespace AdventOfCode2015
{
    public class Day23 : IDay
    {
        /// <inheritdoc />
        public string Puzzle
        {
            get { return Resources.Day23; }
        }

        /// <inheritdoc />
        public object GetAnswerPart1(string input)
        {
            var regA = new Register(0);
            var regB = new Register(0);

            var commands = input.SplitLines();

            ExecuteCommands(commands, regA, regB);

            return regB.Value;
        }

        /// <inheritdoc />
        public object GetAnswerPart2(string input)
        {
            var regA = new Register(1);
            var regB = new Register(0);

            var commands = input.SplitLines();

            ExecuteCommands(commands, regA, regB);

            return regB.Value;
        }

        private static void ExecuteCommands(string[] commands, Register regA, Register regB)
        {
            int i = 0;

            while (i < commands.Length)
            {
                var splited = commands[i].Split(' ').Select(x => x.Trim(',', ' ')).ToArray();

                var op = splited[0];

                var reg = splited[1];

                var currentRegister = reg == "a" ? regA : regB;

                switch (op)
                {
                    case "hlf":
                        currentRegister.Value /= 2;
                        break;
                    case "tpl":
                        currentRegister.Value *= 3;
                        break;
                    case "inc":
                        currentRegister.Value++;
                        break;

                    case "jmp":
                        i += splited[1].ToInt();
                        continue;

                    case "jie":
                        if (currentRegister.Value % 2 == 0)
                        {
                            i += splited[2].ToInt();
                            continue;
                        }
                        break;
                    case "jio":
                        if (currentRegister.Value == 1)
                        {
                            i += splited[2].ToInt();
                            continue;
                        }
                        break;
                }

                i++;
            }
        }

        private class Register
        {
            /// <summary>
            /// Создает новый экземпляр <see cref="Register"/>
            /// </summary>
            public Register(int value)
            {
                Value = value;
            }

            public int Value { get; set; }
        }
    }
}
