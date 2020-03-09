using System.Collections;

namespace MyChess.Scripts.Utility.Common
{
    public static class ListUtils
    {
        #region ListUtils

        private static readonly string ListIsEmptyName = "[IList is empty]";
        private static readonly string ObjectIsEmptyName = "[Object is empty]";

        public static string ToString(this IList list, string separator)
        {
            if (list.IsEmpty())
            {
                return ListIsEmptyName;
            }

            var text = "";
            var count = list.Count;

            for (var i = 0; i < count; i++)
            {
                var obj = list[i];
                text += obj.IsEmpty() ? ObjectIsEmptyName : obj.ToString();
                if (i < count - 1)
                {
                    text += separator;
                }
            }

            return text;
        }

        #endregion
    }
}