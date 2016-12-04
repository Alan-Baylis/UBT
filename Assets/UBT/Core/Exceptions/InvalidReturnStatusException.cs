using System;

namespace UBT.Core.Exceptions
{
    public class InvalidReturnStatusException : SystemException
    {
        public InvalidReturnStatusException()
        {
        }

        public InvalidReturnStatusException(string message) : base(message)
        {
        }
    }
}
