using System;

class ArgumentOutOfRangeDemo
{
    static void Main()
    {
        string s1 = "Hello";

        try
        {
            string sub = s1.Substring(5, 3); 
            Console.WriteLine(sub);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine("ArgumentOutOfRangeException caught");
        }
    }
}
