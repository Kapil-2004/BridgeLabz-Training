using System;
using System.Text.RegularExpressions;

public class LanguageExtractor
{
    public static void Main(string[] args)
    {
        string text = "I love Java, Python, and JavaScript, but I haven't tried Go yet.";

        // List of programming languages to extract
        string pattern = @"\b(Java|Python|JavaScript|Go)\b";

        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Extracted Programming Languages:");

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
