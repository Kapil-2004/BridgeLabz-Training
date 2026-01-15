using System;

namespace AddressBookSystem
{
    // Utility class to manage Address Book contacts
    public class AddressBookUtility : IAddressBookUtility
    {
        private Address[] contacts;
        private int count;
        private int capacity;

        public AddressBookUtility(int capacity)
        {
            this.capacity = capacity;
            contacts = new Address[capacity];
            count = 0;
        }

        // UC2: Add a new Address
        public void AddAddress()
        {
            if (count >= capacity)
            {
                Console.WriteLine("Address Book is full! Cannot add more contacts.");
                return;
            }

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            // UC7 Duplicate validation
            if (IsDuplicate(firstName, lastName))
            {
                Console.WriteLine("Duplicate entry found. Contact already exists.");
                return;
            }

            Console.Write("Enter Address: ");
            string addressLine = Console.ReadLine();

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

            Address newAddress = new Address(
                firstName, lastName, addressLine, city, state, zip, phoneNumber, email
            );

            contacts[count] = newAddress;
            count++;
            Console.WriteLine("Contact added successfully!");
        }

        // UC7: Check duplicate person using First Name and Last Name
        private bool IsDuplicate(string firstName, string lastName)
        {
            for (int i = 0; i < count; i++)
            {
                if (contacts[i].FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                    contacts[i].LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        // UC3: Edit existing contact by first name
        public void EditAddressByName()
        {
            Console.Write("Enter the First Name of the contact to edit: ");
            string firstName = Console.ReadLine();

            for (int i = 0; i < count; i++)
            {
                if (contacts[i].FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Enter new Last Name: ");
                    contacts[i].LastName = Console.ReadLine();

                    Console.Write("Enter new Address: ");
                    contacts[i].AddressLine = Console.ReadLine();

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
        public void DeleteAddressByName()
        {
            Console.Write("Enter the First Name of the contact to delete: ");
            string searchName = Console.ReadLine();

            for (int i = 0; i < count; i++)
            {
                if (contacts[i].FirstName.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    for (int j = i; j < count - 1; j++)
                    {
                        contacts[j] = contacts[j + 1];
                    }

                    contacts[count - 1] = null;
                    count--;

                    Console.WriteLine("Contact deleted successfully!");
                    return;
                }
            }

            Console.WriteLine("Contact with the given first name not found.");
        }

        // UC5: Add multiple contacts
        public void AddMultipleAddresses()
        {
            char choice;

            do
            {
                AddAddress();
                Console.Write("Do you want to add another contact? (y/n): ");
                choice = Console.ReadLine().ToLower()[0];

            } while (choice == 'y' && count < capacity);
        }
    }
}
