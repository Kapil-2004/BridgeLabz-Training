using System;

class SmallestLargest
{
    public static int[] FindSmallestAndLargest(int number1, int number2, int number3)
    {
        int smallest = number1;
        int largest = number1;

        if (number2 < smallest) smallest = number2;
        if (number3 < smallest) smallest = number3;

        if (number2 > largest) largest = number2;
        if (number3 > largest) largest = number3;

        return new int[] { smallest, largest };
    }

    static void Main()
    {
        int number1 = Convert.ToInt32(Console.ReadLine());
        int number2 = Convert.ToInt32(Console.ReadLine());
        int number3 = Convert.ToInt32(Console.ReadLine());

        int[] result = FindSmallestAndLargest(number1, number2, number3);

        Console.WriteLine(result[0]);
        Console.WriteLine(result[1]);
    }
}
