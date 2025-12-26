using System;

class CompareStringsDemo
{
    static void Main()
    {
        string s1 = Console.ReadLine();
        string s2 = Console.ReadLine();

        int result = CompareStrings(s1, s2);

        if (result < 0)
            Console.WriteLine($"\"{s1}\" comes before \"{s2}\"");
        else if (result > 0)
            Console.WriteLine($"\"{s1}\" comes after \"{s2}\"");
        else
            Console.WriteLine($"\"{s1}\" is equal to \"{s2}\"");
    }

    // Method to compare two strings lexicographically
    static int CompareStrings(string s1, string s2)
    {
        int len1 = s1.Length;
        int len2 = s2.Length;
        int minLen = (len1 < len2) ? len1 : len2;

        for (int i = 0; i < minLen; i++)
        {
            if (s1[i] != s2[i])
                return s1[i] - s2[i]; 
        }

        return len1 - len2;
    }
}
