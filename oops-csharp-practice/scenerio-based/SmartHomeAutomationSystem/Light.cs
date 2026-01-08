
using System;
namespace SmartHomeAutomationSystem
{
    class Light : Appliance
{
    public Light(string name) : base(name) { }

    public override void TurnOn()
    {
        Console.WriteLine(Name + " light is glowing softly.");
    }

    public override void TurnOff()
    {
        Console.WriteLine(Name + " light is turned off.");
    }
}
}