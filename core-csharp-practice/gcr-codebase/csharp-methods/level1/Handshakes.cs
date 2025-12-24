using System;

class Handshakes
{
    static int CalculateHandshakes(int students)
    {
        return (students * (students - 1)) / 2;
    }

    static void Main()
    {
        int students = Convert.ToInt32(Console.ReadLine());
        int handshakes = CalculateHandshakes(students);
        Console.WriteLine(handshakes);
    }
}
