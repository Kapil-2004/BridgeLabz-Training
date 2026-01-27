using System;
using System.Text.RegularExpressions;

public class LinkExtractor
{
    public static void Main(string[] args)
    {
        string text = "Visit https://www.google.com and http://example.org for more info.";

        string pattern = @"https?://[^\s]+";

        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Extracted Links:");

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
