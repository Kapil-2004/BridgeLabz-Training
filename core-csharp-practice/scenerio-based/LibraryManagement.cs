using System;

class LibraryManagement
{
    // 2D Array: [BookIndex, Details]
    // 0 = Title, 1 = Author, 2 = Status
    static string[,] books =
    {
        { "The Alchemist", "Paulo Coelho", "Available" },
        { "Clean Code", "Robert C. Martin", "Checked Out" },
        { "Effective Python", "James Clear", "Available" },
        { "Rich Dad Poor Dad", "Robert Kiyosaki", "Available" },
        { "Think and Grow Rich", "Napoleon Hill", "Available" },
        { "Introduction to Algorithms", "Thomas H. Cormen", "Available" },
        { "The Pragmatic Programmer", "Andrew Hunt", "Checked Out" },
        { "Effective Java", "Joshua Bloch", "Available" },
        { "Design Patterns", "Erich Gamma", "Available" },
        { "You Don’t Know JS", "Kyle Simpson", "Available" }
    };

    static void Main(string[] args)
{
    while (true)
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("--------------- Library Management System ----------------\n");

        DisplayBooks();

        Console.Write("\nEnter book title to search (partial allowed): ");
        string searchedTitle = Console.ReadLine();
        SearchByTitle(searchedTitle);

        Console.Write("\nEnter exact book title to checkout: ");
        string checkoutTitle = Console.ReadLine();
        CheckoutBook(checkoutTitle);

        Console.WriteLine("\nUpdated Book List:\n");
        DisplayBooks();

        Console.WriteLine("\nPress 0 to exit OR press any other key to continue...");
        string choice = Console.ReadLine();

        if (choice == "0")
        {
            Console.WriteLine("Exiting Library Management System...");
            break;
        }
    }
}


    // Display all books
   static void DisplayBooks()
{
    Console.WriteLine("--------------------------------------------------------------------------");
    Console.WriteLine("{0,-35} {1,-25} {2,-15}", "TITLE", "AUTHOR", "STATUS");
    Console.WriteLine("--------------------------------------------------------------------------");

    for (int i = 0; i < books.GetLength(0); i++)
    {
        Console.WriteLine(
            "{0,-35} {1,-25} {2,-15}",
            books[i, 0],
            books[i, 1],
            books[i, 2]
        );
    }

    Console.WriteLine("--------------------------------------------------------------------------");
}
    // Partial title search
    static void SearchByTitle(string searchedTitle)
    {
        bool found = false;

        Console.WriteLine("\nSearch Results:");
        Console.WriteLine("----------------------------------------------------------");

        for (int i = 0; i < books.GetLength(0); i++)
        {
            if (books[i, 0].IndexOf(searchedTitle, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Console.WriteLine($"{books[i, 0]} | {books[i, 1]} | {books[i, 2]}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No matching books found.");
        }

        Console.WriteLine("----------------------------------------------------------");
    }

    // Checkout a book
    static void CheckoutBook(string title)
    {
        for (int i = 0; i < books.GetLength(0); i++)
        {
            if (string.Equals(books[i, 0], title, StringComparison.OrdinalIgnoreCase))
            {
                if (books[i, 2] == "Available")
                {
                    books[i, 2] = "Checked Out";
                    Console.WriteLine("Book checked out successfully.");
                }
                else
                {
                    Console.WriteLine("Book is already checked out.");
                }
                return;
            }
        }

        Console.WriteLine("Book not found.");
    }
}
