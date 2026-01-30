using System;
using System.IO;

class DetectDuplicates
{
    static void Main()
    {
        var lines = File.ReadAllLines("students.csv");

        Console.WriteLine("Duplicate Records:");

        for (int i = 1; i < lines.Length; i++) // skip header
        {
            var data1 = lines[i].Split(',');
            string id1 = data1[0];

            for (int j = i + 1; j < lines.Length; j++)
            {
                var data2 = lines[j].Split(',');
                string id2 = data2[0];

                if (id1 == id2)
                {
                    Console.WriteLine(lines[i]);
                    Console.WriteLine(lines[j]);
                    Console.WriteLine("-------------------");
                }
            }
        }
    }
}
