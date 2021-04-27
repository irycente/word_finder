using System.Collections.Generic;

namespace Application.WordStreamProviders.Implementations
{
    public class MockedWordStreamProvider : IWordStreamProvider
    {
        private IEnumerable<string> wordStream;

        /// <summary>
        /// Returns a mocked matrix with 10 rows and 20 columns 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetValidWordStream()
        {
            InitializeWordStream();

            return wordStream;
        }

        public void InitializeWordStream()
        {
            wordStream = new List<string>
            {
                "ketchup",
                "burger",
                "pizza",
                "steak",
                "hotdog",
                "pineapple"
            };
        }
    }
}
