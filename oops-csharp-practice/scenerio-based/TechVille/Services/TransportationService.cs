using System;

namespace TechVille.Services
{
    /// <summary>
    /// Module 6: TransportationService Class
    /// Demonstrates: Inheritance, Method overriding, Polymorphism
    /// </summary>
    public class TransportationService : Service
    {
        // ===== PRIVATE ATTRIBUTES (Specific to Transportation) =====
        private int totalBuses;
        private int totalRoutes;
        private int dailyPassengers;
        private double farePerKm;

        // ===== CONSTRUCTOR =====
        public TransportationService(int serviceId, string description, double budgetAllocated,
                                    int totalBuses, int totalRoutes, double farePerKm)
            : base(serviceId, "Transportation", description, budgetAllocated)
        {
            this.totalBuses = totalBuses;
            this.totalRoutes = totalRoutes;
            this.dailyPassengers = 0;
            this.farePerKm = farePerKm;
        }

        // ===== PUBLIC PROPERTIES =====

        public int TotalBuses
        {
            get { return totalBuses; }
            set { totalBuses = value; }
        }

        public int TotalRoutes
        {
            get { return totalRoutes; }
            set { totalRoutes = value; }
        }

        public int DailyPassengers
        {
            get { return dailyPassengers; }
            set { dailyPassengers = value; }
        }

        public double FarePerKm
        {
            get { return farePerKm; }
            set { farePerKm = value; }
        }

        // ===== PUBLIC METHODS =====

        /// <summary>
        /// Record passenger boarding
        /// </summary>
        public void RecordPassenger(string passengerName)
        {
            dailyPassengers++;
            Console.WriteLine($"✅ {passengerName} boarded. Daily passengers: {dailyPassengers}");
        }

        /// <summary>
        /// Calculate fare for distance traveled
        /// </summary>
        public double CalculateFare(double kilometers)
        {
            return kilometers * farePerKm;
        }

        /// <summary>
        /// Override: ProvideService method
        /// </summary>
        public override void ProvideService(string citizenName)
        {
            Console.WriteLine($"🚌 Providing transportation service to {citizenName}...");
            Console.WriteLine($"Routes: {totalRoutes}, Buses: {totalBuses}, Fare: ₹{farePerKm}/km");
        }

        /// <summary>
        /// Override: DisplayServiceInfo
        /// </summary>
        public override void DisplayServiceInfo()
        {
            base.DisplayServiceInfo();
            Console.WriteLine($"Total Buses: {totalBuses}");
            Console.WriteLine($"Total Routes: {totalRoutes}");
            Console.WriteLine($"Daily Passengers: {dailyPassengers}");
            Console.WriteLine($"Fare per km: ₹{farePerKm:F2}");
        }
    }
}
