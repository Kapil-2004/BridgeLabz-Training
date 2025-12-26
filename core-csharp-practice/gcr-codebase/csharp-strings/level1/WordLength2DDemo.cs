using System;

class SplitAndLength
{
    // Method to calculate length of a string without using Length
    static int getLength(string text)
    {
        int count = 0;

        foreach (char c in text)
        {
            count++;
        }

        return count;
    }

    // Method to split text into words without using Split()
    // Returns a 2D array: [word, length]
    static string[,] splitWordsAndLengths(string text)
    {
        int wordCount = 0;
        bool inWord = false;

        // First pass: count words
        for (int i = 0; i < getLength(text); i++)
        {
            if (text[i] != ' ' && !inWord)
            {
                wordCount++;
                inWord = true;
            }
            else if (text[i] == ' ')
            {
                inWord = false;
            }
        }

        string[,] result = new string[wordCount, 2];

        int index = 0;
        string currentWord = "";

        // Second pass: build words
        for (int i = 0; i < getLength(text); i++)
        {
            if (text[i] != ' ')
            {
                currentWord += text[i];
            }
            else if (currentWord != "")
            {
                result[index, 0] = currentWord;
                result[index, 1] = getLength(currentWord).ToString();
                index++;
                currentWord = "";
            }
        }

        // Add last word if exists
        if (currentWord != "")
        {
            result[index, 0] = currentWord;
            result[index, 1] = getLength(currentWord).ToString();
        }

        return result;
    }

    static void Main()
    {
        string input = Console.ReadLine();

        string[,] words = splitWordsAndLengths(input);

        for (int i = 0; i < words.GetLength(0); i++)
        {
            Console.WriteLine(words[i, 0] + "\t" + words[i, 1]);
        }
    }
}