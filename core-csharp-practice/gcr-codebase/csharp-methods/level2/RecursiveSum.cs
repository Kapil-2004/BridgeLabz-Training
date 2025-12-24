using System;

class SumOfNaturalNumbers
{
    static int RecursiveSum(int number)
    {
        if (number == 0)
            return 0;

        return number + RecursiveSum(number - 1);
    }

    static int FormulaSum(int number)
    {
        return number * (number + 1) / 2;
    }

    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());

        if (number <= 0)
            return;

        int recursiveResult = RecursiveSum(number);
        int formulaResult = FormulaSum(number);

        Console.WriteLine(recursiveResult);
        Console.WriteLine(formulaResult);
        Console.WriteLine(recursiveResult == formulaResult);
    }
}
