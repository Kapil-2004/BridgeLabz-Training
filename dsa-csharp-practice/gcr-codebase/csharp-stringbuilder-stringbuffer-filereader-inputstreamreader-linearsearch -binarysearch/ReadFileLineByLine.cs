using System;
using System.IO;

class ReadFileLineByLine
{
    static void Main()
    {
        StreamReader reader = new StreamReader("sample.txt");

        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }

        reader.Close();
    }
}
