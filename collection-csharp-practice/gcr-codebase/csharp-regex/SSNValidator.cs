using System;
using System.Text.RegularExpressions;

public class SSNValidator
{
    public static void Main(string[] args)
    {
        string[] ssns =
        {
            "123-45-6789",   // valid
            "123456789",     // invalid
            "987-65-4321",   // valid
            "12-345-6789",   // invalid
            "000-12-3456"    // valid (format only)
        };

        // Regex for SSN format: 3 digits - 2 digits - 4 digits
        string pattern = @"^\d{3}-\d{2}-\d{4}$";

        foreach (string ssn in ssns)
        {
            bool isValid = Regex.IsMatch(ssn, pattern);
            Console.WriteLine($"{ssn} → {(isValid ? "Valid" : "Invalid")}");
        }

        // User input check
        Console.WriteLine("\nEnter an SSN to validate:");
        string input = Console.ReadLine();

        if (Regex.IsMatch(input, pattern))
            Console.WriteLine("SSN is Valid");
        else
            Console.WriteLine("SSN is Invalid");
    }
}
