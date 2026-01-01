using System;

class Vehicle
{
    // Instance variables
    private string ownerName;
    private string vehicleType;

    // Class variable (shared)
    private static double registrationFee = 5000;

    // Constructor
    public Vehicle(string ownerName, string vehicleType)
    {
        this.ownerName = ownerName;
        this.vehicleType = vehicleType;
    }

    // Instance method
    public void DisplayVehicleDetails()
    {
        Console.WriteLine("Owner Name        : " + ownerName);
        Console.WriteLine("Vehicle Type     : " + vehicleType);
        Console.WriteLine("Registration Fee : Rs. " + registrationFee);
        Console.WriteLine("-------------------------------");
    }

    // Class (static) method
    public static void UpdateRegistrationFee(double newFee)
    {
        registrationFee = newFee;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter Registration Fee: ");
        double fee = Convert.ToDouble(Console.ReadLine());
        Vehicle.UpdateRegistrationFee(fee);

        Console.Write("Enter number of vehicles: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"\nEnter details for Vehicle {i}");

            Console.Write("Owner Name: ");
            string owner = Console.ReadLine();

            Console.Write("Vehicle Type: ");
            string type = Console.ReadLine();

            Vehicle v = new Vehicle(owner, type);
            v.DisplayVehicleDetails();
        }
    }
}
