using System;
using System.IO;

class WriteEmployees
{
    static void Main()
    {
        string[] data =
        {
            "ID,Name,Department,Salary",
            "1,Rahul,IT,50000",
            "2,Amit,HR,45000",
            "3,Priya,Finance,55000",
            "4,Neha,Marketing,48000",
            "5,Suresh,IT,60000"
        };

        File.WriteAllLines("employees.csv", data);

        Console.WriteLine("CSV file created and data written successfully.");
    }
}
