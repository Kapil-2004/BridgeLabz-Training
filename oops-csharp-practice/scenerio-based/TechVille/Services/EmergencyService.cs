using System;

namespace TechVille.Services
{
    /// <summary>
    /// Module 8: Emergency Service Class
    /// Demonstrates: Inheritance, Method Overriding, Specialized Implementation
    /// Emergency services have different procedures than routine services
    /// </summary>
    public class EmergencyService : Service
    {
        // ===== EMERGENCY-SPECIFIC ATTRIBUTES =====
        private int responseTimeMinutes;
        private bool hasAmbulance;
        private bool available24_7;
        private string emergencyType;  // Fire, Medical, Police, etc.

        // ===== CONSTRUCTOR =====
        public EmergencyService(int serviceId, string serviceName, string description,
                               double budgetAllocated, int responseTimeMinutes,
                               bool hasAmbulance, string emergencyType)
            : base(serviceId, serviceName, description, budgetAllocated)
        {
            this.responseTimeMinutes = responseTimeMinutes;
            this.hasAmbulance = hasAmbulance;
            this.available24_7 = true;  // Emergency services always 24/7
            this.emergencyType = emergencyType;
        }

        // ===== PUBLIC PROPERTIES =====

        public int ResponseTimeMinutes
        {
            get { return responseTimeMinutes; }
            set { responseTimeMinutes = value; }
        }

        public bool HasAmbulance
        {
            get { return hasAmbulance; }
            set { hasAmbulance = value; }
        }

        public bool Available24_7
        {
            get { return available24_7; }
        }

        public string EmergencyType
        {
            get { return emergencyType; }
            set { emergencyType = value; }
        }

        // ===== OVERRIDE ACTIVATION METHOD =====

        /// <summary>
        /// Override: Emergency services always active
        /// Demonstrates: Method overriding behavior change
        /// </summary>
        public override void ActivateService()
        {
            base.ActivateService();
            Console.WriteLine($"🚨 {ServiceName} is ALWAYS ACTIVE for {emergencyType} emergencies!");
        }

        /// <summary>
        /// Override: Cannot deactivate emergency service
        /// Demonstrates: Specialized method behavior
        /// </summary>
        public override void DeactivateService()
        {
            Console.WriteLine($"❌ {ServiceName} ({emergencyType}) cannot be deactivated! Emergency services must remain active.");
        }

        // ===== OVERRIDE PROVIDE SERVICE =====

        /// <summary>
        /// Override: Emergency service provision
        /// Demonstrates: Specialized implementation
        /// </summary>
        public override void ProvideService(string citizenName)
        {
            Console.WriteLine($"\n🚨 ===== EMERGENCY SERVICE ===== 🚨");
            Console.WriteLine($"Service: {ServiceName}");
            Console.WriteLine($"Emergency Type: {emergencyType}");
            Console.WriteLine($"Caller: {citizenName}");
            Console.WriteLine($"Response Time: {responseTimeMinutes} minutes");
            Console.WriteLine($"Available 24/7: ✅ YES");
            Console.WriteLine($"Ambulance Equipped: {(hasAmbulance ? "✅ YES" : "❌ NO")}");
        }

        // ===== OVERRIDE DISPLAY SERVICE INFO =====

        /// <summary>
        /// Override: Display emergency service information
        /// Demonstrates: Method overriding with enhanced details
        /// </summary>
        public override void DisplayServiceInfo()
        {
            base.DisplayServiceInfo();
            Console.WriteLine($"--- Emergency Service Details ---");
            Console.WriteLine($"Emergency Type: {emergencyType}");
            Console.WriteLine($"Response Time: {responseTimeMinutes} minutes");
            Console.WriteLine($"Ambulance Available: {(hasAmbulance ? "✅ YES" : "❌ NO")}");
            Console.WriteLine($"Available 24/7: ✅ YES");
        }

        // ===== OVERRIDE OBJECT METHODS =====

        /// <summary>
        /// Override ToString from Object class
        /// Shows emergency-specific format
        /// </summary>
        public override string ToString()
        {
            return $"🚨 {ServiceName} ({emergencyType}) [ID: {ServiceId}, Response: {responseTimeMinutes}min, 24/7: ✅]";
        }

        /// <summary>
        /// Emergency: Respond to call
        /// Demonstrates: Service-specific custom method
        /// </summary>
        public void RespondToEmergencyCall(string location, string severity)
        {
            Console.WriteLine($"\n🚨 Responding to emergency call...");
            Console.WriteLine($"Location: {location}");
            Console.WriteLine($"Severity Level: {severity}");
            Console.WriteLine($"Response Time: Dispatching units in {responseTimeMinutes} minutes");
            Console.WriteLine($"Service Type: {emergencyType}");
        }
    }
}
