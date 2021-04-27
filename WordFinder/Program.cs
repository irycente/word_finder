using System.Collections.Generic;
using System.Linq;
using Application.MatrixProviders;
using Application.MatrixProviders.Implementations;
using Application.WordFinders;
using Application.WordFinders.Implementations;
using Application.WordStreamProviders;
using Application.WordStreamProviders.Implementations;
using ConsoleApp.Helpers.Printers.ListPrinters;
using ConsoleApp.Helpers.Printers.ListPrinters.Implementations;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // TO-DO: Implement file matrix provider using validator.
            IMatrixProvider matrixProvider = new MockedMatrixProvider();
            // TO-DO: Implement file word stream provider.
            IWordStreamProvider wordStreamProvider = new MockedWordStreamProvider();            
            IListPrinter wordPrinter = new RankedListPrinter();
            IWordFinder wordFinder;

            IEnumerable<string> matrix;
            IEnumerable<string> wordStream;
            IEnumerable<string> foundWords;

            matrix = matrixProvider.GetValidMatrix();
            wordStream = wordStreamProvider.GetValidWordStream();

            wordFinder = new WordFinder(matrix);
            foundWords = wordFinder.FindWords(wordStream);

            wordPrinter.PrintList(foundWords.ToList());
        }
    }
}
