using System;

class BMICalculator
{
    static void Main(string[] args)
    {
        Console.Write("Enter weight in kg: ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Enter height in cm: ");
        double heightCm = double.Parse(Console.ReadLine());

        double heightMeter = heightCm / 100;

        double bmi = weight / (heightMeter * heightMeter);

        Console.WriteLine("BMI is: " + bmi);

        if (bmi < 18.5)
        {
            Console.WriteLine("Weight Status: Underweight");
        }
        else if (bmi >= 18.5 && bmi < 25)
        {
            Console.WriteLine("Weight Status: Normal");
        }
        else if (bmi >= 25 && bmi < 30)
        {
            Console.WriteLine("Weight Status: Overweight");
        }
        else
        {
            Console.WriteLine("Weight Status: Obese");
        }
    }
}
