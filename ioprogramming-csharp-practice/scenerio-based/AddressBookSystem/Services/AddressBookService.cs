using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AddressBookSystem.Attributes;
using AddressBookSystem.Entities;
using AddressBookSystem.Exceptions;

namespace AddressBookSystem.Services
{
    public class AddressBookService
    {
        // DSA: Dictionary for multiple AddressBooks
        private readonly Dictionary<string, AddressBook> addressBooks;

        // Delegate + Event (UC)
        public delegate void ContactAddedHandler(string name);
        public event ContactAddedHandler OnContactAdded;

        public AddressBookService()
        {
            addressBooks = new Dictionary<string, AddressBook>(StringComparer.OrdinalIgnoreCase);
        }

        public void AddAddressBook(string name)
        {
            if (!addressBooks.ContainsKey(name))
                addressBooks.Add(name, new AddressBook(name));
            else
                Console.WriteLine("Address Book already exists!");
        }

        public List<string> GetAddressBookNames()
        {
            return addressBooks.Keys.ToList();
        }

        private AddressBook GetBook(string name)
        {
            if (!addressBooks.ContainsKey(name))
                throw new AddressBookNotFoundException($"Address Book '{name}' not found!");

            return addressBooks[name];
        }

        // Reflection + Attributes Validation
        private void ValidateContact(Contact contact)
        {
            PropertyInfo[] props = typeof(Contact).GetProperties();

            foreach (PropertyInfo prop in props)
            {
                if (Attribute.IsDefined(prop, typeof(RequiredFieldAttribute)))
                {
                    string value = prop.GetValue(contact)?.ToString();
                    if (string.IsNullOrWhiteSpace(value))
                        throw new Exception($"{prop.Name} is required!");
                }

                if (Attribute.IsDefined(prop, typeof(EmailAttribute)))
                {
                    string email = prop.GetValue(contact)?.ToString();
                    if (!email.Contains("@") || !email.Contains("."))
                        throw new Exception("Invalid Email Format!");
                }
            }
        }

        // UC2: Add Contact + Duplicate Check
        public void AddContact(string addressBookName, Contact contact)
        {
            AddressBook book = GetBook(addressBookName);

            ValidateContact(contact);

            bool duplicate = book.Contacts.Any(c =>
                c.FirstName.Equals(contact.FirstName, StringComparison.OrdinalIgnoreCase) &&
                c.LastName.Equals(contact.LastName, StringComparison.OrdinalIgnoreCase));

            if (duplicate)
                throw new DuplicateContactException("Duplicate contact not allowed in same Address Book!");

            book.Contacts.Add(contact);

            // event trigger
            OnContactAdded?.Invoke(contact.FullName);
        }

        // UC3: Edit Contact
        public void EditContact(string addressBookName, string firstName, string lastName, Contact updated)
        {
            AddressBook book = GetBook(addressBookName);

            Contact existing = book.Contacts.FirstOrDefault(c =>
                c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

            if (existing == null)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            ValidateContact(updated);

            existing.FirstName = updated.FirstName;
            existing.LastName = updated.LastName;
            existing.Address = updated.Address;
            existing.City = updated.City;
            existing.State = updated.State;
            existing.Zip = updated.Zip;
            existing.PhoneNumber = updated.PhoneNumber;
            existing.Email = updated.Email;
        }

        // UC4: Delete Contact
        public void DeleteContact(string addressBookName, string firstName, string lastName)
        {
            AddressBook book = GetBook(addressBookName);

            Contact existing = book.Contacts.FirstOrDefault(c =>
                c.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                c.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));

            if (existing == null)
            {
                Console.WriteLine("Contact not found!");
                return;
            }

            book.Contacts.Remove(existing);
        }

        // UC8: Search by City/State across multiple AddressBooks
        public List<Contact> SearchByCityOrState(string cityOrState)
        {
            List<Contact> results = new List<Contact>();

            foreach (var book in addressBooks.Values)
            {
                results.AddRange(book.Contacts.Where(c =>
                    c.City.Equals(cityOrState, StringComparison.OrdinalIgnoreCase) ||
                    c.State.Equals(cityOrState, StringComparison.OrdinalIgnoreCase)));
            }

            return results;
        }

        // UC9: View by City/State
        public List<Contact> ViewByCityOrState(string cityOrState)
        {
            return SearchByCityOrState(cityOrState);
        }

        // UC10: Count by City/State
        public int CountByCityOrState(string cityOrState)
        {
            return SearchByCityOrState(cityOrState).Count;
        }

        // UC11: Sort by Name
        public void SortByName(string addressBookName)
        {
            AddressBook book = GetBook(addressBookName);
            book.Contacts.Sort();
        }

        // UC12: Sort by City/State/Zip
        public void SortByCityStateZip(string addressBookName)
        {
            AddressBook book = GetBook(addressBookName);

            book.Contacts = book.Contacts
                .OrderBy(c => c.City)
                .ThenBy(c => c.State)
                .ThenBy(c => c.Zip)
                .ToList();
        }

        // For Data Sources
        public AddressBook GetAddressBook(string name)
        {
            return GetBook(name);
        }

        public void ReplaceAddressBook(AddressBook book)
        {
            addressBooks[book.Name] = book;
        }
    }
}
