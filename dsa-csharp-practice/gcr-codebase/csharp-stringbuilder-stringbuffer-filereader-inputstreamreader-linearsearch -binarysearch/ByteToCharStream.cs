using System;
using System.IO;

class ByteToCharStream
{
    static void Main()
    {
        FileStream fileStream = new FileStream("sample.txt", FileMode.Open);
        StreamReader reader = new StreamReader(fileStream);

        int ch;
        while ((ch = reader.Read()) != -1)
        {
            Console.Write((char)ch);
        }

        reader.Close();
        fileStream.Close();
    }
}
