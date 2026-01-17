using System;

namespace FlashDealz
{
    public class FlashDealzMenu
    {
        public void ShowMenu()   // ✅ method, not constructor
        {
            FlashDealzUtility utility = new FlashDealzUtility();
            int choice;

            do
            {
                Console.WriteLine("\n--- FlashDealz Menu ---");
                Console.WriteLine("1. Show Products");
                Console.WriteLine("2. Sort Products by Price (Quick Sort)");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        utility.ShowProducts();
                        break;
                    case 2:
                        utility.SortProducts();
                        break;
                    case 0:
                        Console.WriteLine("Exiting FlashDealz...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

            } while (choice != 0);
        }
    }
}
