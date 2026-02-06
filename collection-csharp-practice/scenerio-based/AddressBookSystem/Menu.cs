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

        public void ShowMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\n--- Address Book System ---");
                Console.WriteLine("1. Add Address Book");
                Console.WriteLine("2. Open Address Book");
                Console.WriteLine("3. List Address Books");
                Console.WriteLine("4. Search Person by City or State");
                Console.WriteLine("5. Search Persons Either by City or State");
                Console.WriteLine("6. Count Contacts by City or State");
                Console.WriteLine("7. Exit");
                Console.Write("Enter choice: ");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    choice = 0;
                }

                switch (choice)
                {
                    case 1:
                        manager.AddAddressBook();
                        break;

                    case 2:
                        AddressBookUtility book = manager.SelectAddressBook();
                        if (book != null)
                        {
                            ShowAddressBookMenu(book);
                        }
                        break;

                    case 3:
                        manager.ListAddressBooks();
                        break;

                    case 4:
                        {
                            // UC8: Search person by city or state in a single address book
                            AddressBookUtility bookToSearch = manager.SelectAddressBook();
                            if (bookToSearch != null)
                            {
                                bookToSearch.SearchPersonByCityOrState();
                            }
                            break;
                        }

                    case 5:
                        {
                            // UC9: Search persons by City OR State separately
                            AddressBookUtility bookToSearch = manager.SelectAddressBook();
                            if (bookToSearch != null)
                            {
                                Console.WriteLine("Search by:\n1. City\n2. State");
                                Console.Write("Enter choice: ");

                                int subChoice;
                                try
                                {
                                    subChoice = int.Parse(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid input.");
                                    break;
                                }

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

                    case 6:
                        {
                            // UC10: Count Contacts by City or State
                            AddressBookUtility bookToCount = manager.SelectAddressBook();
                            if (bookToCount != null)
                            {
                                Console.WriteLine("Count by:\n1. City\n2. State");
                                Console.Write("Enter choice: ");

                                int subChoice;
                                try
                                {
                                    subChoice = int.Parse(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid input.");
                                    break;
                                }

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

                    case 7:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 7);
        }

        private void ShowAddressBookMenu(AddressBookUtility utility)
        {
            int choice;

            do
            {
                Console.WriteLine("\n--- Address Book Menu ---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Add Multiple Contacts");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Delete Contact");

                // UC12: Ability to sort the entries in the address book by City, State, or Zip
                Console.WriteLine("5. Sort Contacts");

                // UC13: Ability to Read/Write the Address Book with Persons Contact as CSV File
                Console.WriteLine("6. Write Contacts to CSV");
                Console.WriteLine("7. Read Contacts from CSV");

                Console.WriteLine("8. Back");
                Console.Write("Enter choice: ");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    choice = 0;
                }

                switch (choice)
                {
                    case 1:
                        utility.AddAddress();
                        break;

                    case 2:
                        utility.AddMultipleAddresses();
                        break;

                    case 3:
                        utility.EditAddressByName();
                        break;

                    case 4:
                        utility.DeleteAddressByName();
                        break;

                    case 5:
                        {
                            // UC12: Sort contacts by City, State, or Zip
                            Console.WriteLine("\nSort by:\n1. City\n2. State\n3. Zip");
                            Console.Write("Enter choice: ");

                            int sortChoice;
                            try
                            {
                                sortChoice = int.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Invalid input.");
                                break;
                            }

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

                    case 6:
                        {
                            // UC13: Write contacts to CSV
                            Console.Write("Enter CSV File Path to Save: ");
                            string path = Console.ReadLine();
                            utility.WriteContactsToCSV(path);
                            break;
                        }

                    case 7:
                        {
                            // UC13: Read contacts from CSV
                            Console.Write("Enter CSV File Path to Load: ");
                            string path = Console.ReadLine();
                            utility.ReadContactsFromCSV(path);
                            break;
                        }

                    case 8:
                        // Back
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 8);
        }
    }
}
