using System;

namespace AddressBookSystem
{
    // Interface defining Address Book operations
    public interface IAddressBookUtility
    {
        // UC2: Add a single contact
        void AddAddress();

        // UC3: Edit existing contact using name
        void EditAddressByName();

        // UC4: Delete a contact using name
        void DeleteAddressByName();

        // UC5: Add multiple contacts one at a time
        void AddMultipleAddresses();

        // UC8: Search person by City or State within this Address Book
        void SearchPersonByCityOrState();

        // UC9: search persons by City or State - separate methods
        void SearchByCity();
        void SearchByState();

        // UC10: Count persons by City or State - separate methods
        void CountByCity();
        void CountByState();

        // UC12: Ability to sort the entries in the address book by City, State, or Zip
        void SortByCity();
        void SortByState();
        void SortByZip();

        // UC13: Ability to Read or Write the Address Book with Persons Contact into a File using File IO
        void WriteContactsToFile();
        void ReadContactsFromFile();

        // UC14: Ability to Read/Write the Address Book with Persons Contact as CSV File
        void WriteContactsToCSV();
        void ReadContactsFromCSV();
    }
}
