using System;
using System.Collections.Generic;

namespace TechVille.Services
{
    /// <summary>
    /// Module 9: ExternalUtilitiesProvider
    /// Demonstrates: Third interface combination showing polymorphism
    /// Implements: ITrackable, IReportable
    /// Purpose: External utilities provider focused on tracking and reporting
    /// </summary>
    public class ExternalUtilitiesProvider : ServiceProvider, ITrackable
    {
        // ===== PRIVATE ATTRIBUTES =====
        private string utilityType;
        private double monthlyRevenue;
        private int totalConnections;
        private int activeConnections;
        private Dictionary<string, double> connectionMetrics;

        // ===== CONSTRUCTOR =====
        public ExternalUtilitiesProvider(string providerName, double budget, string utilityType)
            : base(providerName, utilityType, budget)
        {
            this.utilityType = utilityType;
            this.monthlyRevenue = 0;
            this.totalConnections = 0;
            this.activeConnections = 0;
            this.connectionMetrics = new Dictionary<string, double>();
        }

        // ===== ITrackable Implementation =====

        public string GetServiceStatus()
        {
            return $"{ProviderName}: {activeConnections} active connections, ₹{monthlyRevenue:F2} revenue";
        }

        public void DisplayPerformanceMetrics()
        {
            Console.WriteLine($"\n📊 Utilities Provider Performance:");
            Console.WriteLine($"Active Connections: {activeConnections}/{totalConnections}");
            Console.WriteLine($"Monthly Revenue: ₹{monthlyRevenue:F2}");
            Console.WriteLine($"Rating: {GetProviderRating():F1}/5.0");
            Console.WriteLine($"Avg Per Unit: ₹{(activeConnections > 0 ? monthlyRevenue / activeConnections : 0):F2}");
        }

        public string TrackBooking(string connectionId)
        {
            if (connectionMetrics.ContainsKey(connectionId))
            {
                return $"✅ Connection Traced: {connectionId} - {utilityType} - Active";
            }
            else
            {
                return $"❌ Connection Not Found: {connectionId}";
            }
        }

        // ===== CUSTOM METHODS FOR UTILITIES =====

        public void AddConnection(string citizenId, double initialReading)
        {
            if (!connectionMetrics.ContainsKey(citizenId))
            {
                connectionMetrics[citizenId] = initialReading;
                totalConnections++;
                activeConnections++;
                LogServiceTransaction($"New {utilityType} connection for {citizenId}");
                UpdateRating(true);
                Console.WriteLine($"✅ {utilityType} connection established!");
            }
        }

        public void RecordBilling(string citizenId, double unitsUsed, double billAmount)
        {
            if (connectionMetrics.ContainsKey(citizenId))
            {
                connectionMetrics[citizenId] += unitsUsed;
                monthlyRevenue += billAmount;
                LogServiceTransaction($"Billing: {citizenId} - {utilityType} - Units: {unitsUsed}, Amount: ₹{billAmount}");
                Console.WriteLine($"✅ Bill recorded - ₹{billAmount:F2}");
            }
        }

        // ===== ABSTRACT METHOD IMPLEMENTATIONS =====

        public override void ProvideService(string citizenName)
        {
            Console.WriteLine($"\n⚡ {utilityType} Service for {citizenName}");
            string connId = $"UTIL{DateTime.Now:HHmmss}";
            AddConnection(connId, 0);
            RecordBilling(connId, 100, 500);
        }

        public override void DisplayDetailedStatus()
        {
            DisplayProviderInfo();
            Console.WriteLine($"\n⚡ Utilities Provider Details:");
            Console.WriteLine($"Utility Type: {utilityType}");
            Console.WriteLine($"Total Connections: {totalConnections}");
            Console.WriteLine($"Active Connections: {activeConnections}");
            Console.WriteLine($"Monthly Revenue: ₹{monthlyRevenue:F2}");
            Console.WriteLine($"Avg Revenue per Connection: ₹{(activeConnections > 0 ? monthlyRevenue / activeConnections : 0):F2}");
        }
    }
}
