using System;

class BMICalculation
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        double[] weight = new double[n];
        double[] height = new double[n];
        double[] bmi = new double[n];
        string[] status = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter details for Person {i + 1}");

            Console.Write("Enter weight (in kg): ");
            weight[i] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter height (in meters): ");
            height[i] = Convert.ToDouble(Console.ReadLine());
        }

        for (int i = 0; i < n; i++)
        {
            bmi[i] = weight[i] / (height[i] * height[i]);

            if (bmi[i] < 18.5)
                status[i] = "Underweight";
            else if (bmi[i] < 25)
                status[i] = "Normal";
            else if (bmi[i] < 30)
                status[i] = "Overweight";
            else
                status[i] = "Obese";
        }
        Console.WriteLine("Height(m)\tWeight(kg)\tBMI\tStatus");

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"{height[i]}\t\t{weight[i]}\t\t{bmi[i]:F2}\t{status[i]}");
        }
    }
}
