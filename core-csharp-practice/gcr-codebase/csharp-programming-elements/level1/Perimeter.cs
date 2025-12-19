using System ;

class Perimeter
{
    static void Main(string[] args)
    {
        int perimeter = int.Parse(Console.ReadLine());
        int length = Perimeter / 4;
        Console.WriteLine($"The length of the side is {length} whose perimeter is {perimeter}");
    }
}   