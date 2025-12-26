using System;

class LongestWordDemo
{
    static void Main()
    {
        string sentence = Console.ReadLine();
        string longest = FindLongestWord(sentence);
        Console.WriteLine("Longest Word: " + longest);
    }

    // Method to find the longest word manually
    static string FindLongestWord(string s)
    {
        string longest = "";
        string word = "";

        for (int i = 0; i <= s.Length; i++)
        {
            char ch = (i < s.Length) ? s[i] : ' '; // Treat end as space

            if (ch != ' ')
            {
                word += ch;
            }
            else
            {
                if (word.Length > longest.Length)
                    longest = word;
                word = "";
            }
        }

        return longest;
    }
}
