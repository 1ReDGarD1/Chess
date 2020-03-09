using System;
using System.Collections.Generic;

namespace MyChess.Scripts.Utility.Common
{
    public static class RandomUtils
    {
        #region RandomUtils

        private static readonly Random Random = new Random();

        private static int Range(int min, int max) => Random.Next(min, max + 1);

        public static T GetRandom<T>(this IList<T> list)
        {
            if (list.IsEmpty())
            {
                return default;
            }

            var ix = Range(0, list.Count - 1);
            return list[ix];
        }

        public static T GetRandom<T>(this T[] array)
        {
            var idx = Range(0, array.Length - 1);
            return array[idx];
        }

        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = Random.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }

        #endregion
    }
}