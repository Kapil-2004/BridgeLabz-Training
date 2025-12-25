using System;

class NumberChecker
{
    static bool IsPrime(int number)
    {
        if (number <= 1)
            return false;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }

    static bool IsNeonNumber(int number)
    {
        int square = number * number;
        int sum = 0;

        while (square != 0)
        {
            sum += square % 10;
            square /= 10;
        }

        return sum == number;
    }

    static bool IsSpyNumber(int number)
    {
        int sum = 0;
        int product = 1;

        while (number != 0)
        {
            int digit = number % 10;
            sum += digit;
            product *= digit;
            number /= 10;
        }

        return sum == product;
    }

    static bool IsAutomorphicNumber(int number)
    {
        int square = number * number;
        int temp = number;

        while (temp != 0)
        {
            if (square % 10 != temp % 10)
                return false;

            square /= 10;
            temp /= 10;
        }

        return true;
    }

    static bool IsBuzzNumber(int number)
    {
        return number % 7 == 0 || number % 10 == 7;
    }

    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(IsPrime(number));
        Console.WriteLine(IsNeonNumber(number));
        Console.WriteLine(IsSpyNumber(number));
        Console.WriteLine(IsAutomorphicNumber(number));
        Console.WriteLine(IsBuzzNumber(number));
    }
}
