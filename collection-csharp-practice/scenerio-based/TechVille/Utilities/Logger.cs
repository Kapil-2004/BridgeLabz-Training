using System;
using System.IO;

namespace TechVille.Utilities
{
    public class Logger
    {
        private static string logFile = "logs.txt";

        public static void Log(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(logFile, true))
                {
                    sw.WriteLine($"[{DateTime.Now}] {message}");
                }
            }
            catch
            {
                // ignore logging errors
            }
        }
    }
}
