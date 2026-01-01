using System;

class HotelBooking
{
    private string guestName;
    private string roomType;
    private int nights;

    // Default Constructor
    public HotelBooking()
    {
        guestName = "You can call me X";
        roomType = "Standard";
        nights = 1;
    }

    // Parameterized Constructor
    public HotelBooking(string guestName, string roomType, int nights)
    {
        this.guestName = guestName;
        this.roomType = roomType;
        this.nights = nights;
    }

    // Copy Constructor
    public HotelBooking(HotelBooking booking)
    {
        guestName = booking.guestName;
        roomType = booking.roomType;
        nights = booking.nights;
    }

    // Display Booking Details
    public void DisplayBooking()
    {
        Console.WriteLine("Guest Name : " + guestName);
        Console.WriteLine("Room Type  : " + roomType);
        Console.WriteLine("Nights     : " + nights);
        Console.WriteLine("--------------------------");
    }

    static void Main(string[] args)
    {
        // Default booking
        HotelBooking booking1 = new HotelBooking();
        booking1.DisplayBooking();

        // Parameterized booking
        HotelBooking booking2 = new HotelBooking(Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()));
        booking2.DisplayBooking();

        // Copy booking
        HotelBooking booking3 = new HotelBooking(booking2);
        booking3.DisplayBooking();
    }
}
