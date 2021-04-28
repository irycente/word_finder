using System;

namespace Domain.Exceptions
{
    public class NoMatchesException : Exception
    {
        private const string MESSAGE = "No matches found.";

        public NoMatchesException()
            :base(MESSAGE)
        {
        }
    }
}
