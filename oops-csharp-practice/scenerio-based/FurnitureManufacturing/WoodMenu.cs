using System;

class Menu
{
    public static void ShowMenu()
    {
        Console.WriteLine("\n--- FURNITURE FACTORY MENU ---");
        Console.WriteLine("1. Maximize Revenue");
        Console.WriteLine("2. Revenue with Waste Constraint");
        Console.WriteLine("3. Best Revenue with Minimal Waste");
        Console.WriteLine("4. Exit");
        Console.Write("Enter choice: ");
    }
}
