using System;
using System.IO;

class ReadInputAndWriteToFile
{
    static void Main()
    {
        Console.WriteLine("Enter text (type 'exit' to finish):");

        // StreamReader reads from console input
        StreamReader reader = new StreamReader(Console.OpenStandardInput());
        StreamWriter writer = new StreamWriter("output.txt");

        string line;
        while ((line = reader.ReadLine()) != "exit")
        {
            writer.WriteLine(line);
        }

        reader.Close();
        writer.Close();

        Console.WriteLine("User input written to output.txt");
    }
}
