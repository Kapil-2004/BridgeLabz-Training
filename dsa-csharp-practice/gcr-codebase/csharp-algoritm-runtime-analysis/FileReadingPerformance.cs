using System;
using System.Diagnostics;
using System.IO;
using System.Text;

class FileReadingPerformance
{
    static void CreateDummyFile(string path, int sizeInMB)
    {
        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            byte[] buffer = new byte[1024 * 1024]; // 1MB buffer
            for (int i = 0; i < sizeInMB; i++)
            {
                fs.Write(buffer, 0, buffer.Length);
            }
        }
    }

    // ---------- StreamReader ----------
    static void ReadUsingStreamReader(string path)
    {
        using (StreamReader reader = new StreamReader(path))
        {
            while (reader.Read() != -1) { }
        }
    }

    // ---------- FileStream ----------
    static void ReadUsingFileStream(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[4096];
            while (fs.Read(buffer, 0, buffer.Length) > 0) { }
        }
    }

    static void Test(string label, int sizeInMB)
    {
        string filePath = label + ".dat";
        CreateDummyFile(filePath, sizeInMB);

        Stopwatch sw = new Stopwatch();

        Console.WriteLine("File Size: " + sizeInMB + " MB");

        sw.Start();
        ReadUsingStreamReader(filePath);
        sw.Stop();
        Console.WriteLine("StreamReader Time: " + sw.ElapsedMilliseconds + " ms");

        sw.Restart();
        ReadUsingFileStream(filePath);
        sw.Stop();
        Console.WriteLine("FileStream Time: " + sw.ElapsedMilliseconds + " ms");

        Console.WriteLine();
    }

    static void Main()
    {
        Test("file1MB", 1);
        Test("file100MB", 100);
        Test("file500MB", 500);
    }
}
