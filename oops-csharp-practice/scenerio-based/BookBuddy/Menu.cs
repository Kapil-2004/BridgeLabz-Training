using System;

namespace BookBuddy
{
    class Menu
    {
        private IBookBuddy bookBuddy;

        public Menu(IBookBuddy bookBuddy)
        {
            this.bookBuddy = bookBuddy;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- BookBuddy Menu ---");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Display Books");
                Console.WriteLine("3. Sort Books");
                Console.WriteLine("4. Search by Author");
                Console.WriteLine("5. Export & Exit");

                Console.Write("Choose option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Book Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Author Name: ");
                        string author = Console.ReadLine();
                        bookBuddy.AddBook(title, author);
                        break;

                    case 2:
                        bookBuddy.DisplayBooks();
                        break;

                    case 3:
                        bookBuddy.SortBooksAlphabetically();
                        break;

                    case 4:
                        Console.Write("Enter Author Name: ");
                        bookBuddy.SearchByAuthor(Console.ReadLine());
                        break;

                    case 5:
                        string[] exported = bookBuddy.ExportBooks();
                        Console.WriteLine("Exported Books:");
                        foreach (string book in exported)
                            Console.WriteLine(book);
                        return;
                }
            }
        }
    }
}
