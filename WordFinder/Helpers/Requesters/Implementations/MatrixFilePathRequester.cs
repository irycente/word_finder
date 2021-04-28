namespace ConsoleApp.Helpers.Requesters.Implementations
{
    public class MatrixFilePathRequester : StringInputRequester
    {
        private const string PROMT_MESSAGE = "Please provide the path for the file containing the matrix.";

        public MatrixFilePathRequester()
            :base(PROMT_MESSAGE)
        {

        }
    }
}
