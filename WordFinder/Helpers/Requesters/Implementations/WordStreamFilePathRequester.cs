namespace ConsoleApp.Helpers.Requesters.Implementations
{
    public class WordStreamFilePathRequester : StringInputRequester
    {
        private const string PROMT_MESSAGE = "Please provide the path for the file containing the word stream.";

        public WordStreamFilePathRequester() 
            : base(PROMT_MESSAGE)
        {

        }
    }
}
