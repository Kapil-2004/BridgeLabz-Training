using System;

namespace AddressBookSystem
{

    // Address class represents a single address in the Address Book
    // It stores personal and contact details of a user
    public class Address
    {
        // Private fields to store contact details
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private string zip;
        private string phoneNumber;
        private string email;

        // Public property to get or set First Name
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        // Public property to get or set Last Name
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        // Public property to get or set Address
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        // Public property to get or set City
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        // Public property to get or set State
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        // Public property to get or set Zip code
        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        // Public property to get or set Phone Number
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        // Public property to get or set Email
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        // Constructor to initialize an Address object
        public Address(string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        // Method to get full details of the address as a formatted string
        public string GetDetails()
        {
            return $"{firstName} {lastName}, {address}, {city}, {state}, {zip}, {phoneNumber}, {email}";
        }
    }
}
