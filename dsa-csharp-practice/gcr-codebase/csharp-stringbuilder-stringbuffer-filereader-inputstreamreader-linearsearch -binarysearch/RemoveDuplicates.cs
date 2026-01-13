using System;
using System.Text;

class RemoveDuplicates
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < input.Length; i++)
        {
            bool isDuplicate = false;

            // Check if character already exists in result
            for (int j = 0; j < result.Length; j++)
            {
                if (input[i] == result[j])
                {
                    isDuplicate = true;
                    break;
                }
            }

            if (!isDuplicate)
            {
                result.Append(input[i]);
            }
        }

        Console.WriteLine("String after removing duplicates: " + result.ToString());
    }
}
