using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter salary: ");
        double salary = double.Parse(Console.ReadLine());
        
        Console.Write("Enter years of service: ");
        int yearsOfService = int.Parse(Console.ReadLine());
        
        double bonus = 0;
        
        if (yearsOfService > 5)
        {
            bonus = salary * 0.05;
        }
        
        Console.WriteLine($"Bonus amount: {bonus}");
    }
}