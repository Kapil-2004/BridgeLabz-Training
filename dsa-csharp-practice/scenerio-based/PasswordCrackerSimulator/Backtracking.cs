using System;

namespace PasswordCrackerSimulator
{
    class Backtracking
    {
        // Static array containing all 26 lowercase letters
        static char[] letters ={'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
        static int count = 0;

        // Start cracking
        public static void CrackPassword(string password, int length)
        {
            char[] current = new char[length];
            Generate(current, 0, password);
        }

        // Backtracking function
        static bool Generate(char[] current, int index, string password)
        {
            // If full password length is generated
            if (index == current.Length)
            {
                count++;  
                string attempt = new string(current);

                Console.WriteLine("Attempt "+ count + " " + attempt);

                if (attempt == password)
                {
                    Console.WriteLine("\nPassword Found: " + attempt);
                    Console.WriteLine("Total Attempts: " + count);
                    return true;
                }
                return false;
            }

            // Try every letter (a-z) at current position
            for (int i = 0; i < letters.Length; i++)
            {
                current[index] = letters[i];

                if (Generate(current, index + 1, password))
                    return true;
            }

            return false;
        }
    }
}
