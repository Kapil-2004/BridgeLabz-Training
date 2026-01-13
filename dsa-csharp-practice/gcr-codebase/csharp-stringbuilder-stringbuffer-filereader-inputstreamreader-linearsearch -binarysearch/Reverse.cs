using System;
using System.Text;

class Reverse
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        StringBuilder reversed = new StringBuilder();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed.Append(input[i]);
        }

        Console.WriteLine("Reversed string: " + reversed.ToString());
    }
}
