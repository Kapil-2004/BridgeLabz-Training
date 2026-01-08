using System;

namespace SmartHomeAutomationSystem
{
class Fan : Appliance
{
    public Fan(string name) : base(name) { }

    public override void TurnOn()
    {
        Console.WriteLine(Name + " fan is rotating at medium speed.");
    }

    public override void TurnOff()
    {
        Console.WriteLine(Name + " fan is stopped.");
    }
}

}