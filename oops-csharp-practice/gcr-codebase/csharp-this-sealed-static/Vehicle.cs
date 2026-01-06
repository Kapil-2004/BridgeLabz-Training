using System;

class Vehicle
{
    // static variable (common registration fee)
    public static double RegistrationFee = 1500.0;

    // readonly variable
    public readonly string RegistrationNumber;

    // instance variables
    public string OwnerName;
    public string VehicleType;

    // constructor using 'this'
    public Vehicle(string OwnerName, string VehicleType, string RegistrationNumber)
    {
        this.OwnerName = OwnerName;
        this.VehicleType = VehicleType;
        this.RegistrationNumber = RegistrationNumber; // readonly assigned once
    }

    // static method to update registration fee
    public static void UpdateRegistrationFee(double newFee)
    {
        RegistrationFee = newFee;
    }

    // method to display vehicle details
    public void DisplayDetails()
    {
        Console.WriteLine("Owner Name          : " + OwnerName);
        Console.WriteLine("Vehicle Type        : " + VehicleType);
        Console.WriteLine("Registration Number : " + RegistrationNumber);
        Console.WriteLine("Registration Fee    : " + RegistrationFee);
    }
}

class Program
{
    static void Main()
    {
        Vehicle v1 = new Vehicle("Arjun", "Car", "MH12AB1234");
        Vehicle v2 = new Vehicle("Kavya", "Bike", "DL05XY6789");

        // update static registration fee
        Vehicle.UpdateRegistrationFee(2000.0);

        // is operator usage
        if (v1 is Vehicle)
        {
            Console.WriteLine("\nVehicle 1 Details:");
            v1.DisplayDetails();
        }

        if (v2 is Vehicle)
        {
            Console.WriteLine("\nVehicle 2 Details:");
            v2.DisplayDetails();
        }
    }
}
