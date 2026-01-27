using System;
using System.Text.RegularExpressions;

public class CapitalizedWordExtractor
{
    public static void Main(string[] args)
    {
        string text = "The Eiffel Tower is in Paris and the Statue of Liberty is in New York.";

        string pattern = @"\b[A-Z][a-z]*\b";

        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Extracted Capitalized Words:");

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
