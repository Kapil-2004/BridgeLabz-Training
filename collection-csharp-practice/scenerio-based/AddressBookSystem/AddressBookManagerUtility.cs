using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    // Implements IAddressBookManager using Dictionary
    public class AddressBookManagerUtility : IAddressBookManager
    {
        private Dictionary<string, AddressBookUtility> addressBooks;

        public AddressBookManagerUtility()
        {
            addressBooks = new Dictionary<string, AddressBookUtility>();
        }

        public void AddAddressBook()
        {
            Console.Write("Enter Address Book Name: ");
            string name = Console.ReadLine();

            if (addressBooks.ContainsKey(name))
            {
                Console.WriteLine("Address Book already exists.");
                return;
            }

            addressBooks[name] = new AddressBookUtility(10);
            Console.WriteLine("Address Book created successfully.");
        }

        public AddressBookUtility SelectAddressBook()
        {
            Console.Write("Enter Address Book Name to open: ");
            string name = Console.ReadLine();

            if (addressBooks.ContainsKey(name))
            {
                return addressBooks[name];
            }

            Console.WriteLine("Address Book not found.");
            return null;
        }

        public void ListAddressBooks()
        {
            if (addressBooks.Count == 0)
            {
                Console.WriteLine("No Address Books available.");
                return;
            }

            Console.WriteLine("Available Address Books:");
            foreach (string key in addressBooks.Keys)
            {
                Console.WriteLine("- " + key);
            }
        }
    }
}
