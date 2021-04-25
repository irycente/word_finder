using System.Collections.Generic;
using System.Linq;
using Application.MatrixProviders;
using Application.MatrixProviders.Implementations;
using Application.WordFinders;
using Application.WordFinders.Implementations;
using Application.WordStreamProviders;
using Application.WordStreamProviders.Implementations;
using WordFinder.Helpers.Printers;
using WordFinder.Helpers.Printers.Implementations;

namespace WordFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NUMBER_OF_WORDS_TO_PRINT = 10;

            IMatrixProvider matrixProvider = new MockedMatrixProvider();
            IWordStreamProvider wordStreamProvider = new MockedWordStreamProvider();
            IWordFinder wordFinder = new MockedWordFinder();
            IListPrinter wordPrinter = new RankedListPrinter(); 

            IEnumerable<string> matrix;
            IEnumerable<string> wordStream;
            IEnumerable<string> words;

            // 1. Get valid matrix.

            matrix = matrixProvider.GetValidMatrix();

            // 2. Get valid stream.

            wordStream = wordStreamProvider.GetValidWordStream();

            // 3. Get the 10 words from the stream with most occurences in the matrix.

            words = wordFinder.FindWords(matrix, wordStream, NUMBER_OF_WORDS_TO_PRINT);

            // 4. Print the result.

            wordPrinter.PrintList(words.ToList());
        }
    }
}
