using System;

class PalindromeCheck
{
    static void Main()
    {
        string input = Console.ReadLine();
        if (IsPalindrome(input))
            Console.WriteLine("The string is a palindrome.");
        else
            Console.WriteLine("The string is not a palindrome.");
    }

    // Method to check palindrome
    static bool IsPalindrome(string s)
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
}
