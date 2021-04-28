using System;

namespace ConsoleApp.Helpers.Requesters
{
    public abstract class StringInputRequester
    {
        protected StringInputRequester(string promptMessage)
        {
            PromptMessage = promptMessage;
        }

        protected string PromptMessage { get; }

        public string Request()
        {
            string input = string.Empty;

            while(input == string.Empty)
            {
                Console.WriteLine(PromptMessage);

                input = Console.ReadLine();
            }

            return input;
        }
    }
}
