using System;
using System.IO;

class FileReadDemo
{
    static void Main()
    {
        string filePath = "data.txt";

        try
        {
            // Try to read the file
            string content = File.ReadAllText(filePath);

            // If file exists, print its contents
            Console.WriteLine("File contents:\n");
            Console.WriteLine(content);
        }
        catch (IOException)
        {
            // If file does not exist or any IO error occurs
            Console.WriteLine("File not found");
        }
    }
}
