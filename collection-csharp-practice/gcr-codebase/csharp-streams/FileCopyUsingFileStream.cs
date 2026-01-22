using System;
using System.IO;
using System.Text;

class FileCopyUsingFileStream
{
    static void Main()
    {
        string sourceFilePath = "source.txt";
        string destinationFilePath = "destination.txt";

        try
        {
            // Check if source file exists
            if (!File.Exists(sourceFilePath))
            {
                Console.WriteLine("Source file does not exist. Please check the file path.");
                return;
            }

            // Open source file for reading
            using (FileStream readStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            {
                // Create or overwrite destination file for writing
                using (FileStream writeStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    // Read from source and write to destination
                    while ((bytesRead = readStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                    }
                }
            }

            Console.WriteLine("File copied successfully using FileStream.");
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
