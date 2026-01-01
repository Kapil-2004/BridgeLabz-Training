using System;

class Person
{
    private string name;
    private int age;

    private string fullname;

    public Person(string name , int age)
    {
        this.name = name;
        this.age = age;
        this.fullname = null;
    }

    public Person(Person p , string surname)
    {
        name = p.name;
        fullname = p.name + " " + surname;
        age = p.age;
    }

    public void display()
    {
        Console.WriteLine("Name  : " + name);
        Console.WriteLine("Age : " + age);
        if(!string.IsNullOrEmpty(fullname))
            Console.WriteLine("Full Name : " + fullname);
        Console.WriteLine("-----------------------");
    }
    static void Main(string[] args)
    {
        Person p1 = new Person("Kapil" , 22);
        p1.display();

        Person p2 = new Person(p1 , "Gautam");
        p2.display();
    }
}