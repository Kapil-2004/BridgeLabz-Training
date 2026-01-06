using System;

// Base class
abstract class Bird
{
    public string Name { get; set; }

    public Bird(string name)
    {
        Name = name;
    }

    public abstract void Display();
}

// Interfaces
interface IFlyable
{
    void Fly();
}

interface ISwimmable
{
    void Swim();
}

// Derived Classes
class Eagle : Bird, IFlyable
{
    public Eagle(string name) : base(name) { }

    public override void Display()
    {
        Console.WriteLine($"Eagle: {Name}");
    }

    public void Fly()
    {
        Console.WriteLine($"{Name} is soaring high in the sky.");
    }
}

class Sparrow : Bird, IFlyable
{
    public Sparrow(string name) : base(name) { }

    public override void Display()
    {
        Console.WriteLine($"Sparrow: {Name}");
    }

    public void Fly()
    {
        Console.WriteLine($"{Name} is flying short distances.");
    }
}

class Duck : Bird, ISwimmable
{
    public Duck(string name) : base(name) { }

    public override void Display()
    {
        Console.WriteLine($"Duck: {Name}");
    }

    public void Swim()
    {
        Console.WriteLine($"{Name} is swimming in the pond.");
    }
}

class Penguin : Bird, ISwimmable
{
    public Penguin(string name) : base(name) { }

    public override void Display()
    {
        Console.WriteLine($"Penguin: {Name}");
    }

    public void Swim()
    {
        Console.WriteLine($"{Name} is swimming in cold water.");
    }
}

class Seagull : Bird, IFlyable, ISwimmable
{
    public Seagull(string name) : base(name) { }

    public override void Display()
    {
        Console.WriteLine($"Seagull: {Name}");
    }

    public void Fly()
    {
        Console.WriteLine($"{Name} is flying over the sea.");
    }

    public void Swim()
    {
        Console.WriteLine($"{Name} is floating on water.");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        Bird[] birds = new Bird[]
        {
            new Eagle("Golden Eagle"),
            new Sparrow("House Sparrow"),
            new Duck("Mallard Duck"),
            new Penguin("Emperor Penguin"),
            new Seagull("Ocean Seagull")
        };

        foreach (Bird bird in birds)
        {
            bird.Display();

            if (bird is IFlyable)
            {
                ((IFlyable)bird).Fly();
            }

            if (bird is ISwimmable)
            {
                ((ISwimmable)bird).Swim();
            }

            Console.WriteLine("------------------------");
        }
    }
}
