public class PalindromeChecker
{
    public static bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
            return true;

        string cleaned = System.Text.RegularExpressions.Regex.Replace(s.ToLower(), "[^a-z0-9]", "");
        
        int left = 0, right = cleaned.Length - 1;
        while (left < right)
        {
            if (cleaned[left] != cleaned[right])
                return false;
            left++;
            right--;
        }
        return true;
    }

    public static void Main()
    {
        Console.WriteLine(IsPalindrome("A man, a plan, a canal: Panama")); // true
        Console.WriteLine(IsPalindrome("race a car")); // false
        Console.WriteLine(IsPalindrome("0P")); // false
    }
}