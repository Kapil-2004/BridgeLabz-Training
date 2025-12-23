using System;

class NumCheck
{
    static void Main()
    {
        int[] arr = new int[5];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > 0)
            {
                if (arr[i] % 2 == 0)
                {
                    Console.WriteLine(arr[i] + " is Positive and Even");
                }
                else
                {
                    Console.WriteLine(arr[i] + " is Positive and Odd");
                }
            }
            else if (arr[i] < 0)
            {
                Console.WriteLine(arr[i] + " is Negative");
            }
            else
            {
                Console.WriteLine(arr[i] + " is Zero");
            }
        }

        if (arr[0] == arr[arr.Length - 1])
        {
            Console.WriteLine("First and last elements are Equal");
        }
        else if (arr[0] > arr[arr.Length - 1])
        {
            Console.WriteLine("First element is Greater than last element");
        }
        else
        {
            Console.WriteLine("First element is Less than last element");
        }
    }
}
