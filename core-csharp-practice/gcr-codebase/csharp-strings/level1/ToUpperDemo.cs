using System;

class ToUpperDemo
{
    static void Main()
    {
        string s1 = Console.ReadLine();

        string manualUpper = ToUpperASCII(s1);
        string builtInUpper = s1.ToUpper();

        Console.WriteLine(manualUpper == builtInUpper);
    }

    static string ToUpperASCII(string s1)
    {
        string result = "";

        for (int i = 0; i < s1.Length; i++)
        {
            char ch = s1[i];

            if (ch >= 'a' && ch <= 'z')
            {
                ch = (char)(ch - 32);
            }

            result += ch;
        }

        return result;
    }
}
