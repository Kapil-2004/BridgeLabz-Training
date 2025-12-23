using System;

class MultiplicationTable2
{
    static void Main(string []args)
    {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        int[] multiplicationResult = new int[4];
        int index = 0;
        for (int i = 6; i <= 9; i++)
        {
            multiplicationResult[index] = number * i;
            index++;
        }

        index = 0;
        for (int i = 6; i <= 9; i++)
        {
            Console.WriteLine(number + " * " + i + " = " + multiplicationResult[index]);
            index++;
        }
    }
}
