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
    }
}
