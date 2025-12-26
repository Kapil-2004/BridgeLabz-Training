using System;

class AnagramCheck
{
    static void Main()
    {
        string s1 = Console.ReadLine();
        string s2 = Console.ReadLine();

        if (AreAnagrams(s1, s2))
            Console.WriteLine("The strings are anagrams.");
        else
            Console.WriteLine("The strings are not anagrams.");
    }

    // Method to check if two strings are anagrams
    static bool AreAnagrams(string s1, string s2)
    {
        int[] freq = new int[256]; // ASCII character frequency

        // Ignore length mismatch early
        if (s1.Length != s2.Length)
            return false;

        // Count characters in first string
        for (int i = 0; i < s1.Length; i++)
            freq[s1[i]]++;

        // Subtract counts using second string
        for (int i = 0; i < s2.Length; i++)
        {
            freq[s2[i]]--;
            if (freq[s2[i]] < 0)
                return false; // character count mismatch
        }

        return true;
    }
}
