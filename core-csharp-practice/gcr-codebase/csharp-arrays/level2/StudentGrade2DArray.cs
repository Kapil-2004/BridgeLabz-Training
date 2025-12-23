using System;

class StudentGrade2DArray
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] marks = new int[n, 3];
        double[] percentage = new double[n];
        char[] grade = new char[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter marks for Student " + (i + 1));
            int phy = Convert.ToInt32(Console.ReadLine());
            int chem = Convert.ToInt32(Console.ReadLine());
            int math = Convert.ToInt32(Console.ReadLine());

            if (phy < 0 || chem < 0 || math < 0)
            {
                Console.WriteLine("Invalid marks. Enter positive values only.");
                i--;
                continue;
            }

            marks[i, 0] = phy;
            marks[i, 1] = chem;
            marks[i, 2] = math;
        }

        for (int i = 0; i < n; i++)
        {
            int total = marks[i, 0] + marks[i, 1] + marks[i, 2];
            percentage[i] = total / 3.0;

            if (percentage[i] >= 80)
                grade[i] = 'A';
            else if (percentage[i] >= 70)
                grade[i] = 'B';
            else if (percentage[i] >= 60)
                grade[i] = 'C';
            else if (percentage[i] >= 50)
                grade[i] = 'D';
            else if (percentage[i] >= 40)
                grade[i] = 'E';
            else
                grade[i] = 'R';
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(
                marks[i, 0] + "        " +
                marks[i, 1] + "         " +
                marks[i, 2] + "     " +
                Math.Round(percentage[i], 2) + "        " +
                grade[i]
            );
        }
    }
}
