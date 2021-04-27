using System;
using System.Collections.Generic;

namespace Utils.Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddOrIncrementExistent<T>(this IDictionary<T, int> source, T key, int value)
        {
            try
            {
                source.Add(key, value);
            }
            catch (ArgumentException)
            {
                source[key] += value;
            }
        }
    }
}
