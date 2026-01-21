using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class WordFrequencyCounter
{
    static void Main()
    {
        string filePath = "input.txt"; // Text file path

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found: " + filePath);
            return;
        }

        string text = File.ReadAllText(filePath);

        Dictionary<string, int> wordFrequency = CountWords(text);

        Console.WriteLine("Word Frequencies:");
        foreach (var pair in wordFrequency)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }
    }

    static Dictionary<string, int> CountWords(string text)
    {
        Dictionary<string, int> freq = new Dictionary<string, int>();

        // Convert to lowercase and remove punctuation
        text = text.ToLower();
        text = Regex.Replace(text, @"[^\w\s]", ""); // Remove punctuation

        string[] words = text.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (freq.ContainsKey(word))
                freq[word]++;
            else
                freq[word] = 1;
        }

        return freq;
    }
}
