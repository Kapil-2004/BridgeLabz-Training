using System;
using System.Text.RegularExpressions;

public class SpaceNormalizer
{
    public static void Main(string[] args)
    {
        string input = "This   is   an   example   with   multiple   spaces.";

        string pattern = @"\s+";
        string result = Regex.Replace(input, pattern, " ");

        Console.WriteLine("Original Text:");
        Console.WriteLine(input);

        Console.WriteLine("\nAfter Replacing Multiple Spaces:");
        Console.WriteLine(result);
    }
}
