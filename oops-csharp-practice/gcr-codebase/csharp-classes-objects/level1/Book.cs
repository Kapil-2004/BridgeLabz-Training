using System;

// Class Definition
class Book
{
    // Attributes (Fields)
    private string title;
    private string author;
    private double price;

    // Constructor
    public Book(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }

    // Method to display book details
    public void DisplayDetails()
    {
        Console.WriteLine("Book Title  : " + title);
        Console.WriteLine("Author      : " + author);
        Console.WriteLine("Price       : ₹" + price);
    }
}

class Program
{
    static void Main()
    {
        // Create Book object
        Book b1 = new Book("Clean Code", "Robert C. Martin", 499);

        // Display book details
        b1.DisplayDetails();
    }
}
