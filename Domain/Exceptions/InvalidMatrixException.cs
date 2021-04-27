using System;

namespace Domain.Exceptions
{
    public class InvalidMatrixException : Exception
    {
        private const string baseMessage = "Invalid Matrix";

        public InvalidMatrixException(string message) 
            :base(baseMessage + ": " + message)
        {

        }

    }
}
