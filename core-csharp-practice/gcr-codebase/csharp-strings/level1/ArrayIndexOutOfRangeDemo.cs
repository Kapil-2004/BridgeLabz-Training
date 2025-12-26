using System;

class ArrayIndexOutOfRangeDemo
{
    static void Main()
    {
        int[] arr = { 10, 20, 30 };

        try
        {
            int value = arr[5]; // invalid index
            Console.WriteLine(value);
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine("IndexOutOfRangeException caught");
        }
    }
}
