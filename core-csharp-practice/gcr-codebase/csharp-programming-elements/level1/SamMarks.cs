using System;

class SamMarks
{
    static void Main(string[] args)
    {
        int math = 94;
        int physics = 95;
        int chemistry = 96;
        int avg = (math + physics + chemistry) / 300;
        Console.WriteLine("Sam’s average mark in PCM is"+ avg);
    }
}