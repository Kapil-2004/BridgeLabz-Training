using System;

class ToLowerDemo
{
    static void Main()
    {
        string s1 = Console.ReadLine();

        string manualLower = ToLowerASCII(s1);
        string builtInLower = s1.ToLower();

        Console.WriteLine(manualLower == builtInLower);
    }

    static string ToLowerASCII(string s1)
    {
        string result = "";

        for (int i = 0; i < s1.Length; i++)
        {
            char ch = s1[i];
            if (ch >= 'A' && ch <= 'Z')
            {
                ch = (char)(ch + 32);
            }

            result += ch;
        }

        return result;
    }
}
