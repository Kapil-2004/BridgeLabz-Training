using System;

class Program
{
    static void Main()
    {
        TicketReservationSystem trs = new TicketReservationSystem();

        trs.AddTicket(101, "Rahul", "Inception", "A1", "10:30 AM");
        trs.AddTicket(102, "Anita", "Interstellar", "B2", "1:00 PM");
        trs.AddTicket(103, "Rahul", "Inception", "A2", "10:30 AM");

        trs.DisplayTickets();

        Console.WriteLine("\nSearch by Customer:");
        trs.SearchTicket("Rahul");

        Console.WriteLine("\nTotal Tickets: " + trs.CountTickets());

        trs.RemoveTicket(102);
        trs.DisplayTickets();
    }
}
