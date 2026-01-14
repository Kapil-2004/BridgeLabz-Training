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

        // UC2: Add a new Address (contact) to the Address Book
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

        // Uc3: Edit an existing contact by first name
        public void EditAddress()
        {
            Console.Write("Enter the First Name of the contact to edit: ");
            string firstName = Console.ReadLine();
            for (int i = 0; i < count; i++)
            {
                if (contacts[i].FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Editing contact: " + contacts[i].GetDetails());

                    // Read new details
                    Console.Write("Enter new Last Name: ");
                    contacts[i].LastName = Console.ReadLine();

                    Console.Write("Enter new Address: ");
                    contacts[i].Address = Console.ReadLine();

                    Console.Write("Enter new City: ");
                    contacts[i].City = Console.ReadLine();

                    Console.Write("Enter new State: ");
                    contacts[i].State = Console.ReadLine();

                    Console.Write("Enter new Zip Code: ");
                    contacts[i].Zip = Console.ReadLine();

                    Console.Write("Enter new Phone Number: ");
                    contacts[i].PhoneNumber = Console.ReadLine();

                    Console.Write("Enter new Email: ");
                    contacts[i].Email = Console.ReadLine();

                    Console.WriteLine("Contact updated successfully!");
                    return;
                }
            }
            Console.WriteLine("Contact with the given first name not found.");
        }

        // UC4: Delete a contact by first name
        public void DeleteAddress()
        {
            Console.Write("Enter the First Name of the contact to delete: ");
            string searchName  = Console.ReadLine();
            for (int i = 0; i < count; i++)
            {
                if (contacts[i].FirstName.Equals(searchName , StringComparison.OrdinalIgnoreCase))
                {
                    // Shift contacts to remove the deleted one
                    for (int j = i; j < count - 1; j++)
                    {
                        contacts[j] = contacts[j + 1];
                    }
                    contacts[count - 1] = null; // Clear last entry
                    count--;
                    Console.WriteLine("Contact deleted successfully!");
                    return;
                }
            }
            Console.WriteLine("Contact with the given first name not found.");
        }
    }
}
