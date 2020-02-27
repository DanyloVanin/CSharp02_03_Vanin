using System;

namespace CSharp_Vanin_02.Exceptions
{
    internal class PersonTooOldException: ArgumentException
    {
        public PersonTooOldException(string message) : base(message) { }
    }
}
