using System;

namespace UBT.Core.Exceptions
{
    public class NotTickableException : SystemException
    {
        public NotTickableException()
        {
        }

        public NotTickableException(string message) : base(message)
        {
        }
    }
}
