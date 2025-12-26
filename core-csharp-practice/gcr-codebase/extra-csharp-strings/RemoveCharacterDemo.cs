using System;

class RemoveCharacterDemo
{
    static void Main()
    {
        string input = Console.ReadLine();
        char toRemove = Console.ReadLine()[0];

        string result = RemoveCharacter(input, toRemove);
        Console.WriteLine("Modified String: " + result);
    }

    // Method to remove a specific character
    static string RemoveCharacter(string s, char c)
    {
        string result = "";

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != c)
                result += s[i];
        }

        return result;
    }
}
