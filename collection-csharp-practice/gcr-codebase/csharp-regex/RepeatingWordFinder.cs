using System;
using System.Text.RegularExpressions;

public class RepeatingWordFinder
{
    public static void Main(string[] args)
    {
        string text = "This is is a repeated repeated word test.";

        // Regex to find repeating words (case-insensitive)
        string pattern = @"\b(\w+)\s+\1\b";

        MatchCollection matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase);

        Console.WriteLine("Repeating Words:");

        foreach (Match match in matches)
        {
            // \1 is the repeated word
            Console.WriteLine(match.Groups[1].Value);
        }
    }
}
