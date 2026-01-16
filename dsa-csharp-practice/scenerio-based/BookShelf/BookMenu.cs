using System;

namespace BookShelf
{
    public class BookMenu
    {
        private IBookShelfManager manager;

        public BookMenu()
        {
            manager = new BookShelfUtility();
        }

        public void ShowMenu()
        {
            int choice;

            do
            {
                Console.WriteLine("\n=== BookShelf Library ===");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.WriteLine("3. Display Books by Genre");
                Console.WriteLine("4. Display All Books");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        manager.AddBook();
                        break;

                    case 2:
                        manager.RemoveBook();
                        break;

                    case 3:
                        manager.DisplayByGenre();
                        break;

                    case 4:
                        manager.DisplayAll();
                        break;

                    case 0:
                        Console.WriteLine("Exiting Library System...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while (choice != 0);
        }
    }
}
