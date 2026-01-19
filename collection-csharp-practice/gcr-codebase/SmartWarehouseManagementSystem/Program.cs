using System;

class Program
{
    static void Main()
    {
        Storage<Electronics> electronicsStorage = new Storage<Electronics>();
        electronicsStorage.AddItem(new Electronics("Laptop", 75000, 2));
        electronicsStorage.AddItem(new Electronics("Phone", 30000, 1));

        Storage<Groceries> groceryStorage = new Storage<Groceries>();
        groceryStorage.AddItem(new Groceries("Milk", 50, DateTime.Now.AddDays(5)));

        Console.WriteLine("Electronics Items:");
        electronicsStorage.DisplayAllItems();

        Console.WriteLine("\nGrocery Items:");
        groceryStorage.DisplayAllItems();
    }
}
