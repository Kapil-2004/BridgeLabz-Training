using System;
using System.Collections;
using System.ComponentModel;

class CafeteriaMenu
{
    static string[,] menu = {
        { "Veg Sandwich", "50" },
        { "Chicken Burger", "120" },
        { "Paneer Roll", "80" },
        { "Masala Dosa", "70" },
        { "Veg Fried Rice", "90" },
        { "Chicken Biryani", "150" },
        { "French Fries", "60" },
        { "Pasta", "110" },
        { "Cold Coffee", "70" },
        { "Tea", "20" }
    };

    static int totalBill = 0;
    static ArrayList selectedItems = new ArrayList();

    // 1. Display the menu
    static void DisplayMenu()
    {
        Console.WriteLine("Cafeteria Menu:\n");
        for (int i = 0; i < menu.GetLength(0); i++)
        {
            Console.WriteLine($"{i + 1}. {menu[i, 0]} - Rs. {menu[i, 1]}");
        }
    }

    // 2. Display selected item
    static void DisplayItem(int index)
    {
        Console.WriteLine($"\nSelected Item: {menu[index, 0]}");
        Console.WriteLine($"Price: Rs. {menu[index, 1]}");
    }

    // 3. Calculate bill for one item
    static int CalculateTotalBill(int quantity, int choice)
    {
        selectedItems.Add(menu[choice - 1, 0]);
        return quantity * Convert.ToInt32(menu[choice - 1, 1]);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to the Cafeteria!");

        while (true) 
        {
            Console.WriteLine("\n📋 Campus Cafeteria Menu");
            Console.WriteLine("0. Exit\n");

            DisplayMenu();

            Console.Write("\nEnter item number: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 0)
            {
                Console.WriteLine("\nThank you for ordering. Visit again!");
                Console.WriteLine("\nYou ordered:");
                foreach (string item in selectedItems)
                {
                    Console.WriteLine($"- {item}");
                }
                Console.WriteLine($"Total Bill: Rs. {totalBill}");
                return;
            }

            if (choice < 1 || choice > 10)
            {
                Console.WriteLine("❌ Invalid choice. Try again.");
                continue;
            }

            DisplayItem(choice - 1);

            Console.Write("Enter quantity: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            totalBill += CalculateTotalBill(quantity, choice);
            Console.WriteLine($"Current Total: Rs. {totalBill}");
        }
    }
}
