using System;
using System.Text.RegularExpressions;

public class LicensePlateValidator
{
    public static void Main(string[] args)
    {
        string[] plates = { "AB1234", "A12345", "XY9999", "ab1234", "CD12E4" };

        string pattern = @"^[A-Z]{2}[0-9]{4}$";

        foreach (string plate in plates)
        {
            bool isValid = Regex.IsMatch(plate, pattern);
            Console.WriteLine($"{plate} → {(isValid ? "Valid" : "Invalid")}");
        }

        // User input check
        Console.WriteLine("\nEnter a license plate number:");
        string input = Console.ReadLine();

        if (Regex.IsMatch(input, pattern))
            Console.WriteLine("License plate is Valid");
        else
            Console.WriteLine("License plate is Invalid");
    }
}
