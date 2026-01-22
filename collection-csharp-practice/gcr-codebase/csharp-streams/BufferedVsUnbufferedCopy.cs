using System;
using System.Diagnostics;
using System.IO;

class BufferedVsUnbufferedCopy
{
    static void Main()
    {
        string sourceFilePath = "largeSourceFile.dat";          // e.g. 100MB file
        string unbufferedDestPath = "copy_unbuffered.dat";
        string bufferedDestPath = "copy_buffered.dat";

        const int bufferSize = 4096; // 4 KB

        if (!File.Exists(sourceFilePath))
        {
            Console.WriteLine("Source file does not exist. Please create or place a large file named:");
            Console.WriteLine(sourceFilePath);
            return;
        }

        try
        {
            // --------- Unbuffered FileStream Copy ---------
            Stopwatch swUnbuffered = new Stopwatch();
            swUnbuffered.Start();

            using (FileStream readStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream writeStream = new FileStream(unbufferedDestPath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead;

                while ((bytesRead = readStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                }
            }

            swUnbuffered.Stop();
            Console.WriteLine("Unbuffered FileStream copy completed.");
            Console.WriteLine("Time taken (ms): " + swUnbuffered.ElapsedMilliseconds);
            Console.WriteLine();

            // --------- BufferedStream Copy ---------
            Stopwatch swBuffered = new Stopwatch();
            swBuffered.Start();

            using (FileStream readFs = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream writeFs = new FileStream(bufferedDestPath, FileMode.Create, FileAccess.Write))
            using (BufferedStream bufferedRead = new BufferedStream(readFs, bufferSize))
            using (BufferedStream bufferedWrite = new BufferedStream(writeFs, bufferSize))
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead;

                while ((bytesRead = bufferedRead.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bufferedWrite.Write(buffer, 0, bytesRead);
                }
            }

            swBuffered.Stop();
            Console.WriteLine("BufferedStream copy completed.");
            Console.WriteLine("Time taken (ms): " + swBuffered.ElapsedMilliseconds);
            Console.WriteLine();

            // --------- Comparison ---------
            Console.WriteLine("========= PERFORMANCE COMPARISON =========");
            Console.WriteLine("Unbuffered Time (ms): " + swUnbuffered.ElapsedMilliseconds);
            Console.WriteLine("Buffered Time   (ms): " + swBuffered.ElapsedMilliseconds);

            if (swBuffered.ElapsedMilliseconds < swUnbuffered.ElapsedMilliseconds)
            {
                Console.WriteLine("BufferedStream is faster.");
            }
            else if (swBuffered.ElapsedMilliseconds > swUnbuffered.ElapsedMilliseconds)
            {
                Console.WriteLine("Unbuffered FileStream is faster.");
            }
            else
            {
                Console.WriteLine("Both methods took the same time.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("An I/O error occurred:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}
