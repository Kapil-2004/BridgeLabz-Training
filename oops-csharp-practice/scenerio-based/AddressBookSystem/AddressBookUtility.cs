using System;

namespace AddressBookSystem
{
    // Utility class to manage Address Book contacts
    public class AddressBookUtility
    {
        private Address[] contacts;  // array to store Address objects
        private int count;           // tracks number of contacts added
        private int capacity;        // maximum number of contacts

        // Constructor initializes array with given capacity
        public AddressBookUtility(int capacity)
        {
            this.capacity = capacity;
            contacts = new Address[capacity];
            count = 0;
        }

        // UC1: Add a new Address (contact) to the Address Book
        public void AddAddress()
        {
            if (count >= capacity)
            {
                Console.WriteLine("Address Book is full! Cannot add more contacts.");
                return;
            }

            // Read details from console
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            Console.Write("Enter State: ");
            string state = Console.ReadLine();

            Console.Write("Enter Zip Code: ");
            string zip = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            // Create Address object
            Address newAddress = new Address(firstName, lastName, address, city, state, zip, phoneNumber, email);

            // Add to array
            contacts[count] = newAddress;
            count++;

            Console.WriteLine("Contact added successfully!");
        }
    }
}
