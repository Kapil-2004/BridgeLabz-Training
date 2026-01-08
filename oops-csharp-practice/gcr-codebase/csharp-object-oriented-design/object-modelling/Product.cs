using System;
using System.Collections.Generic;

// Product class
class Product
{
    public string ProductName { get; set; }
    public double Price { get; set; }

    public Product(string name, double price)
    {
        ProductName = name;
        Price = price;
    }

    public void Display()
    {
        Console.WriteLine($"Product: {ProductName}, Price: ₹{Price}");
    }
}

// Order class (Aggregates Products)
class Order
{
    public int OrderId { get; set; }
    public List<Product> Products { get; set; }

    public Order(int id)
    {
        OrderId = id;
        Products = new List<Product>();
    }

    // Communication: Order interacting with Product
    public void AddProduct(Product product)
    {
        Products.Add(product);
        Console.WriteLine($"{product.ProductName} added to Order {OrderId}");
    }

    public void DisplayOrder()
    {
        Console.WriteLine($"\nOrder ID: {OrderId}");
        foreach (Product p in Products)
            p.Display();
    }
}

// Customer class
class Customer
{
    public string Name { get; set; }

    public Customer(string name)
    {
        Name = name;
    }

    // Communication: Customer placing an Order
    public Order PlaceOrder(int orderId)
    {
        Console.WriteLine($"\nCustomer {Name} placed Order {orderId}");
        return new Order(orderId);
    }
}

class Program
{
    static void Main()
    {
        // Creating Products
        Product p1 = new Product("Laptop", 55000);
        Product p2 = new Product("Mouse", 500);
        Product p3 = new Product("Keyboard", 1200);

        // Creating Customer
        Customer customer = new Customer("Amit");

        // Customer places an Order
        Order order = customer.PlaceOrder(101);

        // Order aggregates Products
        order.AddProduct(p1);
        order.AddProduct(p2);
        order.AddProduct(p3);

        // Display Order details
        order.DisplayOrder();
    }
}
