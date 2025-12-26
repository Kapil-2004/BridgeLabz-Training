using System;

class SubstringOccurrences
{
    static void Main()
    {
        string text = Console.ReadLine();
        string sub = Console.ReadLine();

        int count = CountSubstringOccurrences(text, sub);
        Console.WriteLine($"The substring occurs {count} times.");
    }

    // Method to count substring occurrences manually
    static int CountSubstringOccurrences(string text, string sub)
    {
        int count = 0;
        int textLen = text.Length;
        int subLen = sub.Length;

        if (subLen == 0 || subLen > textLen) return 0;

        for (int i = 0; i <= textLen - subLen; i++)
        {
            bool match = true;

            for (int j = 0; j < subLen; j++)
            {
                if (text[i + j] != sub[j])
                {
                    match = false;
                    break;
                }
            }

            if (match) count++;
        }

        return count;
    }
}
