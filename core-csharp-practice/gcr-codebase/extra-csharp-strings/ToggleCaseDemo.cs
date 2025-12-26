using System;

class ToggleCaseDemo
{
    static void Main()
    {
        string input = Console.ReadLine();
        string toggled = ToggleCase(input);
        Console.WriteLine("Toggled String: " + toggled);
    }

    // Method to toggle case of each character
    static string ToggleCase(string s)
    {
        string result = "";

        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[i];

            if (ch >= 'a' && ch <= 'z')      
                ch = (char)(ch - 32);
            else if (ch >= 'A' && ch <= 'Z') 
                ch = (char)(ch + 32);

            result += ch;
        }

        return result;
    }
}
