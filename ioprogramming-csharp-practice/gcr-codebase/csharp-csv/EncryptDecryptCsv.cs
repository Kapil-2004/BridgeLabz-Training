using System;
using System.IO;
using System.Text;

class EncryptDecryptCsv
{
    // Encrypt string using Base64
    static string Encrypt(string plainText)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(bytes);
    }

    // Decrypt string using Base64
    static string Decrypt(string encryptedText)
    {
        byte[] bytes = Convert.FromBase64String(encryptedText);
        return Encoding.UTF8.GetString(bytes);
    }

    static void Main()
    {
        // Sample employee data
        string[] employees =
        {
            "ID,Name,Department,Salary,Email",
            "1,Rahul,IT,50000,rahul@gmail.com",
            "2,Amit,HR,45000,amit@gmail.com",
            "3,Priya,Finance,55000,priya@gmail.com"
        };

        string encryptedFile = "employees_encrypted.csv";

        // --- Write Encrypted CSV ---
        using (StreamWriter sw = new StreamWriter(encryptedFile))
        {
            sw.WriteLine(employees[0]); // header

            for (int i = 1; i < employees.Length; i++)
            {
                var data = employees[i].Split(',');

                // Encrypt Salary and Email
                data[3] = Encrypt(data[3]);
                data[4] = Encrypt(data[4]);

                sw.WriteLine(string.Join(",", data));
            }
        }

        Console.WriteLine("CSV file written with encrypted data.\n");

        // --- Read and Decrypt CSV ---
        var lines = File.ReadAllLines(encryptedFile);
        Console.WriteLine("Decrypted CSV Data:");

        for (int i = 0; i < lines.Length; i++)
        {
            if (i == 0)
            {
                Console.WriteLine(lines[i]); // header
                continue;
            }

            var data = lines[i].Split(',');
            data[3] = Decrypt(data[3]); // Salary
            data[4] = Decrypt(data[4]); // Email

            Console.WriteLine(string.Join(",", data));
        }
    }
}
