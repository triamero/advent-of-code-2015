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

            GoDeepPart1(obj, ref count);

            return count;
        }

        public object GetAnswerPart2(string input)
        {
            var obj = JToken.Parse(input);

            var count = 0;

            GoDeepPart2(obj, ref count);

            return count;
        }

        private static void GoDeepPart1(JToken token, ref int count)
        {
            if (token.Type == JTokenType.Array
                || token.Type == JTokenType.Object
                || token.Type == JTokenType.Property)
            {
                foreach (var child in token.Children())
                {
                    GoDeepPart1(child, ref count);
                }
            }

            if (token.Type == JTokenType.Integer)
            {
                count += token.Value<int>();
                return;
            }
        }

        private static void GoDeepPart2(JToken token, ref int count)
        {
            if (token.Type == JTokenType.Object)
            {
                var children = token.Children();

                foreach (var child in children)
                {
                    if (child.Type == JTokenType.Property)
                    {
                        foreach (var child1 in child.Children())
                        {
                            if (child1.Type == JTokenType.String)
                            {
                                if (child1.Value<string>() == "red")
                                {
                                    return;
                                }
                            }
                        }
                    }
                }

                foreach (var child in children)
                {
                    if (child.Type == JTokenType.Array
                        || child.Type == JTokenType.Object
                        || child.Type == JTokenType.Property)
                    {
                        GoDeepPart2(child, ref count);
                    }

                    if (token.Type == JTokenType.Integer)
                    {
                        count += token.Value<int>();
                    }
                }

                return;
            }

            if (token.Type == JTokenType.Array
                || token.Type == JTokenType.Property)
            {
                foreach (var child in token.Children())
                {
                    GoDeepPart2(child, ref count);
                }

                return;
            }

            if (token.Type == JTokenType.Integer)
            {
                count += token.Value<int>();
                return;
            }
        }
    }
}
