using System;

class VowelConsonantCount
{
    static void Main()
    {
        string input = Console.ReadLine();

        int vowels = 0, consonants = 0;

        for (int i = 0; i < input.Length; i++)
        {
            char ch = input[i];

            // Convert uppercase letters to lowercase for simplicity
            if (ch >= 'A' && ch <= 'Z') ch = (char)(ch + 32);

            if (ch >= 'a' && ch <= 'z') // consider only letters
            {
                if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                    vowels++;
                else
                    consonants++;
            }
        }

        Console.WriteLine("Vowels: " + vowels);
        Console.WriteLine("Consonants: " + consonants);
    }
}
