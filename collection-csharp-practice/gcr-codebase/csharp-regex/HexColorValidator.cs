using System;
using System.Text.RegularExpressions;

public class HexColorValidator
{
    public static void Main(string[] args)
    {
        string[] colors = { "#FFA500", "#ff4500", "#123", "#12FG45", "FFA500" };

        string pattern = @"^#[0-9A-Fa-f]{6}$";

        foreach (string color in colors)
        {
            bool isValid = Regex.IsMatch(color, pattern);
            Console.WriteLine($"{color} → {(isValid ? "Valid" : "Invalid")}");
        }

        // User input check
        Console.WriteLine("\nEnter a hex color code:");
        string input = Console.ReadLine();

        if (Regex.IsMatch(input, pattern))
            Console.WriteLine("Hex color code is Valid");
        else
            Console.WriteLine("Hex color code is Invalid");
    }
}
