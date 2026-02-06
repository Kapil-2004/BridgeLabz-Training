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
            // capacity kept so your existing manager code stays same
            contacts = new List<Address>(capacity);
        }

        // UC2: Add a new Address
        public void AddAddress()
        {
            try
            {
                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                {
                    Console.WriteLine("First Name and Last Name cannot be empty.");
                    return;
                }

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
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding contact: " + ex.Message);
            }
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
            try
            {
                Console.Write("Enter the First Name of the contact to edit: ");
                string firstName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(firstName))
                {
                    Console.WriteLine("First Name cannot be empty.");
                    return;
                }

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
            catch (Exception ex)
            {
                Console.WriteLine("Error while editing contact: " + ex.Message);
            }
        }

        // UC4: Delete a contact by first name
        public void DeleteAddressByName()
        {
            try
            {
                Console.Write("Enter the First Name of the contact to delete: ");
                string searchName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(searchName))
                {
                    Console.WriteLine("First Name cannot be empty.");
                    return;
                }

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
            catch (Exception ex)
            {
                Console.WriteLine("Error while deleting contact: " + ex.Message);
            }
        }

        // UC5: Add multiple contacts
        public void AddMultipleAddresses()
        {
            try
            {
                char choice;

                do
                {
                    AddAddress();
                    Console.Write("Do you want to add another contact? (y/n): ");

                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Invalid input. Stopping multiple add.");
                        return;
                    }

                    choice = char.ToLower(input[0]);

                } while (choice == 'y');
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding multiple contacts: " + ex.Message);
            }
        }

        // UC8: Search person by City or State within this Address Book
        public void SearchPersonByCityOrState()
        {
            try
            {
                Console.Write("Enter City: ");
                string city = Console.ReadLine();

                Console.Write("Enter State: ");
                string state = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(city) && string.IsNullOrWhiteSpace(state))
                {
                    Console.WriteLine("City or State must be entered.");
                    return;
                }

                bool found = false;

                SortByPersonName();

                for (int i = 0; i < contacts.Count; i++)
                {
                    if ((!string.IsNullOrWhiteSpace(city) &&
                        contacts[i].City.Equals(city, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrWhiteSpace(state) &&
                        contacts[i].State.Equals(state, StringComparison.OrdinalIgnoreCase)))
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
            catch (Exception ex)
            {
                Console.WriteLine("Error while searching: " + ex.Message);
            }
        }

        // UC9: search persons by City or State - separate methods
        // Search persons by City
        public void SearchByCity()
        {
            try
            {
                Console.Write("Enter City: ");
                string city = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(city))
                {
                    Console.WriteLine("City cannot be empty.");
                    return;
                }

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
            catch (Exception ex)
            {
                Console.WriteLine("Error while searching by city: " + ex.Message);
            }
        }

        // Search persons by State
        public void SearchByState()
        {
            try
            {
                Console.Write("Enter State: ");
                string state = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(state))
                {
                    Console.WriteLine("State cannot be empty.");
                    return;
                }

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
            catch (Exception ex)
            {
                Console.WriteLine("Error while searching by state: " + ex.Message);
            }
        }

        // UC10: Count persons by City or State - separate methods
        // Count contacts by City
        public void CountByCity()
        {
            try
            {
                Console.Write("Enter City: ");
                string city = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(city))
                {
                    Console.WriteLine("City cannot be empty.");
                    return;
                }

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
            catch (Exception ex)
            {
                Console.WriteLine("Error while counting by city: " + ex.Message);
            }
        }

        // Count contacts by State
        public void CountByState()
        {
            try
            {
                Console.Write("Enter State: ");
                string state = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(state))
                {
                    Console.WriteLine("State cannot be empty.");
                    return;
                }

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
            catch (Exception ex)
            {
                Console.WriteLine("Error while counting by state: " + ex.Message);
            }
        }

        // UC11: Sort contacts alphabetically by FirstName, then LastName
        private void SortByPersonName()
        {
            for (int i = 0; i < contacts.Count - 1; i++)
            {
                for (int j = i + 1; j < contacts.Count; j++)
                {
                    int firstNameCompare =
                        string.Compare(contacts[i].FirstName, contacts[j].FirstName, true);

                    if (firstNameCompare > 0 ||
                        (firstNameCompare == 0 &&
                        string.Compare(contacts[i].LastName, contacts[j].LastName, true) > 0))
                    {
                        Address temp = contacts[i];
                        contacts[i] = contacts[j];
                        contacts[j] = temp;
                    }
                }
            }
        }

        // UC12: Ability to sort the entries in the address book by City
        public void SortByCity()
        {
            try
            {
                for (int i = 0; i < contacts.Count - 1; i++)
                {
                    for (int j = i + 1; j < contacts.Count; j++)
                    {
                        if (string.Compare(contacts[i].City, contacts[j].City, true) > 0)
                        {
                            Address temp = contacts[i];
                            contacts[i] = contacts[j];
                            contacts[j] = temp;
                        }
                    }
                }

                Console.WriteLine("Contacts sorted by City successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while sorting by city: " + ex.Message);
            }
        }

        // UC12: Ability to sort the entries in the address book by State
        public void SortByState()
        {
            try
            {
                for (int i = 0; i < contacts.Count - 1; i++)
                {
                    for (int j = i + 1; j < contacts.Count; j++)
                    {
                        if (string.Compare(contacts[i].State, contacts[j].State, true) > 0)
                        {
                            Address temp = contacts[i];
                            contacts[i] = contacts[j];
                            contacts[j] = temp;
                        }
                    }
                }

                Console.WriteLine("Contacts sorted by State successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while sorting by state: " + ex.Message);
            }
        }

        // UC12: Ability to sort the entries in the address book by Zip
        public void SortByZip()
        {
            try
            {
                for (int i = 0; i < contacts.Count - 1; i++)
                {
                    for (int j = i + 1; j < contacts.Count; j++)
                    {
                        if (string.Compare(contacts[i].Zip, contacts[j].Zip, true) > 0)
                        {
                            Address temp = contacts[i];
                            contacts[i] = contacts[j];
                            contacts[j] = temp;
                        }
                    }
                }

                Console.WriteLine("Contacts sorted by Zip successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while sorting by zip: " + ex.Message);
            }
        }

        // UC13: Ability to Write the Address Book with Persons Contact as CSV File
        public void WriteContactsToCSV(string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    Console.WriteLine("File path cannot be empty.");
                    return;
                }

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email");

                    for (int i = 0; i < contacts.Count; i++)
                    {
                        Address c = contacts[i];

                        string line =
                            EscapeCsv(c.FirstName) + "," +
                            EscapeCsv(c.LastName) + "," +
                            EscapeCsv(c.AddressLine) + "," +
                            EscapeCsv(c.City) + "," +
                            EscapeCsv(c.State) + "," +
                            EscapeCsv(c.Zip) + "," +
                            EscapeCsv(c.PhoneNumber) + "," +
                            EscapeCsv(c.Email);

                        writer.WriteLine(line);
                    }
                }

                Console.WriteLine("Contacts saved to CSV successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while writing CSV: " + ex.Message);
            }
        }

        // UC13: Ability to Read the Address Book with Persons Contact as CSV File
        public void ReadContactsFromCSV(string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    Console.WriteLine("File path cannot be empty.");
                    return;
                }

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("CSV file not found: " + filePath);
                    return;
                }

                contacts.Clear();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string header = reader.ReadLine(); // skip header

                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        string[] parts = SplitCsvLine(line);

                        if (parts.Length == 8)
                        {
                            Address contact = new Address(
                                parts[0], parts[1], parts[2],
                                parts[3], parts[4], parts[5],
                                parts[6], parts[7]
                            );

                            contacts.Add(contact);
                        }
                    }
                }

                Console.WriteLine("Contacts loaded from CSV successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while reading CSV: " + ex.Message);
            }
        }

        // Helps write proper CSV values
        private string EscapeCsv(string value)
        {
            if (value == null)
                return "";

            value = value.Replace("\"", "\"\"");

            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                return "\"" + value + "\"";
            }

            return value;
        }

        // Helps read proper CSV values (simple CSV parsing)
        private string[] SplitCsvLine(string line)
        {
            List<string> values = new List<string>();
            bool inQuotes = false;
            string current = "";

            for (int i = 0; i < line.Length; i++)
            {
                char ch = line[i];

                if (ch == '"')
                {
                    // Handle escaped quote
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current += '"';
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (ch == ',' && !inQuotes)
                {
                    values.Add(current);
                    current = "";
                }
                else
                {
                    current += ch;
                }
            }

            values.Add(current);
            return values.ToArray();
        }
    }
}
