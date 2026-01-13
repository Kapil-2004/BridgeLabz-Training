using System;
using System.IO;

class WordCountInFile
{
    static void Main()
    {
        StreamReader reader = new StreamReader("sample.txt");

        Console.Write("Enter word to search: ");
        string searchWord = Console.ReadLine();

        int count = 0;
        string line;

        while ((line = reader.ReadLine()) != null)
        {
            string[] words = line.Split(' ', '.', ',', '!', '?');

            foreach (string word in words)
            {
                if (word.Equals(searchWord, StringComparison.OrdinalIgnoreCase))
                {
                    count++;
                }
            }
        }

        reader.Close();

        Console.WriteLine("Word occurrence count: " + count);
    }
}
