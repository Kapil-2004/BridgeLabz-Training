using System;

class RemoveDuplicatesDemo
{
    static void Main()
    {
        string input = Console.ReadLine();
        string result = RemoveDuplicates(input);
        Console.WriteLine("Modified String: " + result);
    }

    // Method to remove duplicates manually
    static string RemoveDuplicates(string s)
    {
        string result = "";

        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[i];
            if (!Contains(result, ch))
            {
                result += ch;
            }
        }

        return result;
    }

    // Helper method to check if a character exists in a string
    static bool Contains(string s, char c)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == c)
                return true;
        }
        return false;
    }
}
