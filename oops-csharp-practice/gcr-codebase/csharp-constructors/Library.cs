using System;

// Base class
class Library
{
    public string ISBN;        // Public
    protected string title;    // Protected
    private string author;     // Private

    // Constructor
    public Library(string ISBN, string title, string author)
    {
        this.ISBN = ISBN;
        this.title = title;
        this.author = author;
    }

    // Setter for author
    public void SetAuthor(string author)
    {
        this.author = author;
    }

    // Getter for author
    public string GetAuthor()
    {
        return author;
    }
}

// Derived class
class EBook : Book
{
    public EBook(string ISBN, string title, string author)
        : base(ISBN, title, author)
    {
    }

    // Accessing public and protected members
    public void DisplayEBookDetails()
    {
        Console.WriteLine("ISBN   : " + ISBN);     // Public
        Console.WriteLine("Title  : " + title);    // Protected
        Console.WriteLine("Author : " + GetAuthor()); // Private via method
        Console.WriteLine("---------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter ISBN: ");
        string isbn = Console.ReadLine();

        Console.Write("Enter Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Author: ");
        string author = Console.ReadLine();

        EBook ebook = new EBook(isbn, title, author);

        Console.WriteLine("\nEBook Details:");
        ebook.DisplayEBookDetails();

        Console.Write("\nEnter new Author name: ");
        string newAuthor = Console.ReadLine();

        ebook.SetAuthor(newAuthor);

        Console.WriteLine("\nUpdated EBook Details:");
        ebook.DisplayEBookDetails();
    }
}
