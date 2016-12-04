using System;

namespace UBT.Core.Exceptions
{
    public class SpawnException : SystemException
    {
        public SpawnException()
        {
        }

        public SpawnException(string message) : base(message)
        {
        }
    }
}
