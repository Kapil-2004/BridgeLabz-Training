using System;

namespace AddressBookSystem.Exceptions
{
    public class DuplicateContactException : Exception
    {
        public DuplicateContactException(string msg) : base(msg) { }
    }
}
