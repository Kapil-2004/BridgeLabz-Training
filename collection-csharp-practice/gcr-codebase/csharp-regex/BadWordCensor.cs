using System;
using System.Text.RegularExpressions;

public class BadWordCensor
{
    public static void Main(string[] args)
    {
        string input = "This is a damn bad example with some stupid words.";

        string[] badWords = { "damn", "stupid" };

        // Build regex pattern: \b(damn|stupid)\b
        string pattern = @"\b(" + string.Join("|", badWords) + @")\b";

        string result = Regex.Replace(input, pattern, "****", RegexOptions.IgnoreCase);

        Console.WriteLine("Original Sentence:");
        Console.WriteLine(input);

        Console.WriteLine("\nAfter Censoring Bad Words:");
        Console.WriteLine(result);
    }
}
