using System;
using System.Text;

public class LexicalTwistUtil : ILexicalTwist
{
    public string ProcessWords(string word1, string word2)
    {
        ValidateWord(word1);
        ValidateWord(word2);

        if (IsReverse(word1, word2))
        {
            string reversed = Reverse(word1).ToLower();
            return ReplaceVowelsWithAt(reversed);
        }
        else
        {
            string combined = (word1 + word2).ToUpper();
            return AnalyzeAndPrint(combined);
        }
    }

    private void ValidateWord(string word)
    {
        if (word.Trim().Contains(" "))
            throw new InvalidWordException($"{word} is an invalid word");
    }

    private bool IsReverse(string word1, string word2)
    {
        return Reverse(word1).Equals(word2, StringComparison.OrdinalIgnoreCase);
    }

    private string Reverse(string word)
    {
        char[] arr = word.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }

    private string ReplaceVowelsWithAt(string word)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char ch in word)
        {
            if ("aeiou".Contains(ch))
                sb.Append('@');
            else
                sb.Append(ch);
        }

        return sb.ToString();
    }

    private string AnalyzeAndPrint(string word)
    {
        int vowels = 0, consonants = 0;

        foreach (char ch in word)
        {
            if (IsVowel(ch)) vowels++;
            else if (char.IsLetter(ch)) consonants++;
        }

        if (vowels == consonants)
            return "Vowels and consonants are equal";

        if (vowels > consonants)
            return GetFirstTwoUnique(word, true);

        return GetFirstTwoUnique(word, false);
    }

    private string GetFirstTwoUnique(string word, bool needVowels)
    {
        StringBuilder result = new StringBuilder();

        foreach (char ch in word)
        {
            if (!char.IsLetter(ch)) continue;

            bool match = needVowels ? IsVowel(ch) : !IsVowel(ch);

            if (match && !result.ToString().Contains(ch))
            {
                result.Append(ch);

                if (result.Length == 2)
                    break;
            }
        }

        return result.ToString();
    }

    private bool IsVowel(char ch)
    {
        return "AEIOU".Contains(ch);
    }
}
