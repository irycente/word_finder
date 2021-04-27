using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.WordFinders.Implementations
{
    public class WordFinder : IWordFinder
    {
        private const int NUMBER_OF_RESULTS_TO_RETURN = 10;

        private readonly List<string> matrix;
        private readonly int matrixLenght;
        private readonly int matrixHeight;

        public WordFinder(IEnumerable<string> matrix)
        {
            this.matrix = matrix
                .Select(x => x.ToLower())
                .ToList();

            this.matrixHeight = matrix.Count();
            this.matrixLenght = matrixHeight != 0 ? matrix.First().Length : 0; 
        }

        public IEnumerable<string> FindWords(IEnumerable<string> wordStream)
        {
            var words = wordStream
                .Select(x => x.ToLower())
                .ToList();

            var wordsOccurrences = GetWordsOccurrencesInMatrix(words);

            var results = PrepareResults(wordsOccurrences);

            return results;
        }

        private IDictionary<string, int> GetWordsOccurrencesInMatrix(IList<string> words)
        {
            var wordsOccurrencesInMatrix = new Dictionary<string, int>();

            AddVerticalOccurrences(wordsOccurrencesInMatrix, words);

            AddHorizontalOccurrences(wordsOccurrencesInMatrix, words);

            return wordsOccurrencesInMatrix;
        } 

        private void AddVerticalOccurrences(IDictionary<string, int> wordsOccurrencesInMatrix, IList<string> words)
        {
            var matrixColumns = GetMatrixColumns();

            AddOccurrences(words, matrixColumns, wordsOccurrencesInMatrix);
        }

        private void AddHorizontalOccurrences(IDictionary<string, int> wordsOccurrencesInMatrix, IList<string> words)
        {
            // The matrix is already presented as a set of rows.

            AddOccurrences(words, matrix, wordsOccurrencesInMatrix);
        }

        private void AddOccurrences(IList<string> words, IList<string> list, IDictionary<string, int> occurrencesOfEachWordInList)
        {
            var listSize = list.Count;

            foreach(var word in words)
            {
                for(int i = 0; i < listSize; i++)
                {
                    var listItem = list[i];

                    var wordOccurrencesInItem = GetOccurrences(word, listItem);

                    AddOrIncrement(occurrencesOfEachWordInList, word, wordOccurrencesInItem);                    
                }
            }
        }

        private IList<string> GetMatrixColumns()
        {
            var columns = new List<string>();

            for(int x = 0; x < matrixLenght; x++)
            {
                var column = string.Empty;

                for(int y = 0; y < matrixHeight; y++)
                {
                    var cell = matrix[y][x];

                    column += cell;
                }

                columns.Add(column);
            }

            return columns;
        }

        // TO-DO: Move to string extension methods
        private int GetOccurrences(string searched, string source)
        {
            return source.Split(new string[] { searched }, StringSplitOptions.None).Length - 1;
        }

        // TO-DO: Move to Dictionary extension methods.
        private void AddOrIncrement(IDictionary<string, int> dictionary, string key, int value)
        {
            try
            {
                dictionary.Add(key, value);
            }
            catch (ArgumentException)
            {
                dictionary[key] = value + dictionary[key];
            }
        }

        private IEnumerable<string> PrepareResults(IDictionary<string, int> wordsOccurrencesInMatrix)
        {
            return wordsOccurrencesInMatrix
                .OrderByDescending(x => x.Value)
                .Where(x => x.Value != 0)
                //.Take(NUMBER_OF_RESULTS_TO_RETURN)
                .Select(x => x.Key);
        }
    }
}
