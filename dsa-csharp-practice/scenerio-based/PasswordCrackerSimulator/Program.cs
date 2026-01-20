using System;

namespace PasswordCrackerSimulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the Length 1-4");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Password of length " + n + " in samll Alphabets" );
            string password = Console.ReadLine();

            Backtracking.CrackPassword(password, n);
        }
    }
}