using System;

namespace AddressBookSystem
{
    public class Menu
    {
        private AddressBookManagerUtility manager;

        public Menu(AddressBookManagerUtility manager)
        {
            this.manager = manager;
        }

        // Main Menu for Address Book System
        public void ShowMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\n--- Address Book System ---");

                // UC1: Ability to add multiple Address Books
                Console.WriteLine("1. Add Address Book");

                // UC1: Ability to open an existing Address Book
                Console.WriteLine("2. Open Address Book");

                // UC1: Ability to list all Address Books
                Console.WriteLine("3. List Address Books");

                // UC8: Search person by City or State within a single address book
                Console.WriteLine("4. Search Person by City or State");

                // UC9: Search persons either by City or State separately
                Console.WriteLine("5. Search Persons Either by City or State");

                // UC10: Count persons by City or State separately
                Console.WriteLine("6. Count Contacts by City or State");

                // Exit
                Console.WriteLine("7. Exit");

                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    // UC1: Add Address Book
                    case 1:
                        manager.AddAddressBook();
                        break;

                    // UC1: Open Address Book
                    case 2:
                        AddressBookUtility book = manager.SelectAddressBook();
                        if (book != null)
                        {
                            ShowAddressBookMenu(book);
                        }
                        break;

                    // UC1: List Address Books
                    case 3:
                        manager.ListAddressBooks();
                        break;

                    // UC8: Search person by city or state in a single address book
                    case 4:
                        {
                            AddressBookUtility bookToSearch = manager.SelectAddressBook();
                            if (bookToSearch != null)
                            {
                                bookToSearch.SearchPersonByCityOrState();
                            }
                            break;
                        }

                    // UC9: Search persons by City OR State separately
                    case 5:
                        {
                            AddressBookUtility bookToSearch = manager.SelectAddressBook();
                            if (bookToSearch != null)
                            {
                                Console.WriteLine("Search by:\n1. City\n2. State");
                                Console.Write("Enter choice: ");
                                int subChoice = int.Parse(Console.ReadLine());

                                if (subChoice == 1)
                                {
                                    bookToSearch.SearchByCity();
                                }
                                else if (subChoice == 2)
                                {
                                    bookToSearch.SearchByState();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice.");
                                }
                            }
                            break;
                        }

                    // UC10: Count contacts by City or State separately
                    case 6:
                        {
                            AddressBookUtility bookToCount = manager.SelectAddressBook();
                            if (bookToCount != null)
                            {
                                Console.WriteLine("Count by:\n1. City\n2. State");
                                Console.Write("Enter choice: ");
                                int subChoice = int.Parse(Console.ReadLine());

                                if (subChoice == 1)
                                {
                                    bookToCount.CountByCity();
                                }
                                else if (subChoice == 2)
                                {
                                    bookToCount.CountByState();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid choice.");
                                }
                            }
                            break;
                        }

                    // Exit
                    case 7:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 7);
        }

        // Sub Menu for operations inside a selected Address Book
        private void ShowAddressBookMenu(AddressBookUtility utility)
        {
            int choice;

            do
            {
                Console.WriteLine("\n--- Address Book Menu ---");

                // UC2: Add Contact
                Console.WriteLine("1. Add Contact");

                // UC5: Add Multiple Contacts
                Console.WriteLine("2. Add Multiple Contacts");

                // UC3: Edit Contact
                Console.WriteLine("3. Edit Contact");

                // UC4: Delete Contact
                Console.WriteLine("4. Delete Contact");

                // UC12: Sort entries by City, State, or Zip
                Console.WriteLine("5. Sort Contacts (City/State/Zip)");

                // UC13: Write contacts to file using File IO
                Console.WriteLine("6. Save Contacts To File");

                // UC13: Read contacts from file using File IO
                Console.WriteLine("7. Load Contacts From File");

                // UC14: Write contacts to CSV file
                Console.WriteLine("8. Save Contacts To CSV");

                // UC14: Read contacts from CSV file
                Console.WriteLine("9. Load Contacts From CSV");

                // Back
                Console.WriteLine("10. Back");

                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    // UC2: Add Contact
                    case 1:
                        utility.AddAddress();
                        break;

                    // UC5: Add Multiple Contacts
                    case 2:
                        utility.AddMultipleAddresses();
                        break;

                    // UC3: Edit Contact
                    case 3:
                        utility.EditAddressByName();
                        break;

                    // UC4: Delete Contact
                    case 4:
                        utility.DeleteAddressByName();
                        break;

                    // UC12: Sort by City / State / Zip
                    case 5:
                        {
                            Console.WriteLine("Sort by:\n1. City\n2. State\n3. Zip");
                            Console.Write("Enter choice: ");
                            int sortChoice = int.Parse(Console.ReadLine());

                            if (sortChoice == 1)
                            {
                                utility.SortByCity();
                            }
                            else if (sortChoice == 2)
                            {
                                utility.SortByState();
                            }
                            else if (sortChoice == 3)
                            {
                                utility.SortByZip();
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                            }
                            break;
                        }

                    // UC13: Save to normal file
                    case 6:
                        utility.WriteContactsToFile();
                        break;

                    // UC13: Load from normal file
                    case 7:
                        utility.ReadContactsFromFile();
                        break;

                    // UC14: Save to CSV file
                    case 8:
                        utility.WriteContactsToCSV();
                        break;

                    // UC14: Load from CSV file
                    case 9:
                        utility.ReadContactsFromCSV();
                        break;

                    // Back
                    case 10:
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 10);
        }
    }
}
