using System;
using System.Text.RegularExpressions;

public class CreditCardValidator
{
    public static void Main(string[] args)
    {
        string[] cardNumbers =
        {
            "4123456789012345", // Visa
            "5123456789012345", // MasterCard
            "6123456789012345", // Invalid start
            "412345678901234",  // Too short
            "51234567890123456" // Too long
        };

        // Visa: starts with 4, 16 digits
        // MasterCard: starts with 5, 16 digits
        string pattern = @"^(4\d{15}|5\d{15})$";

        foreach (string card in cardNumbers)
        {
            bool isValid = Regex.IsMatch(card, pattern);
            Console.WriteLine($"{card} → {(isValid ? "Valid" : "Invalid")}");
        }

        // User input check
        Console.WriteLine("\nEnter a credit card number to validate:");
        string input = Console.ReadLine();

        if (Regex.IsMatch(input, pattern))
            Console.WriteLine("Credit card number is Valid");
        else
            Console.WriteLine("Credit card number is Invalid");
    }
}
