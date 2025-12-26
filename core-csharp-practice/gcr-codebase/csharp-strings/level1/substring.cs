using System;

class substring
{
    static void Main()
    {
        string str = Console.ReadLine();
        int start = Convert.ToInt32(Console.ReadLine());
        int end = Convert.ToInt32(Console.ReadLine());

        string result = CreateSubstring(str, start, end);
        Console.WriteLine(result);
    }

    static string CreateSubstring(string s, int start, int end)
    {
        string result = "";

        for (int i = start; i < end; i++)
        {
            result += s[i];
        }

        return result;
    }
}