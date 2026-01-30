using System;
using System.IO;
using System.Text.RegularExpressions;

class ValidateCsvData
{
    static void Main()
    {
        var lines = File.ReadAllLines("users.csv");

        // Simple regex patterns
        Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        Regex phoneRegex = new Regex(@"^\d{10}$");

        for (int i = 1; i < lines.Length; i++) // skip header
        {
            var data = lines[i].Split(',');

            string email = data[2];
            string phone = data[3];

            bool isEmailValid = emailRegex.IsMatch(email);
            bool isPhoneValid = phoneRegex.IsMatch(phone);

            if (!isEmailValid || !isPhoneValid)
            {
                Console.WriteLine("Invalid Record: " + lines[i]);

                if (!isEmailValid)
                    Console.WriteLine("  → Invalid Email Format");

                if (!isPhoneValid)
                    Console.WriteLine("  → Phone number must be 10 digits");
            }
        }
    }
}
