using System;
using System.Text;

public class Program
{
    public string CleanseAndInvert(string input)
    {
        // Rule 1: null or length < 6
        if (string.IsNullOrEmpty(input) || input.Length < 6)
            return "";

        // Rule 2: must contain only alphabets (no space, digit, special char)
        foreach (char ch in input)
        {
            if (!char.IsLetter(ch))
                return "";
        }

        // Convert to lowercase
        input = input.ToLower();

        // Remove characters whose ASCII values are even
        StringBuilder filtered = new StringBuilder();
        foreach (char ch in input)
        {
            if (((int)ch) % 2 != 0) // keep odd ASCII
                filtered.Append(ch);
        }

        // Reverse remaining characters
        char[] arr = filtered.ToString().ToCharArray();
        Array.Reverse(arr);
        string reversed = new string(arr);

        // Even index (0-based) -> uppercase
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < reversed.Length; i++)
        {
            if (i % 2 == 0)
                result.Append(char.ToUpper(reversed[i]));
            else
                result.Append(reversed[i]);
        }

        return result.ToString();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();

        Program obj = new Program();
        string key = obj.CleanseAndInvert(input);

        if (key == "")
            Console.WriteLine("Invalid Input");
        else
            Console.WriteLine("The generated key is - " + key);
    }
}
