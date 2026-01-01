using System;

class Product
{
    // Instance variables
    private string productName;
    private double price;

    // Class variable (shared)
    private static int totalProducts = 0;

    // Constructor
    public Product(string productName, double price)
    {
        this.productName = productName;
        this.price = price;
        totalProducts++;   // increase count when object is created
    }

    // Instance method
    public void DisplayProductDetails()
    {
        Console.WriteLine("Product Name : " + productName);
        Console.WriteLine("Price        : Rs. " + price);
        Console.WriteLine("-------------------------");
    }

    // Class (static) method
    public static void DisplayTotalProducts()
    {
        Console.WriteLine("Total Products Created: " + totalProducts);
    }

    static void Main(string[] args)
    {
        Console.Write("Enter number of products: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"\nEnter details for Product {i}");

            Console.Write("Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Product p = new Product(name, price);
            p.DisplayProductDetails();
        }

        // Display total products created
        Product.DisplayTotalProducts();
    }
}
