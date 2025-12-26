using System;

class ReplaceWordDemo
{
    static void Main()
    {
        string sentence = Console.ReadLine();
        string oldWord = Console.ReadLine();
        string newWord = Console.ReadLine();

        string modified = ReplaceWord(sentence, oldWord, newWord);
        Console.WriteLine("Modified Sentence: " + modified);
    }

    // Method to replace a word manually
    static string ReplaceWord(string sentence, string oldWord, string newWord)
    {
        string result = "";
        string word = "";

        for (int i = 0; i <= sentence.Length; i++)
        {
            char ch = (i < sentence.Length) ? sentence[i] : ' '; // Treat end as space

            if (ch != ' ')
            {
                word += ch;
            }
            else
            {
                if (word == oldWord)
                    result += newWord;
                else
                    result += word;

                if (i < sentence.Length) result += " "; // add space between words
                word = "";
            }
        }

        return result;
    }
}
