using System;
using System.Collections.Generic;

namespace ConsoleApp.Helpers.Printers.ListPrinters.Implementations
{
    public class RankedListPrinter : IListPrinter
    {
        private const string LINE_FORMAT = "{0}. {1}";
        private const string LINE_SEPARATION = "\n"; 

        public void PrintList(List<string> elements)
        {
            var totalElements = elements.Count;

            for(int i = 0; i < totalElements; i++)
            {
                var order = i + 1;
                var element = elements[i];
                var line = GetLine(order, element);

                Console.WriteLine(line);
                Console.WriteLine(LINE_SEPARATION);
            }
        }

        private string GetLine(int order, string content)
        {
            return string.Format(LINE_FORMAT, order, content);
        }
    }
}
