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

        // UC12: Sort contacts by City, State, or Zip
        void SortByCity();
        void SortByState();
        void SortByZip();
    }
}
