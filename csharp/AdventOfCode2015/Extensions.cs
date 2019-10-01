using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2015
{
    public static class Extensions
    {
        public static string[] SplitLines(this string input)
        {
            return input
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
        }

        public static int ToInt(this string input)
        {
            if (int.TryParse(input, out var i))
            {
                return i;
            }

            return default(int);
        }

        public static IEnumerable<T[]> GetAllPermutations<T>(this T[] array) where T : IComparable<T>
        {
            void Swap(T[] arr, int from, int to)
            {
                T initial = arr[from];
                arr[from] = arr[to];
                arr[to] = initial;
            }

            array = (T[])array.Clone();

            Array.Sort(array);

            yield return array;

            var clone = (T[])array.Clone();

            do
            {
                clone = (T[])clone.Clone();

                int j = clone.Length - 2;

                while (j != -1 && clone[j].CompareTo(clone[j + 1]) >= 0)
                {
                    j--;
                }

                if (j == -1)
                {
                    yield break; // больше перестановок нет
                }

                int k = clone.Length - 1;

                while (clone[j].CompareTo(clone[k]) >= 0)
                {
                    k--;
                }

                Swap(clone, j, k);

                var l = j + 1;
                var r = clone.Length - 1; // сортируем оставшуюся часть последовательности

                while (l < r)
                {
                    Swap(clone, l++, r--);
                }

                yield return clone;
            } while (true);
        }

        public static ushort ToUshort(this object obj)
        {
            if (obj != null)
            {
                if (obj is ushort)
                {
                    return (ushort)obj;
                }


                if (ushort.TryParse(obj.ToString(), out var value))
                {
                    return value;
                }
            }
            return default(ushort);
        }

        public static TValue Get<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key)
        {
            dict.TryGetValue(key, out var value);
            return value;
        }
    }
}
