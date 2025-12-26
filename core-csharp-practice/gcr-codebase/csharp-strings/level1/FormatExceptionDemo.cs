using System;

class FormatExceptionDemo
{
    static void Main()
    {
        string s1 = "abc";

        try
        {
            int num = int.Parse(s1); // non-numeric string
            Console.WriteLine(num);
        }
        catch (FormatException e)
        {
            Console.WriteLine("FormatException caught");
        }
    }
}
