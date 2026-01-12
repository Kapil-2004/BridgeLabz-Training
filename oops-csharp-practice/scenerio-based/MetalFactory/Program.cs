using System;

namespace MetalFactory
{       
class Program
{
    static void Main()
    {
        Console.Write("Enter rod length: ");
        int length = int.Parse(Console.ReadLine());

        Rod rod = new Rod(length);
        RodCutting cutting = new RodCutting();

        int[] price = new int[length + 1]; 

        Console.WriteLine("\nEnter price for each rod length:");
        for (int i = 1; i <= length; i++)
        {
            Console.Write($"Price for length {i}: ");
            price[i] = int.Parse(Console.ReadLine());
        }

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- METAL FACTORY MENU ---");
            Console.WriteLine("1. Calculate Optimized Revenue");
            Console.WriteLine("2. Add / Update Custom Length Price");
            Console.WriteLine("3. Calculate Non-Optimized Revenue");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    int maxRevenue = cutting.GetMaxRevenue(rod.Length, price);
                    Console.WriteLine("Maximum Revenue (Optimized): ₹" + maxRevenue);
                    break;

                case 2:
                    Console.Write("Enter length to update price: ");
                    int l = int.Parse(Console.ReadLine());

                    if (l >= 1 && l <= rod.Length)
                    {
                        Console.Write("Enter new price: ");
                        price[l] = int.Parse(Console.ReadLine());
                        Console.WriteLine("Price updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid rod length.");
                    }
                    break;

                case 3:
                    int direct = cutting.GetDirectRevenue(rod.Length, price);
                    Console.WriteLine("Revenue without optimization: ₹" + direct);
                    break;

                case 4:
                    exit = true;
                    Console.WriteLine("Exiting Metal Factory System...");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
}