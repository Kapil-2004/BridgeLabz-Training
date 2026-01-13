using System;
using System.Text;

class StringConcatenation
{
    static void Main()
    {
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine();

        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine();

        StringBuilder sb = new StringBuilder();
        sb.Append(str1);
        sb.Append(str2);

        Console.WriteLine("Concatenated string:");
        Console.WriteLine(sb.ToString());
    }
}
