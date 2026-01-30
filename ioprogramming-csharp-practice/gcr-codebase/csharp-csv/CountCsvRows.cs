using System;
using System.IO;

class CountCsvRows
{
    static void Main()
    {
        var lines = File.ReadAllLines("students.csv");

        int count = 0;

        for (int i = 1; i < lines.Length; i++)
        {
            count++;
        }

        Console.WriteLine("Total Records (excluding header): " + count);
    }
}
