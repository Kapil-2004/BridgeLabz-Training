using System;
using System.Collections.Generic;

namespace TechVille.Services
{
    /// <summary>
    /// Module 8: Service Booking Helper Class
    /// Demonstrates: Method Overloading
    /// Multiple methods with same name but different parameters
    /// </summary>
    public class ServiceBooking
    {
        private Service service;
        private List<BookingRecord> bookings;

        // ===== CONSTRUCTOR =====
        public ServiceBooking(Service service)
        {
            this.service = service;
            this.bookings = new List<BookingRecord>();
        }

        // ===== OVERLOADED BOOKING METHODS =====

        /// <summary>
        /// Overload 1: Book with citizen name only
        /// </summary>
        public void BookService(string citizenName)
        {
            BookingRecord booking = new BookingRecord(citizenName, DateTime.Now, "Standard");
            bookings.Add(booking);
            Console.WriteLine($"✅ Service booked for {citizenName}");
            Console.WriteLine($"   Service: {service.ServiceName}");
            Console.WriteLine($"   Date: {booking.BookingDate:yyyy-MM-dd HH:mm}");
        }

        /// <summary>
        /// Overload 2: Book with citizen name and date
        /// </summary>
        public void BookService(string citizenName, DateTime bookingDate)
        {
            BookingRecord booking = new BookingRecord(citizenName, bookingDate, "Standard");
            bookings.Add(booking);
            Console.WriteLine($"✅ Service booked for {citizenName}");
            Console.WriteLine($"   Service: {service.ServiceName}");
            Console.WriteLine($"   Booking Date: {bookingDate:yyyy-MM-dd HH:mm}");
        }

        /// <summary>
        /// Overload 3: Book with citizen name, date, and priority
        /// </summary>
        public void BookService(string citizenName, DateTime bookingDate, string priority)
        {
            BookingRecord booking = new BookingRecord(citizenName, bookingDate, priority);
            bookings.Add(booking);
            Console.WriteLine($"✅ Service booked for {citizenName}");
            Console.WriteLine($"   Service: {service.ServiceName}");
            Console.WriteLine($"   Booking Date: {bookingDate:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"   Priority: {priority}");
        }

        /// <summary>
        /// Overload 4: Book with citizen name, date, priority, and duration
        /// </summary>
        public void BookService(string citizenName, DateTime bookingDate, string priority, int durationMinutes)
        {
            BookingRecord booking = new BookingRecord(citizenName, bookingDate, priority, durationMinutes);
            bookings.Add(booking);
            Console.WriteLine($"✅ Service booked for {citizenName}");
            Console.WriteLine($"   Service: {service.ServiceName}");
            Console.WriteLine($"   Booking Date: {bookingDate:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"   Priority: {priority}");
            Console.WriteLine($"   Duration: {durationMinutes} minutes");
            Console.WriteLine($"   End Time: {bookingDate.AddMinutes(durationMinutes):HH:mm}");
        }

        /// <summary>
        /// Overload 5: Book with citizen ID, name, and date
        /// </summary>
        public void BookService(int citizenId, string citizenName, DateTime bookingDate)
        {
            BookingRecord booking = new BookingRecord(citizenId, citizenName, bookingDate, "Standard");
            bookings.Add(booking);
            Console.WriteLine($"✅ Service booked (ID: {citizenId}) for {citizenName}");
            Console.WriteLine($"   Service: {service.ServiceName}");
            Console.WriteLine($"   Booking Date: {bookingDate:yyyy-MM-dd HH:mm}");
        }

        /// <summary>
        /// Overload 6: Book with complete details including notes
        /// </summary>
        public void BookService(int citizenId, string citizenName, DateTime bookingDate, string priority, string notes)
        {
            BookingRecord booking = new BookingRecord(citizenId, citizenName, bookingDate, priority, notes);
            bookings.Add(booking);
            Console.WriteLine($"✅ Service booked (ID: {citizenId}) for {citizenName}");
            Console.WriteLine($"   Service: {service.ServiceName}");
            Console.WriteLine($"   Booking Date: {bookingDate:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"   Priority: {priority}");
            Console.WriteLine($"   Notes: {notes}");
        }

        // ===== OVERLOADED CANCELLATION METHODS =====

        /// <summary>
        /// Overload 1: Cancel by citizen name
        /// </summary>
        public void CancelBooking(string citizenName)
        {
            BookingRecord booking = bookings.Find(b => b.CitizenName == citizenName);
            if (booking != null)
            {
                bookings.Remove(booking);
                Console.WriteLine($"✅ Booking cancelled for {citizenName}");
            }
            else
            {
                Console.WriteLine($"❌ No booking found for {citizenName}");
            }
        }

        /// <summary>
        /// Overload 2: Cancel by citizen ID
        /// </summary>
        public void CancelBooking(int citizenId)
        {
            BookingRecord booking = bookings.Find(b => b.CitizenId == citizenId);
            if (booking != null)
            {
                bookings.Remove(booking);
                Console.WriteLine($"✅ Booking cancelled for citizen ID {citizenId}");
            }
            else
            {
                Console.WriteLine($"❌ No booking found for citizen ID {citizenId}");
            }
        }

        /// <summary>
        /// Overload 3: Cancel by citizen name and date
        /// </summary>
        public void CancelBooking(string citizenName, DateTime bookingDate)
        {
            BookingRecord booking = bookings.Find(b => b.CitizenName == citizenName && b.BookingDate.Date == bookingDate.Date);
            if (booking != null)
            {
                bookings.Remove(booking);
                Console.WriteLine($"✅ Booking cancelled for {citizenName} on {bookingDate:yyyy-MM-dd}");
            }
            else
            {
                Console.WriteLine($"❌ No booking found for {citizenName} on {bookingDate:yyyy-MM-dd}");
            }
        }

        // ===== DISPLAY METHODS =====

        /// <summary>
        /// Display all bookings
        /// </summary>
        public void DisplayAllBookings()
        {
            if (bookings.Count == 0)
            {
                Console.WriteLine($"No bookings for {service.ServiceName}");
                return;
            }

            Console.WriteLine($"\n📋 All Bookings for {service.ServiceName}:");
            for (int i = 0; i < bookings.Count; i++)
            {
                BookingRecord booking = bookings[i];
                Console.WriteLine($"\n[Booking {i + 1}]");
                Console.WriteLine($"   Citizen: {booking.CitizenName} (ID: {booking.CitizenId})");
                Console.WriteLine($"   Date: {booking.BookingDate:yyyy-MM-dd HH:mm}");
                Console.WriteLine($"   Priority: {booking.Priority}");
                if (!string.IsNullOrEmpty(booking.Notes))
                    Console.WriteLine($"   Notes: {booking.Notes}");
            }
        }

        /// <summary>
        /// Get total bookings count
        /// </summary>
        public int GetTotalBookings()
        {
            return bookings.Count;
        }
    }

    // ===== BOOKING RECORD HELPER CLASS =====

    /// <summary>
    /// Helper class to store booking information
    /// </summary>
    public class BookingRecord
    {
        public int CitizenId { get; set; }
        public string CitizenName { get; set; }
        public DateTime BookingDate { get; set; }
        public string Priority { get; set; }
        public int DurationMinutes { get; set; }
        public string Notes { get; set; }
        public DateTime BookedTime { get; set; }

        // ===== CONSTRUCTORS =====

        public BookingRecord(string citizenName, DateTime bookingDate, string priority)
        {
            this.CitizenId = -1;  // No ID provided
            this.CitizenName = citizenName;
            this.BookingDate = bookingDate;
            this.Priority = priority;
            this.DurationMinutes = 30;  // Default
            this.Notes = "";
            this.BookedTime = DateTime.Now;
        }

        public BookingRecord(string citizenName, DateTime bookingDate, string priority, int durationMinutes)
        {
            this.CitizenId = -1;
            this.CitizenName = citizenName;
            this.BookingDate = bookingDate;
            this.Priority = priority;
            this.DurationMinutes = durationMinutes;
            this.Notes = "";
            this.BookedTime = DateTime.Now;
        }

        public BookingRecord(int citizenId, string citizenName, DateTime bookingDate, string priority)
        {
            this.CitizenId = citizenId;
            this.CitizenName = citizenName;
            this.BookingDate = bookingDate;
            this.Priority = priority;
            this.DurationMinutes = 30;
            this.Notes = "";
            this.BookedTime = DateTime.Now;
        }

        public BookingRecord(int citizenId, string citizenName, DateTime bookingDate, string priority, string notes)
        {
            this.CitizenId = citizenId;
            this.CitizenName = citizenName;
            this.BookingDate = bookingDate;
            this.Priority = priority;
            this.DurationMinutes = 30;
            this.Notes = notes;
            this.BookedTime = DateTime.Now;
        }

        // ===== OVERRIDE OBJECT METHODS =====

        public override string ToString()
        {
            return $"Booking: {CitizenName} ({BookingDate:yyyy-MM-dd HH:mm}) - {Priority}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BookingRecord))
                return false;

            BookingRecord other = (BookingRecord)obj;
            return this.CitizenId == other.CitizenId &&
                   this.CitizenName == other.CitizenName &&
                   this.BookingDate == other.BookingDate;
        }

        public override int GetHashCode()
        {
            return (CitizenId + CitizenName + BookingDate).GetHashCode();
        }
    }
}
