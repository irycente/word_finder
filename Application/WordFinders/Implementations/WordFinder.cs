using System.Collections.Generic;
using System.Linq;
using Domain.Model.Abstractions;
using Domain.Model.Concretions;
using Utils.Extensions;

namespace Application.WordFinders.Implementations
{
    public class WordFinder : IWordFinder
    {
        private const int NUMBER_OF_RESULTS_TO_RETURN = 10;

        private readonly IMatrix matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            this.matrix = new HorizontalMatrix(matrix);
        }

        public IEnumerable<string> FindWords(IEnumerable<string> wordStream)
        {
            var wordsOccurrences = GetWordsOccurrencesInMatrix(wordStream.ToList());

            var words = GetWordsWithMostOccurrences(wordsOccurrences, NUMBER_OF_RESULTS_TO_RETURN);

            return words;
        }

        private IDictionary<string, int> GetWordsOccurrencesInMatrix(IList<string> words)
        {
            var wordsOccurrences = new Dictionary<string, int>();

            FindVerticalOccurrences(wordsOccurrences, words);

            FindHorizontalOccurrences(wordsOccurrences, words);

            return wordsOccurrences;
        } 

        private void FindVerticalOccurrences(IDictionary<string, int> wordsOccurrencesInMatrix, IList<string> words)
        {
            var matrixColumns = matrix.Columns;

            FindOccurrences(words, matrixColumns, wordsOccurrencesInMatrix);
        }

        private void FindHorizontalOccurrences(IDictionary<string, int> wordsOccurrencesInMatrix, IList<string> words)
        {
            var matrixRows = matrix.Rows;

            FindOccurrences(words, matrixRows, wordsOccurrencesInMatrix);
        }

        private void FindOccurrences(IList<string> words, IList<string> source, IDictionary<string, int> wordsOccurrences)
        {
            var sourceLength = source.Count;

            foreach(var word in words)
            {
                for(int i = 0; i < sourceLength; i++)
                {
                    var sourceItem = source[i];

                    var wordOccurrencesInItem = sourceItem.GetOccurrencesOf(word);

                    wordsOccurrences.AddOrIncrementExistent(word, wordOccurrencesInItem);                               
                }
            }
        }

        private IEnumerable<string> GetWordsWithMostOccurrences(IDictionary<string, int> wordsOccurrencesInMatrix, int requiredResults)
        {
            return wordsOccurrencesInMatrix
                .OrderByDescending(x => x.Value)
                .Where(x => x.Value != 0)
                .Take(requiredResults)
                .Select(x => x.Key);
        }
    }
}
