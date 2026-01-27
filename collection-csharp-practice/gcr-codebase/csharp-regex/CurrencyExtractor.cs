using System;
using System.Text.RegularExpressions;

public class CurrencyExtractor
{
    public static void Main(string[] args)
    {
        string text = "The price is $45.99, and the discount is $ 10.50.";

        // Matches: $45.99  OR  10.50 (with or without $ and optional space)
        string pattern = @"\$\s?\d+\.\d{2}|\b\d+\.\d{2}\b";

        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Extracted Currency Values:");

        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value.Trim());
        }
    }
}
