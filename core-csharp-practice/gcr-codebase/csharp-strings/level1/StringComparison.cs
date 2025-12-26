using System;

class StringComparison
{
    static void Main()
    {
        string s1 = Console.ReadLine();
        string s2 = Console.ReadLine();

        bool resultCharAt = CompareStrings(s1, s2);
        bool resultEquals = s1.Equals(s2);

        Console.WriteLine(resultCharAt);
        Console.WriteLine(resultEquals);
    }

    static bool CompareStrings(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
                return false;
        }

        return true;
    }
}
