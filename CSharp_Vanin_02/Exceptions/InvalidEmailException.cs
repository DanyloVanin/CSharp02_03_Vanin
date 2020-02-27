using System;

namespace CSharp_Vanin_02.Exceptions
{
    internal class InvalidEmailException: ArgumentException
    {
        public InvalidEmailException(string message) : base(message) { }
    }
}
