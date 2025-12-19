using System;

class PenDistribution
{
    static void Main(string[] args)
    {
        int pen = 14;
        int students = 3;
        int pensPerStudent = pen / students;
        int remainingPens = pen % students;
        Console.WriteLine($"The Pen Per Student is {pensPerStudent} and the remaining pen not distributed is {remainingPens}");
    }
}