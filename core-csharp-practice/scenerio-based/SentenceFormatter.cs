using System;
using System.Text;

class SentenceFormatter
{
    static void Main()
    {
        Console.WriteLine("Enter a paragraph:");
        string text = Console.ReadLine() ?? "";

        // Edge case: empty input
        if (text.Length == 0)
        {
            Console.WriteLine("Empty input");
            return;
        }

        StringBuilder formatted = new StringBuilder();

        int wordCount = 0;
        int currentWordLength = 0;
        int maxWordLength = 0;
        StringBuilder longestWord = new StringBuilder();
        StringBuilder tempWord = new StringBuilder();

        // Handle first character
        char first = text[0];
        if (first >= 'a' && first <= 'z')
            first = (char)(first - 32);

        formatted.Append(first);
        if (first != ' ')
            wordCount = 1;

        tempWord.Append(first);
        currentWordLength = 1;

        for (int i = 1; i < text.Length; i++)
        {
            char curr = text[i];
            char prev = text[i - 1];

            // Remove extra spaces
            if (curr == ' ' && prev == ' ')
                continue;

            // One space after punctuation
            if (curr != ' ' &&
                (prev == '.' || prev == '!' || prev == '?' || prev == ','))
            {
                formatted.Append(' ');
            }

            // Capitalize after . ? !
            if (i >= 2 && prev == ' ' &&
                (text[i - 2] == '.' || text[i - 2] == '!' || text[i - 2] == '?'))
            {
                if (curr >= 'a' && curr <= 'z')
                    curr = (char)(curr - 32);
            }

            formatted.Append(curr);

            // Word count logic
            if (prev == ' ' && curr != ' ')
                wordCount++;

            // Longest word logic
            if ((curr >= 'a' && curr <= 'z') || (curr >= 'A' && curr <= 'Z'))
            {
                tempWord.Append(curr);
                currentWordLength++;
            }
            else
            {
                if (currentWordLength > maxWordLength)
                {
                    maxWordLength = currentWordLength;
                    longestWord.Clear();
                    longestWord.Append(tempWord);
                }
                tempWord.Clear();
                currentWordLength = 0;
            }
        }

        // Last word check
        if (currentWordLength > maxWordLength)
        {
            longestWord.Clear();
            longestWord.Append(tempWord);
        }

        Console.WriteLine("\nFormatted Text:");
        Console.WriteLine(formatted.ToString());
        Console.WriteLine("\nWord Count: " + wordCount);
        Console.WriteLine("Longest Word: " + longestWord.ToString());

        // Word replacement (case-insensitive)
        Console.WriteLine("\nEnter word to replace:");
        string oldWord = Console.ReadLine() ?? "";

        Console.WriteLine("Enter replacement word:");
        string newWord = Console.ReadLine() ?? "";

        Console.WriteLine("\nAfter Replacement:");
        Console.WriteLine(ReplaceWord(formatted.ToString(), oldWord, newWord));
    }

    static string ReplaceWord(string text, string oldWord, string newWord)
    {
        StringBuilder result = new StringBuilder();
        StringBuilder word = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];

            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
            {
                word.Append(ch);
            }
            else
            {
                if (word.Length > 0)
                {
                    if (IsSameWord(word, oldWord))
                        result.Append(newWord);
                    else
                        result.Append(word);

                    word.Clear();
                }
                result.Append(ch);
            }
        }

        if (word.Length > 0)
        {
            if (IsSameWord(word, oldWord))
                result.Append(newWord);
            else
                result.Append(word);
        }

        return result.ToString();
    }

    static bool IsSameWord(StringBuilder word, string target)
    {
        if (word.Length != target.Length)
            return false;

        for (int i = 0; i < word.Length; i++)
        {
            char a = word[i];
            char b = target[i];

            if (a >= 'A' && a <= 'Z') a = (char)(a + 32);
            if (b >= 'A' && b <= 'Z') b = (char)(b + 32);

            if (a != b)
                return false;
        }
        return true;
    }
}
