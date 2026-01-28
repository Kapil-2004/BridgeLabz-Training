using System;
using System.IO;

namespace CSharpNUnit
{
    public class FileProcessor
    {
        public void WriteToFile(string filename, string content)
        {
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentException("Filename cannot be empty", nameof(filename));

            try
            {
                File.WriteAllText(filename, content);
            }
            catch (IOException ex)
            {
                throw new IOException($"Error writing to file: {filename}", ex);
            }
        }

        public string ReadFromFile(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentException("Filename cannot be empty", nameof(filename));

            if (!File.Exists(filename))
                throw new IOException($"File does not exist: {filename}");

            try
            {
                return File.ReadAllText(filename);
            }
            catch (IOException ex)
            {
                throw new IOException($"Error reading from file: {filename}", ex);
            }
        }

        public bool FileExists(string filename)
        {
            return File.Exists(filename);
        }
    }
}
