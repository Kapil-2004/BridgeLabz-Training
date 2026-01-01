using System;

class Book
{
    // Attributes
    string title;
    string author;
    double price;

    // Default Constructor
    public Book()
    {
        title = "Unknown";
        author = "Unknown";
        price = 0.0;
    }

    // Parameterized Constructor
    public Book(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
    }

    // Method to display book details
    public void DisplayBook()
    {
        Console.WriteLine("Title  : " + title);
        Console.WriteLine("Author : " + author);
        Console.WriteLine("Price  : Rs. " + price);
        Console.WriteLine("-----------------------");
    }

    static void Main(string[] args)
    {
        // Using parameterized constructor
        Console.WriteLine("Enter title: ");
        string inputTitle = Console.ReadLine();
        Console.WriteLine("Enter author: ");
        string inputAuthor = Console.ReadLine();
        Console.WriteLine("Enter price: ");
        double inputPrice = double.Parse(Console.ReadLine());
        Book book2 = new Book(inputTitle, inputAuthor, inputPrice);
        book2.DisplayBook();

        
        // Using default constructor
        Book book1 = new Book();
        book1.DisplayBook();

    }
}
