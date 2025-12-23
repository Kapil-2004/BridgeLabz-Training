using System;

class Voting
{
    static void Main(string[] agrs)
    {
        int []arr = new int [10];
        for(int i=0; i<10; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        for(int i=0; i<10; i++)
        {
            if(arr[i] >= 18)
            {
                Console.WriteLine("Vote Accepted");
            }
            else
            {
                Console.WriteLine("Vote Denied");
            }
        }
    }
}