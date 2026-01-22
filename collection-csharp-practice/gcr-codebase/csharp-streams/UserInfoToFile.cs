using System;
using System.IO;

class UserInfoToFile
{
    static void Main()
    {
        string outputFilePath = "UserInfo.txt";

        try
        {
            // Use StreamReader to read from console input
            using (StreamReader consoleReader = new StreamReader(Console.OpenStandardInput()))
            {
                Console.Write("Enter your name: ");
                string name = consoleReader.ReadLine();

                Console.Write("Enter your age: ");
                string age = consoleReader.ReadLine();

                Console.Write("Enter your favorite programming language: ");
                string favoriteLanguage = consoleReader.ReadLine();

                // Use StreamWriter to write data into a file
                using (StreamWriter writer = new StreamWriter(outputFilePath, false))
                {
                    writer.WriteLine("User Information");
                    writer.WriteLine("----------------");
                    writer.WriteLine("Name: " + name);
                    writer.WriteLine("Age: " + age);
                    writer.WriteLine("Favorite Programming Language: " + favoriteLanguage);
                }
            }

            Console.WriteLine();
            Console.WriteLine("User information saved successfully to: " + outputFilePath);
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
