using System;

class FizzBuzzProgram
{
    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());
        if (number <= 0)
        {
            Console.WriteLine("Error: Please enter a positive integer.");
            return;
        }
        string[] results = new string[number + 1]; 

        for (int i = 0; i <= number; i++)
        {
            if (i % 3 == 0 && i % 5 == 0 && i != 0)
            {
                results[i] = "FizzBuzz";
            }
            else if (i % 3 == 0 && i != 0)
            {
                results[i] = "Fizz";
            }
            else if (i % 5 == 0 && i != 0)
            {
                results[i] = "Buzz";
            }
            else
            {
                results[i] = i.ToString();
            }
        }
        for (int i = 1; i <= number; i++) 
        {
            Console.WriteLine("Position " + i + " = " + results[i]);
        }
    }
}
