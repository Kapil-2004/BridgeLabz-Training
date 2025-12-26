using System;

class NullReferenceDemo
{
    static void Main()
    {
        string s1 = null;

        try
        {
            int len = s1.Length; 
            Console.WriteLine(len);
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine("NullReferenceException caught");
        }
    }
}
