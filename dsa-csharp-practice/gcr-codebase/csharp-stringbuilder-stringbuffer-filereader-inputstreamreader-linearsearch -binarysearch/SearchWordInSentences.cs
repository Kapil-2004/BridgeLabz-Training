using System;

class SearchWordInSentences
{
    static void Main()
    {
        string[] sentences = {
            "I love programming.",
            "C# is a powerful language.",
            "Linear search is simple.",
            "Learning algorithms is fun."
        };

        Console.Write("Enter word to search: ");
        string searchWord = Console.ReadLine();

        int foundIndex = -1;

        for (int i = 0; i < sentences.Length; i++)
        {
            if (sentences[i].Contains(searchWord, StringComparison.OrdinalIgnoreCase))
            {
                foundIndex = i;
                break; // Stop at first match
            }
        }

        if (foundIndex != -1)
        {
            Console.WriteLine("First sentence containing the word:");
            Console.WriteLine(sentences[foundIndex]);
            Console.WriteLine("Index: " + foundIndex);
        }
        else
        {
            Console.WriteLine("No sentence contains the word \"" + searchWord + "\".");
        }
    }
}
