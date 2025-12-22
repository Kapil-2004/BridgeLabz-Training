using System;

class VotingAge
{
    static void Main(String[] args)
    {
        int age = int.Parse(Console.ReadLine());
        if (age >= 18)
        {
            Console.WriteLine("The Person's age is "+age + " and can vote");
        }
        else
        {
            Console.WriteLine("The Person's age is "+age + " and can not vote");
        }
    }
}