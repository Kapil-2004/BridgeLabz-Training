using System;

namespace AddressBookSystem.Exceptions
{
    public class AddressBookNotFoundException : Exception
    {
        public AddressBookNotFoundException(string msg) : base(msg) { }
    }
}
