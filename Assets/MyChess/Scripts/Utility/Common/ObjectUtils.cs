using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace MyChess.Scripts.Utility.Common
{
    public static class ObjectUtils
    {
        #region ObjectUtils

        private static bool IsEmpty(this Object unityObj)
        {
            return unityObj.Equals(null);
        }
        
        public static T CheckNull<T>(this T obj)
        {
            Assert.IsFalse(obj.IsEmpty(), $"Incorrect attempt to assign {obj}");
            return obj;
        }

        public static bool IsEmpty(this object obj)
        {
            switch (obj)
            {
                case null:
                case ICollection collection when collection.IsEmpty():
                case string value when string.IsNullOrEmpty(value):
                case Object unityObj when unityObj.IsEmpty():
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsEmpty(this ICollection collection)
        {
            return collection == null || collection.Count <= 0;
        }

        public static string ToString<T1, T2>(this IDictionary<T1, T2> dict, string separator1, string separator2 = "|")
        {
            var txt = "";
            var count = dict.Count;
            var i = 0;

            foreach (var entry in dict)
            {
                var valText = entry.Value is IList list ? list.ToString(",") : "" + entry.Value;
                txt += entry.Key + separator2 + valText;

                if (++i < count - 1)
                {
                    txt += separator1 + " ";
                }
            }

            return txt;
        }

        #endregion
    }
}