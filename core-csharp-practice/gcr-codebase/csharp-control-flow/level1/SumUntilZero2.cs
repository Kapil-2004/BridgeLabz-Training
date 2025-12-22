using System;

class SumUntilZero2
{
    static void Main()
    {
        int sum = 0;
        
        while (true)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            
            if (number <= 0)
            {
                break;
            }
            
            sum += number;
        }
        
        Console.WriteLine($"Sum: {sum}");
    }
}