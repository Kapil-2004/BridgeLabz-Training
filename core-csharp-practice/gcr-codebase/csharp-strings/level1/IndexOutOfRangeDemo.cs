using System;

class IndexOutOfRangeDemo
{
    static void Main()
    {
        string s1 = "Hello";
        try
        {
            char ch = s1[10]; 
            Console.WriteLine(ch);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine("IndexOutOfRangeException caught");
        }
    }

}
