using System;

class Product
{
    // static variable (shared discount for all products)
    public static double Discount = 10.0; // in percentage

    // readonly variable
    public readonly int ProductID;

    // instance variables
    public string ProductName;
    public double Price;
    public int Quantity;

    // constructor using 'this'
    public Product(string ProductName, int ProductID, double Price, int Quantity)
    {
        this.ProductName = ProductName;
        this.ProductID = ProductID;   // readonly value set once
        this.Price = Price;
        this.Quantity = Quantity;
    }

    // static method to update discount
    public static void UpdateDiscount(double newDiscount)
    {
        Discount = newDiscount;
    }

    // method to calculate total price after discount
    public double CalculateTotal()
    {
        double total = Price * Quantity;
        double discountAmount = (Discount / 100) * total;
        return total - discountAmount;
    }

    // method to display product details
    public void DisplayDetails()
    {
        Console.WriteLine("Product Name : " + ProductName);
        Console.WriteLine("Product ID   : " + ProductID);
        Console.WriteLine("Price        : " + Price);
        Console.WriteLine("Quantity     : " + Quantity);
        Console.WriteLine("Discount (%) : " + Discount);
        Console.WriteLine("Final Amount : " + CalculateTotal());
    }
}

class Program
{
    static void Main()
    {
        Product p1 = new Product("Laptop", 501, 60000, 1);
        Product p2 = new Product("Headphones", 502, 2000, 2);

        // update static discount
        Product.UpdateDiscount(15.0);

        // is operator usage
        if (p1 is Product)
        {
            Console.WriteLine("\nProduct 1 Details:");
            p1.DisplayDetails();
        }

        if (p2 is Product)
        {
            Console.WriteLine("\nProduct 2 Details:");
            p2.DisplayDetails();
        }
    }
}
