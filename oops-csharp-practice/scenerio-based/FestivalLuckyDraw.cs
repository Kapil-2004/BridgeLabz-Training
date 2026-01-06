using System;

class FestivalLuckyDraw
{
    static void Main()
    {
        Console.WriteLine("Welcome to Diwali Mela Lucky Draw\n");

        for (int i = 1; i <= 5; i++)   // lucky draw for 5 visitors
        {
            Console.Write("Visitor " + i + ", enter your lucky number: ");
            
            int num;
            bool valid = int.TryParse(Console.ReadLine(), out num);

            if (!valid || num <= 0)
            {
                Console.WriteLine("Invalid number! Try next visitor.\n");
                continue;   // skip this visitor
            }

            if (num % 3 == 0 && num % 5 == 0)
            {
                Console.WriteLine("Congratulations! You won a gift!\n");
            }
            else
            {
                Console.WriteLine("Better luck next time.\n");
            }
        }

        Console.WriteLine("Lucky Draw finished. Happy Diwali!");
    }
}
