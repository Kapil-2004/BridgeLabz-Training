using System;

class BMIProgram
{
    static void CalculateBMI(double[,] data)
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            double heightInMeters = data[i, 1] / 100;
            data[i, 2] = data[i, 0] / (heightInMeters * heightInMeters);
        }
    }

    static string[] GetBMIStatus(double[,] data)
    {
        string[] status = new string[10];

        for (int i = 0; i < data.GetLength(0); i++)
        {
            double bmi = data[i, 2];

            if (bmi <= 18.4)
                status[i] = "Underweight";
            else if (bmi <= 24.9)
                status[i] = "Normal";
            else if (bmi <= 39.9)
                status[i] = "Overweight";
            else
                status[i] = "Obese";
        }

        return status;
    }

    static void Main()
    {
        double[,] data = new double[10, 3];

        for (int i = 0; i < 10; i++)
        {
            data[i, 0] = Convert.ToDouble(Console.ReadLine());
            data[i, 1] = Convert.ToDouble(Console.ReadLine());
        }

        CalculateBMI(data);
        string[] status = GetBMIStatus(data);

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(data[i, 0]);
            Console.WriteLine(data[i, 1]);
            Console.WriteLine(data[i, 2]);
            Console.WriteLine(status[i]);
        }
    }
}
