using System;

namespace AddressBookSystem
{
    public class Address
    {
        private string firstName;
        private string lastName;
        private string addressLine;
        private string city;
        private string state;
        private string zip;
        private string phoneNumber;
        private string email;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string AddressLine
        {
            get { return addressLine; }
            set { addressLine = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Address(string firstName, string lastName, string addressLine,
                       string city, string state, string zip,
                       string phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.addressLine = addressLine;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public string GetDetails()
        {
            return firstName + " " + lastName + ", " +
                   addressLine + ", " +
                   city + ", " +
                   state + ", " +
                   zip + ", " +
                   phoneNumber + ", " +
                   email;
        }
    }
}
