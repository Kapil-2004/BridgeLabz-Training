using System;
using System.Text.RegularExpressions;

public class UsernameValidator
{
    public static void Main(string[] args)
    {
        string[] usernames = { "user_123", "123user", "us", "user@12", "Valid_User1" };

        string pattern = @"^[A-Za-z][A-Za-z0-9_]{4,14}$";

        foreach (string username in usernames)
        {
            bool isValid = Regex.IsMatch(username, pattern);
            Console.WriteLine($"{username} → {(isValid ? "Valid" : "Invalid")}");
        }

        // Optional: user input check
        Console.WriteLine("\nEnter a username to validate:");
        string input = Console.ReadLine();

        if (Regex.IsMatch(input, pattern))
            Console.WriteLine("Username is Valid");
        else
            Console.WriteLine("Username is Invalid");
    }
}
