using System;
using System.IO;

class ReadLargeFileFilterErrors
{
    static void Main()
    {
        string filePath = "largeLogFile.txt";   // Change to your large file path

        try
        {
            // Check if file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist: " + filePath);
                return;
            }

            Console.WriteLine("Reading file and filtering lines containing 'error'...\n");

            int matchCount = 0;
            long lineNumber = 0;

            // Use StreamReader for efficient line-by-line reading
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;

                    // Case-insensitive check for "error"
                    if (line.IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        matchCount++;
                        Console.WriteLine($"Line {lineNumber}: {line}");
                    }
                }
            }

            Console.WriteLine("\n========= SUMMARY =========");
            Console.WriteLine("Total lines containing 'error': " + matchCount);
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
