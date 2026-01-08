using System;
using System.Collections.Generic;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public void DisplayBook()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}");
    }
}

// Library class (aggregates Book objects)
class Library
{
    public string LibraryName { get; set; }
    public List<Book> Books { get; set; }

    public Library(string name)
    {
        LibraryName = name;
        Books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void DisplayLibraryBooks()
    {
        Console.WriteLine($"\nBooks in {LibraryName}:");
        foreach (Book book in Books)
        {
            book.DisplayBook();
        }
    }
}

class Program
{
    static void Main()
    {
        // Creating Book objects independently
        Book b1 = new Book("Clean Code", "Robert C. Martin");
        Book b2 = new Book("The Pragmatic Programmer", "Andrew Hunt");
        Book b3 = new Book("Design Patterns", "Erich Gamma");

        // Creating Library objects
        Library lib1 = new Library("City Library");
        Library lib2 = new Library("College Library");

        // Adding books to libraries
        lib1.AddBook(b1);
        lib1.AddBook(b2);

        lib2.AddBook(b2);  // Same book in another library
        lib2.AddBook(b3);

        // Displaying library contents
        lib1.DisplayLibraryBooks();
        lib2.DisplayLibraryBooks();
    }
}
