using System;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2015
{
    public class Day4 : IDay
    {
        public string Puzzle
        {
            get
            {
                return Resources.Day4;
            }
        }

        public object GetAnswerPart1(string input)
        {
            return GetAnswer(input, 5);
        }

        public object GetAnswerPart2(string input)
        {
            return GetAnswer(input, 6);
        }

        private int GetAnswer(string input, int requiredLeadingZeroes)
        {
            string startWith = new string('0', requiredLeadingZeroes);

            using (var md5 = MD5.Create())
            {
                for (int i = 1; i < int.MaxValue; i++)
                {
                    var str = input + i.ToString();

                    var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

                    var hexHash = ByteArrayToString(hash);

                    if (hexHash.StartsWith(startWith))
                    {
                        return i;
                    }
                }
            }

            return 0;
        }

        public static string ByteArrayToString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
    }
}
