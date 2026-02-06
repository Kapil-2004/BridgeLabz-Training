using System;
using System.Collections.Generic;
using System.IO;

namespace AddressBookSystem
{
    // Utility class to manage Address Book contacts
    public class AddressBookUtility : IAddressBookUtility
    {
        private List<Address> contacts;

        public AddressBookUtility(int capacity)
        {
            // capacity is kept to not break your existing constructor usage
            contacts = new List<Address>(capacity);
        }

        // UC2: Add a new Address
        public void AddAddress()
        {
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

            contacts.Add(newAddress);
            Console.WriteLine("Contact added successfully!");
        }

        // UC7: Check duplicate person using First Name and Last Name
        private bool IsDuplicate(string firstName, string lastName)
        {
            for (int i = 0; i < contacts.Count; i++)
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

            for (int i = 0; i < contacts.Count; i++)
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

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].FirstName.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                {
                    contacts.RemoveAt(i);
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

            } while (choice == 'y');
        }

        // UC8: Search person by City or State within this Address Book
        public void SearchPersonByCityOrState()
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            Console.Write("Enter State: ");
            string state = Console.ReadLine();
            bool found = false;

            SortByPersonName();

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].City.Equals(city, StringComparison.OrdinalIgnoreCase) ||
                    contacts[i].State.Equals(state, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(contacts[i].GetDetails());
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No matching contacts found.");
            }
        }

        // UC9: search persons by City or State - separate methods
        // Search persons by City
        public void SearchByCity()
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            SortByPersonName();

            bool found = false;
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].City.Equals(city, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(contacts[i].GetDetails());
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No contacts found for city: " + city);
            }
        }

        // Search persons by State
        public void SearchByState()
        {
            Console.Write("Enter State: ");
            string state = Console.ReadLine();

            SortByPersonName();

            bool found = false;
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].State.Equals(state, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(contacts[i].GetDetails());
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No contacts found for state: " + state);
            }
        }

        // UC10: Count persons by City or State - separate methods
        // Count contacts by City
        public void CountByCity()
        {
            Console.Write("Enter City: ");
            string city = Console.ReadLine();

            int countFound = 0;
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].City.Equals(city, StringComparison.OrdinalIgnoreCase))
                {
                    countFound++;
                }
            }
            Console.WriteLine("Number of contacts in city '" + city + "': " + countFound);
        }

        // Count contacts by State
        public void CountByState()
        {
            Console.Write("Enter State: ");
            string state = Console.ReadLine();

            int countFound = 0;
            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].State.Equals(state, StringComparison.OrdinalIgnoreCase))
                {
                    countFound++;
                }
            }
            Console.WriteLine("Number of contacts in state '" + state + "': " + countFound);
        }

        // UC11: Sort contacts alphabetically by FirstName, then LastName
        private void SortByPersonName()
        {
            contacts.Sort((a, b) =>
            {
                int firstCompare = string.Compare(a.FirstName, b.FirstName, true);
                if (firstCompare != 0) return firstCompare;

                return string.Compare(a.LastName, b.LastName, true);
            });
        }

        // UC12: Sort the entries in the address book by City, State, or Zip
        public void SortByCity()
        {
            contacts.Sort((a, b) => string.Compare(a.City, b.City, true));
            Console.WriteLine("Contacts sorted by City successfully!");
        }

        public void SortByState()
        {
            contacts.Sort((a, b) => string.Compare(a.State, b.State, true));
            Console.WriteLine("Contacts sorted by State successfully!");
        }

        public void SortByZip()
        {
            contacts.Sort((a, b) => string.Compare(a.Zip, b.Zip, true));
            Console.WriteLine("Contacts sorted by Zip successfully!");
        }

        // UC13: Ability to Read or Write the Address Book with Persons Contact into a File using File IO
        public void WriteContactsToFile()
        {
            string filePath = "AddressBookContacts.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < contacts.Count; i++)
                {
                    Address a = contacts[i];

                    writer.WriteLine(a.FirstName);
                    writer.WriteLine(a.LastName);
                    writer.WriteLine(a.AddressLine);
                    writer.WriteLine(a.City);
                    writer.WriteLine(a.State);
                    writer.WriteLine(a.Zip);
                    writer.WriteLine(a.PhoneNumber);
                    writer.WriteLine(a.Email);
                    writer.WriteLine("-----");
                }
            }

            Console.WriteLine("Contacts saved successfully to file: " + filePath);
        }

        public void ReadContactsFromFile()
        {
            string filePath = "AddressBookContacts.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found: " + filePath);
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            contacts.Clear();

            int i = 0;
            while (i < lines.Length)
            {
                if (lines[i] == "-----")
                {
                    i++;
                    continue;
                }

                string firstName = lines[i++];
                string lastName = lines[i++];
                string addressLine = lines[i++];
                string city = lines[i++];
                string state = lines[i++];
                string zip = lines[i++];
                string phone = lines[i++];
                string email = lines[i++];

                Address a = new Address(firstName, lastName, addressLine, city, state, zip, phone, email);
                contacts.Add(a);
            }

            Console.WriteLine("Contacts loaded successfully from file!");
        }

        // UC14: Ability to Read/Write the Address Book with Persons Contact as CSV File
        public void WriteContactsToCSV()
        {
            string csvPath = "AddressBookContacts.csv";

            using (StreamWriter writer = new StreamWriter(csvPath))
            {
                writer.WriteLine("FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email");

                for (int i = 0; i < contacts.Count; i++)
                {
                    Address a = contacts[i];

                    string line =
                        a.FirstName + "," +
                        a.LastName + "," +
                        a.AddressLine + "," +
                        a.City + "," +
                        a.State + "," +
                        a.Zip + "," +
                        a.PhoneNumber + "," +
                        a.Email;

                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Contacts saved successfully to CSV file: " + csvPath);
        }

        public void ReadContactsFromCSV()
        {
            string csvPath = "AddressBookContacts.csv";

            if (!File.Exists(csvPath))
            {
                Console.WriteLine("CSV file not found: " + csvPath);
                return;
            }

            string[] lines = File.ReadAllLines(csvPath);

            contacts.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');

                if (data.Length == 8)
                {
                    Address a = new Address(
                        data[0], data[1], data[2], data[3],
                        data[4], data[5], data[6], data[7]
                    );

                    contacts.Add(a);
                }
            }

            Console.WriteLine("Contacts loaded successfully from CSV file!");
        }
    }
}
