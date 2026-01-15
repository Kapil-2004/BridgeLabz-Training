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
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());

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
                            // Search person by city or state in a single address book
                            AddressBookUtility bookToSearch = manager.SelectAddressBook();
                            if (bookToSearch != null)
                            {
                                bookToSearch.SearchPersonByCityOrState();
                            }
                            break;
                        }

                    case 5:
                        {
                            // Search persons by City OR State separately
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

                    case 6:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 6);
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
                Console.WriteLine("5. Back");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());

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
                }

            } while (choice != 5);
        }
    }
}
