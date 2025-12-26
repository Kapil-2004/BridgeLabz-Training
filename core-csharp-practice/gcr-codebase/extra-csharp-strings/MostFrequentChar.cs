using System;

class MostFrequentChar
{
    static void Main()
    {
        string input = Console.ReadLine();
        char frequent = FindMostFrequentChar(input);
        Console.WriteLine("Most Frequent Character: '" + frequent + "'");
    }

    // Method to find most frequent character
    static char FindMostFrequentChar(string s)
    {
        int[] freq = new int[256]; // ASCII character frequencies

        for (int i = 0; i < s.Length; i++)
        {
            freq[s[i]]++; // increment frequency for this character
        }

        int max = 0;
        char mostFrequent = s[0];

        for (int i = 0; i < 256; i++)
        {
            if (freq[i] > max)
            {
                max = freq[i];
                mostFrequent = (char)i;
            }
        }

        return mostFrequent;
    }
}
