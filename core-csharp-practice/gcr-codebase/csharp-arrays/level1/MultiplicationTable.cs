using System;

class MultiplicationTable
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int[] table = new int[10];
        for (int i = 1; i <= 10; i++)
        {
            table[i - 1] = number * i;
        }

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(number + " * " + i + " = " + table[i - 1]);
        }
    }
}
