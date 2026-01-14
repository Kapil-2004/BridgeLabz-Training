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
                Console.WriteLine("4. Exit");
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
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 4);
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
