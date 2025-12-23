using System;

class OddEven
{
    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());
        if (number <= 0)
        {
            Console.WriteLine("Error: Please enter a natural number greater than 0.");
            return;
        }

        int size = number / 2 + 1;
        int[] even = new int[size];
        int[] odd = new int[size];

        int evenIndex = 0;
        int oddIndex = 0;

        for (int i = 1; i <= number; i++)
        {
            if (i % 2 == 0)
            {
                even[evenIndex] = i;
                evenIndex++;
            }
            else
            {
                odd[oddIndex] = i;
                oddIndex++;
            }
        }
        for (int i = 0; i < oddIndex; i++)
        {
            Console.Write(odd[i] + " ");
        }
        for (int i = 0; i < evenIndex; i++)
        {
            Console.Write(even[i] + " ");
        }
    }
}
