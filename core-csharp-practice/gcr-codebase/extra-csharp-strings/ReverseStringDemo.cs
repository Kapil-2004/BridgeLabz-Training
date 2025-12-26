using System;

class ReverseStringDemo
{
    static void Main()
    {
        string input = Console.ReadLine();
        string reversed = ReverseString(input);
        Console.WriteLine("Reversed String: " + reversed);
    }

    // Method to reverse a string manually
    static string ReverseString(string s)
    {
        string result = "";
        for (int i = s.Length - 1; i >= 0; i--)
        {
            result += s[i];
        }
        return result;
    }
}
