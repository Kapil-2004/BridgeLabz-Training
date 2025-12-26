using System;

class PalindromeChecker
{
    static void Main()
    {
        string input = ReadInput();
        bool isPalindrome = CheckPalindrome(input);
        DisplayResult(input, isPalindrome);
    }

    // Function to read input string
    static string ReadInput()
    {
        Console.Write("Enter a string: ");
        return Console.ReadLine();
    }

    // Function to check palindrome condition
    static bool CheckPalindrome(string s)
    {
        int start = 0;
        int end = s.Length - 1;

        while (start < end)
        {
            if (s[start] != s[end])
                return false;

            start++;
            end--;
        }
        return true;
    }

    // Function to display result
    static void DisplayResult(string s, bool isPalindrome)
    {
        if (isPalindrome)
            Console.WriteLine($"\"{s}\" is a palindrome.");
        else
            Console.WriteLine($"\"{s}\" is not a palindrome.");
    }
}
