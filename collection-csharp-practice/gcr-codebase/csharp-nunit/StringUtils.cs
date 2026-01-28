using System;

namespace CSharpNUnit
{
    public class StringUtils
    {
        public string Reverse(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            char[] charArray = str.ToCharArray();
            System.Array.Reverse(charArray);
            return new string(charArray);
        }

        public bool IsPalindrome(string str)
        {
            if (string.IsNullOrEmpty(str))
                return true;

            string normalized = str.ToLower().Replace(" ", "");
            string reversed = Reverse(normalized);
            return normalized.Equals(reversed);
        }

        public string ToUpperCase(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return str.ToUpper();
        }
    }
}
