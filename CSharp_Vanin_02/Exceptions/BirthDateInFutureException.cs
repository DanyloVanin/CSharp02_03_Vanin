using System;

namespace CSharp_Vanin_02.Exceptions
{
    internal class BirthDateInFutureException: ArgumentException
    {
        public BirthDateInFutureException(string message) : base(message) { }
    }
}
