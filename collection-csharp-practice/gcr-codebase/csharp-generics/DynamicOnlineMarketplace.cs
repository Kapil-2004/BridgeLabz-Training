using System;
using System.Collections.Generic;

//
// Base category (constraint root)
//
public abstract class ProductCategory
{
    public string Name { get; set; }

    protected ProductCategory(string name)
    {
        Name = name;
    }
}

//
// Concrete categories
//
public class BookCategory : ProductCategory
{
    public BookCategory(string name) : base(name) { }
}

public class ClothingCategory : ProductCategory
{
    public ClothingCategory(string name) : base(name) { }
}

//
// Generic Product class with constraint
//
public class Product<T> where T : ProductCategory
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public T Category { get; set; }

    public Product(string productName, double price, T category)
    {
        ProductName = productName;
        Price = price;
        Category = category;
    }

    public void Display()
    {
        Console.WriteLine(
            $"Product: {ProductName}, Price: {Price:C}, Category: {Category.Name}"
        );
    }
}

//
// Generic catalog to ensure type safety
//
public class Catalog<T> where T : ProductCategory
{
    private List<Product<T>> products = new List<Product<T>>();

    public void Add(Product<T> product)
    {
        products.Add(product);
    }

    public void DisplayAll()
    {
        foreach (var product in products)
        {
            product.Display();
        }
    }
}

//
// Generic method with constraint
//
public static class DiscountService
{
    public static void ApplyDiscount<T>(
        Product<T> product,
        double percentage
    ) where T : ProductCategory
    {
        product.Price -= product.Price * (percentage / 100);
    }
}

//
// Main Program
//
class DynamicOnlineMarketplace
{
    static void Main()
    {
        // Book products
        Catalog<BookCategory> bookCatalog = new Catalog<BookCategory>();
        Product<BookCategory> book =
            new Product<BookCategory>("C# in Depth", 500, new BookCategory("Programming"));

        bookCatalog.Add(book);

        // Clothing products
        Catalog<ClothingCategory> clothingCatalog = new Catalog<ClothingCategory>();
        Product<ClothingCategory> shirt =
            new Product<ClothingCategory>("T-Shirt", 800, new ClothingCategory("Casual"));

        clothingCatalog.Add(shirt);

        // Apply discounts
        DiscountService.ApplyDiscount(book, 10);
        DiscountService.ApplyDiscount(shirt, 20);

        // Display catalogs
        Console.WriteLine("Books:");
        bookCatalog.DisplayAll();

        Console.WriteLine("\nClothing:");
        clothingCatalog.DisplayAll();
    }
}
