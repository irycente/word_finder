using System.Collections.Generic;
using System.Linq;
using Application.WordFinders.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationTest.WordFinders
{
    [TestClass]
    public class WordFinderTest
    {
        [TestMethod]
        public void WordFinderShouldFindAllWordsOccurrencesInMatrix()
        {
            var matrix = new List<string>
            {
                "ASDGIELKETCHUPSNDJHY",
                "QWIDSJBPAJKHGNKIEEEN",
                "CBALKSHIUNLSJFNKKAJS",
                "EBYBVIKTHASDMLKJELKS",
                "AUIENDKZLEUNXDJHTYUB",
                "MRNTVECZXQZEXRCTCYBU",
                "AGSKDJFAGQPWOERUHYER",
                "CEBNAKJSTEAKHSDUUYGG",
                "XRIWNCHSAGDHDHGFPUHE",
                "ABURGERHBLIUJOIKDKPR"
            };

            var words = new List<string>
            {
                "ketchup",
                "burger",
                "pizza",
                "steak"
            };

            var expectedResult = new List<string>
            {
                "burger",
                "ketchup",
                "steak"
            };

            var subject = new WordFinder(matrix);

            var result = subject.FindWords(words).ToList();

            var resultLength = result.Count;
            var expectedResultLength = expectedResult.Count;

            Assert.AreEqual(expectedResultLength, resultLength);
            
            for(int i = 0; i < resultLength; i++)
            {
                var item = result[i];
                var expectedItem = expectedResult[i];

                Assert.AreEqual(expectedItem, item);
            }
        }
    }
}
