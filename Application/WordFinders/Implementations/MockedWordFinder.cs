using System.Collections.Generic;

namespace Application.WordFinders.Implementations
{
    public class MockedWordFinder : IWordFinder
    {
        private IEnumerable<string> result;

        public IEnumerable<string> FindWords(IEnumerable<string> wordStream)
        {
            InitializeResult();

            return result;
        }

        private void InitializeResult()
        {
            result = new List<string>()
            {
                "ketchup",
                "burger",
                "pizza",
                "steak"
            };
        }
    }
}
