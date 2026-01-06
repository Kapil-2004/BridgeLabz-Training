using System;

class Book
{
    // static variable (shared across all books)
    public static string LibraryName = "Central City Library";

    // readonly variable
    public readonly string ISBN;

    // instance variables
    public string Title;
    public string Author;

    // constructor using 'this'
    public Book(string Title, string Author, string ISBN)
    {
        this.Title = Title;
        this.Author = Author;
        this.ISBN = ISBN; // readonly value set only once
    }

    // static method
    public static void DisplayLibraryName()
    {
        Console.WriteLine("Library Name: " + LibraryName);
    }

    // method to display book details
    public void DisplayDetails()
    {
        Console.WriteLine("Title : " + Title);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("ISBN  : " + ISBN);
    }
}

class Program
{
    static void Main()
    {
        Book book1 = new Book("Clean Code", "Robert C. Martin", "978-0132350884");
        Book book2 = new Book("The Alchemist", "Paulo Coelho", "978-0061122415");

        // static method call
        Book.DisplayLibraryName();
        Console.WriteLine();

        // is operator usage
        if (book1 is Book)
        {
            Console.WriteLine("Book 1 Details:");
            book1.DisplayDetails();
        }

        Console.WriteLine();

        if (book2 is Book)
        {
            Console.WriteLine("Book 2 Details:");
            book2.DisplayDetails();
        }
    }
}
