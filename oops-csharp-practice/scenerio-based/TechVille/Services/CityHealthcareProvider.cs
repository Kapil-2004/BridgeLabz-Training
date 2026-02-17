using System;
using System.Collections.Generic;

namespace TechVille.Services
{
    /// <summary>
    /// Module 9: CityHealthcareProvider
    /// Demonstrates: Concrete implementation implementing multiple interfaces
    /// Implements: IBookable, ICancellable, ITrackable, IReportable
    /// Purpose: External healthcare provider with booking, cancellation, and tracking
    /// </summary>
    public class CityHealthcareProvider : ServiceProvider, IBookable, ICancellable, ITrackable
    {
        // ===== PRIVATE ATTRIBUTES =====
        private int totalSlots;
        private int bookedSlots;
        private List<string> activeBookings;
        private int cancellationDeadlineHours;

        // ===== CONSTRUCTOR =====
        public CityHealthcareProvider(string providerName, double budget, int totalSlots)
            : base(providerName, "Healthcare", budget)
        {
            this.totalSlots = totalSlots;
            this.bookedSlots = 0;
            this.activeBookings = new List<string>();
            this.cancellationDeadlineHours = 24;
        }

        // ===== IBookable Implementation =====

        public bool HasAvailableSlots()
        {
            return bookedSlots < totalSlots;
        }

        public bool BookService(string citizenName)
        {
            if (HasAvailableSlots())
            {
                bookedSlots++;
                string serviceType = "General Checkup";
                string booking = $"{citizenName} - {serviceType} - Slot {bookedSlots}";
                activeBookings.Add(booking);
                LogServiceTransaction($"Healthcare booking: {booking}");
                UpdateRating(true);
                return true;
            }
            return false;
        }

        public int GetAvailableSlots()
        {
            return totalSlots - bookedSlots;
        }

        public int GetMaxCapacity()
        {
            return totalSlots;
        }

        // ===== ICancellable Implementation =====

        public bool CancelBooking(string bookingId)
        {
            if (activeBookings.Contains(bookingId))
            {
                activeBookings.Remove(bookingId);
                bookedSlots--;
                LogServiceTransaction($"Healthcare booking cancelled: {bookingId}");
                UpdateRating(false);
                return true;
            }
            return false;
        }

        public bool IsCancellationAllowed()
        {
            // Cancellation allowed if there are active bookings and within deadline
            return activeBookings.Count > 0;
        }

        public int GetCancellationDeadlineHours()
        {
            return cancellationDeadlineHours;
        }

        // ===== ITrackable Implementation =====

        public string GetServiceStatus()
        {
            return $"{ProviderName}: {bookedSlots}/{totalSlots} slots booked";
        }

        public void DisplayPerformanceMetrics()
        {
            Console.WriteLine($"\n📈 Healthcare Provider Performance:");
            Console.WriteLine($"Capacity Utilization: {(bookedSlots * 100.0 / totalSlots):F1}%");
            Console.WriteLine($"Active Bookings: {activeBookings.Count}");
            Console.WriteLine($"Rating: {GetProviderRating():F1}/5.0");
        }

        public string TrackBooking(string bookingId)
        {
            if (activeBookings.Contains(bookingId))
            {
                return $"✅ Booking Found: {bookingId} with {ProviderName}";
            }
            else
            {
                return $"❌ Booking Not Found: {bookingId}";
            }
        }

        // ===== ABSTRACT METHOD IMPLEMENTATIONS =====

        public override void ProvideService(string citizenName)
        {
            Console.WriteLine($"\n🏥 Healthcare Service for {citizenName}");
            if (HasAvailableSlots())
            {
                if (BookService(citizenName))
                {
                    Console.WriteLine($"✅ Service booked successfully!");
                }
            }
            else
            {
                Console.WriteLine($"❌ No slots available!");
            }
        }

        public override void DisplayDetailedStatus()
        {
            DisplayProviderInfo();
            Console.WriteLine($"\n📋 Healthcare Provider Details:");
            Console.WriteLine($"Total Slots: {totalSlots}");
            Console.WriteLine($"Booked Slots: {bookedSlots}");
            Console.WriteLine($"Available: {totalSlots - bookedSlots}");
            Console.WriteLine($"Utilization: {(bookedSlots * 100.0 / totalSlots):F1}%");
            Console.WriteLine($"Cancellation Deadline: {cancellationDeadlineHours} hours");
        }
    }
}
