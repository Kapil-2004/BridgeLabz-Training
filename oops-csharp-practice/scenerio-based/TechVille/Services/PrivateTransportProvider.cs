using System;
using System.Collections.Generic;

namespace TechVille.Services
{
    /// <summary>
    /// Module 9: PrivateTransportProvider
    /// Demonstrates: Different interface implementation showing polymorphism
    /// Implements: IBookable, ITrackable
    /// Purpose: External transport provider with booking and tracking (no cancellation)
    /// </summary>
    public class PrivateTransportProvider : ServiceProvider, IBookable, ITrackable
    {
        // ===== PRIVATE ATTRIBUTES =====
        private int vehicleCount;
        private int busyVehicles;
        private float averageFare;
        private Dictionary<string, string> activeRoutes;

        // ===== CONSTRUCTOR =====
        public PrivateTransportProvider(string providerName, double budget, int vehicleCount)
            : base(providerName, "Transportation", budget)
        {
            this.vehicleCount = vehicleCount;
            this.busyVehicles = 0;
            this.averageFare = 50.0f;
            this.activeRoutes = new Dictionary<string, string>();
        }

        // ===== IBookable Implementation =====

        public bool HasAvailableSlots()
        {
            return busyVehicles < vehicleCount;
        }

        public bool BookService(string citizenName)
        {
            if (HasAvailableSlots())
            {
                busyVehicles++;
                string bookingId = $"TRK{DateTime.Now:HHmmss}";
                string[] destinations = { "City Center", "Railway Station", "Airport", "Hospital" };
                string destination = destinations[new Random().Next(destinations.Length)];
                activeRoutes[bookingId] = destination;
                LogServiceTransaction($"Transport booking: {citizenName} to {destination}");
                UpdateRating(true);
                Console.WriteLine($"✅ Booking Confirmed - ID: {bookingId}");
                return true;
            }
            Console.WriteLine($"❌ No vehicles available!");
            return false;
        }

        public int GetAvailableSlots()
        {
            return vehicleCount - busyVehicles;
        }

        public int GetMaxCapacity()
        {
            return vehicleCount;
        }

        // ===== ITrackable Implementation =====

        public string GetServiceStatus()
        {
            return $"{ProviderName}: {busyVehicles}/{vehicleCount} vehicles in service";
        }

        public void DisplayPerformanceMetrics()
        {
            Console.WriteLine($"\n🚗 Transport Provider Performance:");
            Console.WriteLine($"Fleet Utilization: {(busyVehicles * 100.0 / vehicleCount):F1}%");
            Console.WriteLine($"Average Fare: ₹{averageFare:F2}");
            Console.WriteLine($"Active Routes: {activeRoutes.Count}");
            Console.WriteLine($"Rating: {GetProviderRating():F1}/5.0");
        }

        public string TrackBooking(string bookingId)
        {
            if (activeRoutes.ContainsKey(bookingId))
            {
                return $"✅ Journey Tracked: {bookingId} to {activeRoutes[bookingId]} (In Transit)";
            }
            else
            {
                return $"❌ Booking Not Found: {bookingId}";
            }
        }

        // ===== ABSTRACT METHOD IMPLEMENTATIONS =====

        public override void ProvideService(string citizenName)
        {
            Console.WriteLine($"\n🚕 Transport Service for {citizenName}");
            BookService(citizenName);
        }

        public override void DisplayDetailedStatus()
        {
            DisplayProviderInfo();
            Console.WriteLine($"\n🚗 Transport Provider Details:");
            Console.WriteLine($"Total Vehicles: {vehicleCount}");
            Console.WriteLine($"Busy Vehicles: {busyVehicles}");
            Console.WriteLine($"Available: {vehicleCount - busyVehicles}");
            Console.WriteLine($"Fleet Utilization: {(busyVehicles * 100.0 / vehicleCount):F1}%");
            Console.WriteLine($"Average Fare: ₹{averageFare:F2}");
        }
    }
}
