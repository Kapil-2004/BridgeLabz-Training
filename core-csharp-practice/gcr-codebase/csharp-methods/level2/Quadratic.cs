using System;

class Quadratic
{
    static double[] FindRoots(double a, double b, double c)
    {
        double discriminant = Math.Pow(b, 2) - 4 * a * c;

        if (discriminant > 0)
        {
            double delta = Math.Sqrt(discriminant);
            double root1 = (-b + delta) / (2 * a);
            double root2 = (-b - delta) / (2 * a);
            return new double[] { root1, root2 };
        }

        if (discriminant == 0)
        {
            double root = -b / (2 * a);
            return new double[] { root };
        }

        return new double[0];
    }

    static void Main()
    {
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        double c = Convert.ToDouble(Console.ReadLine());

        double[] roots = FindRoots(a, b, c);

        for (int i = 0; i < roots.Length; i++)
            Console.WriteLine(roots[i]);
    }
}
