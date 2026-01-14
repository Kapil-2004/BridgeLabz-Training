using System;

namespace AddressBookSystem
{
    // Menu class handles user interaction
    public class Menu
    {
        private AddressBookUtility utility;

        // Constructor receives utility object
        public Menu(AddressBookUtility utility)
        {
            this.utility = utility;
        }

        // Displays menu and handles user choices
        public void ShowMenu()
        {
            int choice;

            do
            {
                Console.WriteLine("\n--- Address Book Menu ---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Add Multiple Contacts");
                Console.WriteLine("3. Edit Contact by Name");
                Console.WriteLine("4. Delete Contact by Name");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
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

                    case 5:
                        Console.WriteLine("Exiting Address Book...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            } while (choice != 5);
        }
    }
}
