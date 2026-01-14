using System;

namespace AddressBookSystem
{
    // Interface for managing multiple Address Books
    public interface IAddressBookManager
    {
        void AddAddressBook();                  // Create a new Address Book
        AddressBookUtility SelectAddressBook(); // Switch to an existing Address Book
        void ListAddressBooks();                // Optional: show all Address Books
    }
}
