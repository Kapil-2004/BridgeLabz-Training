using System;
using System.Text.RegularExpressions;

public class IpAddressValidator
{
    public static void Main(string[] args)
    {
        string[] ipAddresses =
        {
            "192.168.1.1",
            "255.255.255.255",
            "0.0.0.0",
            "256.100.50.25",
            "192.168.1",
            "123.045.067.089"
        };

        string pattern =
            @"^(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)\." +
            @"(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)\." +
            @"(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)\." +
            @"(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)$";

        foreach (string ip in ipAddresses)
        {
            bool isValid = Regex.IsMatch(ip, pattern);
            Console.WriteLine($"{ip} → {(isValid ? "Valid" : "Invalid")}");
        }

        // User input check
        Console.WriteLine("\nEnter an IP address to validate:");
        string input = Console.ReadLine();

        if (Regex.IsMatch(input, pattern))
            Console.WriteLine("IP address is Valid");
        else
            Console.WriteLine("IP address is Invalid");
    }
}
