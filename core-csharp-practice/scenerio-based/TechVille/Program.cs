using System;

namespace TechVille
{
    class Program
    {
        /// Module 4 Summary:
        /// This module focuses on citizen profile management using strings and reusable methods.
        /// It demonstrates string manipulation, email validation, string-based search, and
        /// explains the difference between pass-by-value and pass-by-reference in C#.
        static void Main(string[] args)
        {
            string[] names = new string[50];
            string[] emails = new string[50];
            int count = 0;

            while (true)
            {
                Console.WriteLine("\n===== Module 4: Citizen Profile Management =====");
                Console.WriteLine("1. Add Profile");
                Console.WriteLine("2. Search Profile");
                Console.WriteLine("3. Update Email (Pass by Value)");
                Console.WriteLine("4. Update Email (Pass by Reference)");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice!");
                    continue;
                }

                if (choice == 0)
                    break;

                switch (choice)
                {
                    case 1:
                        if (count >= 50)
                        {
                            Console.WriteLine("Storage full!");
                            break;
                        }

                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(name))
                        {
                            Console.WriteLine("Invalid name!");
                            break;
                        }

                        name = FormatName(name);

                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();

                        if (!IsValidEmail(email))
                        {
                            Console.WriteLine("Invalid email!");
                            break;
                        }

                        email = email.Trim().ToLower();

                        names[count] = name;
                        emails[count] = email;
                        count++;

                        Console.WriteLine("Profile added successfully!");
                        break;

                    case 2:
                        if (count == 0)
                        {
                            Console.WriteLine("No profiles found!");
                            break;
                        }

                        Console.Write("Enter name to search: ");
                        string searchName = Console.ReadLine();

                        int index = SearchCitizen(names, count, searchName);

                        if (index == -1)
                            Console.WriteLine("Citizen not found!");
                        else
                            Console.WriteLine($"Citizen Found: {names[index]} | {emails[index]}");

                        break;

                    case 3:
                        // Pass by Value Demo
                        Console.Write("Enter name to update email: ");
                        string updateName1 = Console.ReadLine();

                        int updateIndex1 = SearchCitizen(names, count, updateName1);

                        if (updateIndex1 == -1)
                        {
                            Console.WriteLine("Citizen not found!");
                            break;
                        }

                        Console.Write("Enter new email: ");
                        string newEmail1 = Console.ReadLine();

                        if (!IsValidEmail(newEmail1))
                        {
                            Console.WriteLine("Invalid email!");
                            break;
                        }

                        newEmail1 = newEmail1.Trim().ToLower();

                        string emailCopy = emails[updateIndex1];
                        UpdateEmailByValue(emailCopy, newEmail1);

                        Console.WriteLine("Pass by Value: Email NOT updated in array.");
                        Console.WriteLine("Stored Email: " + emails[updateIndex1]);
                        break;

                    case 4:
                        // Pass by Reference Demo
                        Console.Write("Enter name to update email: ");
                        string updateName2 = Console.ReadLine();

                        int updateIndex2 = SearchCitizen(names, count, updateName2);

                        if (updateIndex2 == -1)
                        {
                            Console.WriteLine("Citizen not found!");
                            break;
                        }

                        Console.Write("Enter new email: ");
                        string newEmail2 = Console.ReadLine();

                        if (!IsValidEmail(newEmail2))
                        {
                            Console.WriteLine("Invalid email!");
                            break;
                        }

                        newEmail2 = newEmail2.Trim().ToLower();

                        UpdateEmailByReference(ref emails[updateIndex2], newEmail2);

                        Console.WriteLine("Pass by Reference: Email updated successfully!");
                        Console.WriteLine("Updated Email: " + emails[updateIndex2]);
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }

        /// <summary>
        /// Module 4 Summary:
        /// This program manages citizen profiles using strings and methods.
        /// It supports adding, searching, and updating citizen information.
        /// It demonstrates pass-by-value and pass-by-reference.
        /// </summary>

        // Name Formatting Method
        static string FormatName(string name)
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

        // Email Validation Method
        static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            email = email.Trim();

            return email.Contains("@") && email.Contains(".");
        }

        // Search Method using String Matching
        static int SearchCitizen(string[] names, int count, string searchName)
        {
            if (string.IsNullOrWhiteSpace(searchName))
                return -1;

            searchName = searchName.Trim().ToLower();

            for (int i = 0; i < count; i++)
            {
                if (names[i].ToLower().Contains(searchName))
                {
                    return i;
                }
            }

            return -1;
        }

        // Pass by Value Method
        static void UpdateEmailByValue(string oldEmail, string newEmail)
        {
            oldEmail = newEmail;
        }

        // Pass by Reference Method
        static void UpdateEmailByReference(ref string oldEmail, string newEmail)
        {
            oldEmail = newEmail;
        }
    }
}
