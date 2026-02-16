using System;
using System.IO;
using TechVille.Modules;

namespace TechVille.Utilities
{
    public class CitizenUtility
    {
        public static string FormatName(string name)
        {
            name = name.Trim().ToLower();
            string[] parts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string finalName = "";

            for (int i = 0; i < parts.Length; i++)
            {
                string word = parts[i];
                finalName += char.ToUpper(word[0]) + word.Substring(1) + " ";
            }

            return finalName.Trim();
        }

        public static bool IsDuplicateCitizen(Citizen[] citizens, int count, int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (citizens[i].Id == id)
                    return true;
            }
            return false;
        }

        public static void LogError(Exception ex)
        {
            try
            {
                string fileName = "TechVille_ErrorLog.txt";

                string logMessage =
                    "\n==============================\n" +
                    "Date: " + DateTime.Now + "\n" +
                    "Error Type: " + ex.GetType().Name + "\n" +
                    "Message: " + ex.Message + "\n";

                File.AppendAllText(fileName, logMessage);
            }
            catch
            {
                // If logging fails, ignore to avoid crashing
            }
        }
    }
}
