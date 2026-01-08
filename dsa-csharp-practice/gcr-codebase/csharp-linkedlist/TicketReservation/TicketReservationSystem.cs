using System;

class TicketReservationSystem
{
    private Ticket head = null;
    private Ticket tail = null;

    // Add ticket at end
    public void AddTicket(int id, string customer, string movie, string seat, string time)
    {
        Ticket newTicket = new Ticket(id, customer, movie, seat, time);

        if (head == null)
        {
            head = tail = newTicket;
            tail.next = head;
        }
        else
        {
            tail.next = newTicket;
            tail = newTicket;
            tail.next = head;
        }
    }

    // Remove ticket by Ticket ID
    public void RemoveTicket(int id)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets to remove");
            return;
        }

        Ticket curr = head;
        Ticket prev = tail;

        do
        {
            if (curr.TicketID == id)
            {
                if (curr == head)
                {
                    head = head.next;
                    tail.next = head;
                }
                else if (curr == tail)
                {
                    tail = prev;
                    tail.next = head;
                }
                else
                {
                    prev.next = curr.next;
                }

                Console.WriteLine("Ticket removed successfully");
                return;
            }

            prev = curr;
            curr = curr.next;

        } while (curr != head);

        Console.WriteLine("Ticket not found");
    }

    // Display all tickets
    public void DisplayTickets()
    {
        if (head == null)
        {
            Console.WriteLine("No booked tickets");
            return;
        }

        Ticket temp = head;
        do
        {
            Console.WriteLine($"ID: {temp.TicketID}, Customer: {temp.CustomerName}, Movie: {temp.MovieName}, Seat: {temp.SeatNumber}, Time: {temp.BookingTime}");
            temp = temp.next;
        } while (temp != head);
    }

    // Search by Customer or Movie
    public void SearchTicket(string key)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets available");
            return;
        }

        Ticket temp = head;
        bool found = false;

        do
        {
            if (temp.CustomerName == key || temp.MovieName == key)
            {
                Console.WriteLine($"Found → ID: {temp.TicketID}, Seat: {temp.SeatNumber}");
                found = true;
            }
            temp = temp.next;
        } while (temp != head);

        if (!found)
            Console.WriteLine("No matching ticket found");
    }

    // Count total tickets
    public int CountTickets()
    {
        if (head == null)
            return 0;

        int count = 0;
        Ticket temp = head;

        do
        {
            count++;
            temp = temp.next;
        } while (temp != head);

        return count;
    }
}
