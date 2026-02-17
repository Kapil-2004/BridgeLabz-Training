using System;
using System.Collections.Generic;

namespace TechVille.Services
{
    /// <summary>
    /// Module 9: ServicePluginManager
    /// Demonstrates: Plugin architecture using interfaces
    /// Purpose: Dynamically manage and swap service providers at runtime
    /// Shows: Polymorphism through interface contracts
    /// </summary>
    public class ServicePluginManager
    {
        // ===== PRIVATE ATTRIBUTES =====
        private Dictionary<string, ServiceProvider> registeredProviders;
        private Dictionary<string, List<string>> providerCapabilities;

        // ===== CONSTRUCTOR =====
        public ServicePluginManager()
        {
            registeredProviders = new Dictionary<string, ServiceProvider>();
            providerCapabilities = new Dictionary<string, List<string>>();
        }

        // ===== PLUGIN MANAGEMENT =====

        /// <summary>
        /// Register a service provider plugin
        /// </summary>
        public void RegisterProvider(string providerId, ServiceProvider provider)
        {
            if (!registeredProviders.ContainsKey(providerId))
            {
                registeredProviders[providerId] = provider;
                providerCapabilities[providerId] = DetermineCapabilities(provider);
                Console.WriteLine($"✅ Provider Registered: {provider.GetProviderName()}");
            }
            else
            {
                Console.WriteLine($"⚠️ Provider already registered: {providerId}");
            }
        }

        /// <summary>
        /// Unregister a service provider
        /// </summary>
        public void UnregisterProvider(string providerId)
        {
            if (registeredProviders.ContainsKey(providerId))
            {
                registeredProviders.Remove(providerId);
                providerCapabilities.Remove(providerId);
                Console.WriteLine($"✅ Provider Unregistered: {providerId}");
            }
        }

        /// <summary>
        /// Determine what interfaces a provider implements
        /// </summary>
        private List<string> DetermineCapabilities(ServiceProvider provider)
        {
            List<string> capabilities = new List<string>();

            if (provider is IBookable)
                capabilities.Add("Bookable");
            if (provider is ICancellable)
                capabilities.Add("Cancellable");
            if (provider is ITrackable)
                capabilities.Add("Trackable");
            if (provider is IReportable)
                capabilities.Add("Reportable");

            return capabilities;
        }

        // ===== PROVIDER QUERIES =====

        /// <summary>
        /// Get all registered providers
        /// </summary>
        public void DisplayAllProviders()
        {
            Console.WriteLine("\n📋 Registered Service Providers:");
            if (registeredProviders.Count == 0)
            {
                Console.WriteLine("No providers registered.");
                return;
            }

            foreach (var kvp in registeredProviders)
            {
                Console.WriteLine($"\n  • {kvp.Value.GetProviderName()}");
                Console.WriteLine($"    ID: {kvp.Key}");
                Console.WriteLine($"    Status: {(kvp.Value.IsOperational() ? "✅ Online" : "❌ Offline")}");
                Console.WriteLine($"    Rating: {kvp.Value.GetProviderRating():F1}/5.0");
                Console.WriteLine($"    Capabilities: {string.Join(", ", providerCapabilities[kvp.Key])}");
            }
        }

        /// <summary>
        /// Get providers that support a specific capability
        /// </summary>
        public List<ServiceProvider> GetProvidersByCapability(string capability)
        {
            List<ServiceProvider> providers = new List<ServiceProvider>();

            foreach (var kvp in registeredProviders)
            {
                if (providerCapabilities[kvp.Key].Contains(capability))
                {
                    providers.Add(kvp.Value);
                }
            }

            return providers;
        }

        /// <summary>
        /// Get a specific provider by ID
        /// </summary>
        public ServiceProvider GetProvider(string providerId)
        {
            return registeredProviders.ContainsKey(providerId) ? registeredProviders[providerId] : null;
        }

        // ===== POLYMORPHIC OPERATIONS =====

        /// <summary>
        /// Use bookable providers polymorphically
        /// </summary>
        public void BookServiceThroughProvider(string providerId, string citizenName)
        {
            ServiceProvider provider = GetProvider(providerId);
            if (provider == null)
            {
                Console.WriteLine($"❌ Provider not found: {providerId}");
                return;
            }

            if (provider is IBookable bookable)
            {
                Console.WriteLine($"\n📅 Booking with {provider.GetProviderName()}:");
                bookable.BookService(citizenName);
            }
            else
            {
                Console.WriteLine($"❌ Provider {provider.GetProviderName()} does not support bookings");
            }
        }

        /// <summary>
        /// Use cancellable providers polymorphically
        /// </summary>
        public void CancelServiceThroughProvider(string providerId, string bookingId)
        {
            ServiceProvider provider = GetProvider(providerId);
            if (provider == null)
            {
                Console.WriteLine($"❌ Provider not found: {providerId}");
                return;
            }

            if (provider is ICancellable cancellable)
            {
                Console.WriteLine($"\n❌ Cancelling booking with {provider.GetProviderName()}:");
                cancellable.CancelBooking(bookingId);
            }
            else
            {
                Console.WriteLine($"❌ Provider {provider.GetProviderName()} does not support cancellations");
            }
        }

        /// <summary>
        /// Use trackable providers polymorphically
        /// </summary>
        public void TrackServiceThroughProvider(string providerId, string bookingId)
        {
            ServiceProvider provider = GetProvider(providerId);
            if (provider == null)
            {
                Console.WriteLine($"❌ Provider not found: {providerId}");
                return;
            }

            if (provider is ITrackable trackable)
            {
                Console.WriteLine($"\n🔍 Tracking with {provider.GetProviderName()}:");
                string status = trackable.TrackBooking(bookingId);
                Console.WriteLine(status);
            }
            else
            {
                Console.WriteLine($"❌ Provider {provider.GetProviderName()} does not support tracking");
            }
        }

        /// <summary>
        /// Generate reports from reportable providers
        /// </summary>
        public void GenerateReportFromProvider(string providerId)
        {
            ServiceProvider provider = GetProvider(providerId);
            if (provider == null)
            {
                Console.WriteLine($"❌ Provider not found: {providerId}");
                return;
            }

            if (provider is IReportable reportable)
            {
                Console.WriteLine($"\n📊 Report from {provider.GetProviderName()}:");
                Console.WriteLine(reportable.GenerateReport());
                reportable.DisplayStatistics();
            }
            else
            {
                Console.WriteLine($"❌ Provider {provider.GetProviderName()} does not support reporting");
            }
        }

        /// <summary>
        /// Display status of all bookable providers
        /// </summary>
        public void DisplayAllBookableProvidersStatus()
        {
            Console.WriteLine("\n📋 Bookable Service Providers Status:");
            List<ServiceProvider> bookableProviders = GetProvidersByCapability("Bookable");
            
            if (bookableProviders.Count == 0)
            {
                Console.WriteLine("No bookable providers registered.");
                return;
            }

            foreach (var provider in bookableProviders)
            {
                if (provider is ITrackable trackable)
                {
                    Console.WriteLine($"\n✓ {provider.GetProviderName()}");
                    Console.WriteLine($"  Status: {trackable.GetServiceStatus()}");
                }
            }
        }

        /// <summary>
        /// Compare performance of all providers
        /// </summary>
        public void DisplayPerformanceComparison()
        {
            Console.WriteLine("\n⭐ Provider Performance Comparison:");
            if (registeredProviders.Count == 0)
            {
                Console.WriteLine("No providers to compare.");
                return;
            }

            // Sort by rating
            List<ServiceProvider> sortedProviders = new List<ServiceProvider>(registeredProviders.Values);
            sortedProviders.Sort((a, b) => b.GetProviderRating().CompareTo(a.GetProviderRating()));

            foreach (var provider in sortedProviders)
            {
                Console.WriteLine($"\n  {provider.GetProviderName()}");
                Console.WriteLine($"    Rating: {provider.GetProviderRating():F1}/5.0");
                Console.WriteLine($"    Status: {(provider.IsOperational() ? "🟢 Online" : "🔴 Offline")}");
                
                if (provider is ITrackable trackable)
                {
                    trackable.DisplayPerformanceMetrics();
                }
            }
        }
    }
}
