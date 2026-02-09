using System;
using AddressBookSystem.Attributes;

namespace AddressBookSystem.Entities
{
    public class Contact : IComparable<Contact>
    {
        [RequiredField]
        public string FirstName { get; set; }

        [RequiredField]
        public string LastName { get; set; }

        [RequiredField]
        public string Address { get; set; }

        [RequiredField]
        public string City { get; set; }

        [RequiredField]
        public string State { get; set; }

        [RequiredField]
        public string Zip { get; set; }

        [RequiredField]
        public string PhoneNumber { get; set; }

        [Email]
        public string Email { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public int CompareTo(Contact other)
        {
            return string.Compare(FullName, other.FullName, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"{FullName}, {Address}, {City}, {State}, {Zip}, {PhoneNumber}, {Email}";
        }
    }
}
