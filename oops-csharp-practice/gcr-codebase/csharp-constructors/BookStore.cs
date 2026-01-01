using System;

class BookStore
{
    private string title;
    private string author;
    private double price;
    private bool availability;

    // Constructor
    public BookStore(string title, string author, double price)
    {
        this.title = title;
        this.author = author;
        this.price = price;
        this.availability = true;   // book is available initially
    }

    // Method to borrow a book
    public void BorrowBook()
    {
        if (availability)
        {
            availability = false;
            Console.WriteLine($"You have successfully borrowed \"{title}\".");
        }
        else
        {
            Console.WriteLine($"Sorry, \"{title}\" is currently not available.");
        }
    }

    // Method to display book details
    public void DisplayBook()
    {
        Console.WriteLine("Title        : " + title);
        Console.WriteLine("Author       : " + author);
        Console.WriteLine("Price        : Rs. " + price);
        Console.WriteLine("Availability : " + (availability ? "Available" : "Borrowed"));
        Console.WriteLine("----------------------------");
    }

    static void Main(string[] args)
    {
        BookStore book1 = new BookStore(Console.ReadLine(), Console.ReadLine(), double.Parse(Console.ReadLine()));

        book1.DisplayBook();

        book1.BorrowBook();   // First borrow attempt
        book1.BorrowBook();   // Second borrow attempt

        book1.DisplayBook();
    }
}
