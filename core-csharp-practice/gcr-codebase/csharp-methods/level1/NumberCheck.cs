using System;

class NumberCheck
{
    static int check(int number)
    {
        if(number>0) return 1;
        else if(number<0) return -1;
        else return 0;
    }

    static void Main()
    {
        int number = Convert.ToInt32(Console.ReadLine());
        int result = check(number);
        Console.WriteLine(result);
    }
}