using System;

class CharArrayComaparision
{
    static void Main()
    {
        string s1 = Console.ReadLine();
        char []str1 = new char [s1.Length];
        for (int i = 0; i < s1.Length; i++)
        {
            str1[i] = s1[i];
        }
        char []str2 = s1.ToCharArray();
        bool result = check(str1, str2);
        Console.WriteLine(result);
    }

    static bool check(char[] str1, char[] str2)
    {
        if (str1.Length != str2.Length)
            return false;

        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] != str2[i])
                return false;
        }

        return true;
    }
}