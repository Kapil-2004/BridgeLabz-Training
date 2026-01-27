using System;

public class MethodOverridingDemo
{
    // Parent class
    class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("The animal makes a sound.");
        }
    }

    // Child class
    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("The dog barks.");
        }
    }

    public static void Main()
    {
        Dog dog = new Dog();
        dog.MakeSound();   // Calls overridden method
    }
}
