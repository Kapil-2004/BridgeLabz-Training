using System;
using System.IO;

class MergeCsvFiles
{
    static void Main()
    {
        var students1 = File.ReadAllLines("students1.csv");
        var students2 = File.ReadAllLines("students2.csv");

        string[] mergedData = new string[students1.Length];
        mergedData[0] = "ID,Name,Age,Marks,Grade"; // new header

        int index = 1;

        for (int i = 1; i < students1.Length; i++)
        {
            var data1 = students1[i].Split(',');
            string id1 = data1[0];

            for (int j = 1; j < students2.Length; j++)
            {
                var data2 = students2[j].Split(',');
                string id2 = data2[0];

                if (id1 == id2)
                {
                    mergedData[index] =
                        data1[0] + "," +
                        data1[1] + "," +
                        data1[2] + "," +
                        data2[1] + "," +
                        data2[2];

                    index++;
                    break;
                }
            }
        }

        File.WriteAllLines("merged_students.csv", mergedData);

        Console.WriteLine("CSV files merged successfully.");
    }
}
