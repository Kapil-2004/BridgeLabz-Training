class Ticket
{
    public int TicketID;
    public string CustomerName;
    public string MovieName;
    public string SeatNumber;
    public string BookingTime;
    public Ticket next;

    public Ticket(int id, string customer, string movie, string seat, string time)
    {
        TicketID = id;
        CustomerName = customer;
        MovieName = movie;
        SeatNumber = seat;
        BookingTime = time;
        next = null;
    }
}
