using System;

class BMIMultiArray
{
    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());
        double[][] personData = new double[number][];
        string[] weightStatus = new string[number];

        for (int i = 0; i < number; i++)
        {
            personData[i] = new double[3];
        }

        for (int i = 0; i < number; i++)
        {
            Console.WriteLine("Enter details for Person " + (i + 1));

            double weight;
            double height;

            while (true)
            {
                weight = Convert.ToDouble(Console.ReadLine());
                height = Convert.ToDouble(Console.ReadLine());

                if (weight > 0 && height > 0)
                    break;

                Console.WriteLine("Invalid input. Please enter positive values.");
            }

            personData[i][0] = weight;
            personData[i][1] = height;
        }
        for (int i = 0; i < number; i++)
        {
            double bmi = personData[i][0] / (personData[i][1] * personData[i][1]);
            personData[i][2] = bmi;

            if (bmi < 18.5)
                weightStatus[i] = "Underweight";
            else if (bmi < 25)
                weightStatus[i] = "Normal";
            else if (bmi < 30)
                weightStatus[i] = "Overweight";
            else
                weightStatus[i] = "Obese";
        }
        Console.WriteLine("Height(m)   Weight(kg)   BMI     Status");

        for (int i = 0; i < number; i++)
        {
            Console.WriteLine(
                personData[i][1] + "        " +
                personData[i][0] + "        " +
                Math.Round(personData[i][2], 2) + "    " +
                weightStatus[i]
            );
        }
    }
}
