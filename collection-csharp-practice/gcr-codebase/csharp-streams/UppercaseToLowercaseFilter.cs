using System;
using System.IO;
using System.Text;

class UppercaseToLowercaseFilter
{
    static void Main()
    {
        string sourceFilePath = "input.txt";
        string destinationFilePath = "output.txt";

        // Use UTF-8 encoding to handle character encoding properly
        Encoding encoding = Encoding.UTF8;

        try
        {
            // Check if source file exists
            if (!File.Exists(sourceFilePath))
            {
                Console.WriteLine("Source file does not exist: " + sourceFilePath);
                return;
            }

            // Open file streams
            using (FileStream readFs = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferedRead = new BufferedStream(readFs))
            using (StreamReader reader = new StreamReader(bufferedRead, encoding))
            using (FileStream writeFs = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
            using (BufferedStream bufferedWrite = new BufferedStream(writeFs))
            using (StreamWriter writer = new StreamWriter(bufferedWrite, encoding))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    // Convert uppercase to lowercase
                    string lowerCaseLine = line.ToLowerInvariant();
                    writer.WriteLine(lowerCaseLine);
                }
            }

            Console.WriteLine("File processing completed successfully.");
            Console.WriteLine("Uppercase letters converted to lowercase.");
            Console.WriteLine("Output file created: " + destinationFilePath);
        }
        catch (IOException ex)
        {
            Console.WriteLine("An I/O error occurred:");
            Console.WriteLine(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Access denied:");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}
