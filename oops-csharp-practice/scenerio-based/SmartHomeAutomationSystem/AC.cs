
using System;
namespace SmartHomeAutomationSystem
{
    class AC : Appliance
{
    public AC(string name) : base(name) { }

    public override void TurnOn()
    {
        Console.WriteLine(Name + " AC is cooling the room.");
    }

    public override void TurnOff()
    {
        Console.WriteLine(Name + " AC is powered off.");
    }
}

}