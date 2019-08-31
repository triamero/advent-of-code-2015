using Newtonsoft.Json.Linq;

namespace AdventOfCode2015
{
    public class Day12 : IDay
    {
        public string Puzzle
        {
            get
            {
                return Resources.Day12;
            }
        }

        public object GetAnswerPart1(string input)
        {
            var obj = JToken.Parse(input);

            var count = 0;

            GoDeep(obj, ref count);

            return count;
        }

        public object GetAnswerPart2(string input)
        {
            return null;
        }

        private static void GoDeep(JToken token, ref int count)
        {
            if (token.Type == JTokenType.Array
                || token.Type == JTokenType.Object
                || token.Type == JTokenType.Property)
            {
                foreach (var child in token.Children())
                {
                    GoDeep(child, ref count);
                }
            }

            if (token.Type == JTokenType.Integer)
            {
                count += token.Value<int>();
                return;
            }
        }
    }
}
