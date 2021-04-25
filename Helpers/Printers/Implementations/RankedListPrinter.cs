using System;
using System.Collections.Generic;

namespace WordFinder.Helpers.Printers.Implementations
{
    public class RankedListPrinter : IListPrinter
    {
        private const string LINE_FORMAT = "{0}. {1}";
        private const string LINE_SEPARATION = "\n"; 

        public void PrintList(List<string> elements)
        {
            for(int i = 0; i < elements.Count; i++)
            {
                var index = i + 1;
                var element = elements[i];
                var line = GetLine(i, element);

                Console.WriteLine(line);
                Console.WriteLine(LINE_SEPARATION);
            }
        }

        private string GetLine(int index, string content)
        {
            return string.Format(LINE_FORMAT, index, content);
        }
    }
}
