using System;

namespace Utils.Extensions
{
    public static class StringExtensions
    {
        public static int GetOccurrencesOf(this string aString, string anotherString, bool caseSensitive = false)
        {
            var source = caseSensitive ? aString : aString.ToLower();
            var searched = caseSensitive ? anotherString : anotherString.ToLower();

            return source.Split(new string[] { searched }, StringSplitOptions.None).Length - 1;
        }
    }
}
