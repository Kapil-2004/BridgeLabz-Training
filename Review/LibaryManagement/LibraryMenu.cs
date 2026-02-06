using System;

class Menu
{
    public static void ShowMenu()
    {
        Console.WriteLine("\n--- LIBRARY MENU ---");
        Console.WriteLine("1. Add Book");
        Console.WriteLine("2. Display Books");
        Console.WriteLine("3. Search Book by Title");
        Console.WriteLine("4. Checkout Book");
        Console.WriteLine("5. Exit");
        Console.Write("Enter choice: ");
    }
}
