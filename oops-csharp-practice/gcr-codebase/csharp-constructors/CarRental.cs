using System;

class CarRental
{
    private string customerName;
    private string carModel;
    private int rentalDays;
    private int costPerDay;

    // Parameterized Constructor (used with user input)
    public CarRental(string customerName, string carModel, int rentalDays)
    {
        this.customerName = customerName;
        this.carModel = carModel;
        this.rentalDays = rentalDays;
        this.costPerDay = 1000; // Rs per day (fixed)
    }

    // Method to calculate total cost
    public int CalculateTotalCost()
    {
        return rentalDays * costPerDay;
    }

    // Display rental details
    public void DisplayRental()
    {
        Console.WriteLine("\n--- Rental Details ---");
        Console.WriteLine("Customer Name : " + customerName);
        Console.WriteLine("Car Model     : " + carModel);
        Console.WriteLine("Rental Days   : " + rentalDays);
        Console.WriteLine("Total Cost    : Rs. " + CalculateTotalCost());
        Console.WriteLine("---------------------------");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("🚗 Welcome to Car Rental System");

        Console.Write("Enter Customer Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Car Model: ");
        string model = Console.ReadLine();

        Console.Write("Enter Rental Days: ");
        int days = Convert.ToInt32(Console.ReadLine());

        // Create object using user input
        CarRental rental = new CarRental(name, model, days);

        // Display result
        rental.DisplayRental();
    }
}
