using System;

class MainApp
{
    public void Run()
    {
        ILibrary library = new LibraryUtility(10);

        bool exit = false;

        while (!exit)
        {
            Menu.ShowMenu();
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();
                    library.AddBook(title, author);
                    break;

                case 2:
                    library.DisplayBooks();
                    break;

                case 3:
                    Console.Write("Enter title keyword: ");
                    library.SearchBookByTitle(Console.ReadLine());
                    break;

                case 4:
                    Console.Write("Enter book index: ");
                    int index = int.Parse(Console.ReadLine());
                    library.CheckoutBook(index);
                    break;

                case 5:
                    exit = true;
                    Console.WriteLine("Exiting Library System...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
