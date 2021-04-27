using System.Collections.Generic;
using System.Linq;

namespace Utils.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<string> ToLower(this IEnumerable<string> source)
        {
            return  source.Select(x => x.ToLower());
        }

        public static int GetLengthOfFirstElement(this IEnumerable<string> source)
        {
            var itemsInSource = source.Count();

            return itemsInSource != 0 ? source.First().Length : 0;
        }
    }
}
