
using System;
namespace SmartHomeAutomationSystem
{
    class Program
{
    static void Main()
    {
        Appliance[] devices =
        {
            new Light("Bedroom"),
            new Fan("Hall"),
            new AC("Living Room")
        };

        foreach (Appliance device in devices)
        {
            device.TurnOn();
        }

        Console.WriteLine();

        foreach (Appliance device in devices)
        {
            device.TurnOff();
        }
    }
}
 
}