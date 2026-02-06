using System;

class LibraryUtility : ILibrary
{
    private Book[] books;
    private int count;

    public LibraryUtility(int size)
    {
        books = new Book[size];
        count = 0;
    }

    public void AddBook(string title, string author)
    {
        if (count >= books.Length)
        {
            Console.WriteLine("Library is full.");
            return;
        }

        books[count++] = new Book(title, author);
        Console.WriteLine("Book added successfully.");
    }

    public void DisplayBooks()
    {
        Console.WriteLine("\n--- BOOK LIST ---");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(
                (i+1) + ". " +
                books[i].Title + " | " +
                books[i].Author + " | " +
                (books[i].IsAvailable ? "Available" : "Checked Out")
            );
        }
    }

    public void SearchBookByTitle(string title)
    {
        bool found = false;
        title = title.ToLower();

        for (int i = 0; i < count; i++)
        {
            if (books[i].Title.ToLower().Contains(title))
            {
                Console.WriteLine(
                    i + ". " +
                    books[i].Title + " | " +
                    books[i].Author + " | " +
                    (books[i].IsAvailable ? "Available" : "Checked Out")
                );
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No matching book found.");
    }

    public void CheckoutBook(int index)
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Invalid book index.");
            return;
        }

        if (books[index].IsAvailable)
        {
            books[index].IsAvailable = false;
            Console.WriteLine("Book checked out successfully.");
        }
        else
        {
            Console.WriteLine("Book already checked out.");
        }
    }
}
