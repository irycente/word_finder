using System.Collections.Generic;

namespace Application.MatrixProviders.Implementations
{
    public class MockedMatrixProvider : IMatrixProvider
    {
        private IEnumerable<string> matrix;

        /// <summary>
        /// Returns a mocked matrix with 10 rows and 20 columns 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetValidMatrix()
        {
            InitializeMatrix();

            return matrix;
        }

        public void InitializeMatrix()
        {
            matrix = new List<string>
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
        }
    }
}
