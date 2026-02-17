using System;

namespace TechVille.Services
{
    /// <summary>
    /// Module 8: Routine Service Class
    /// Demonstrates: Inheritance, Method Overriding, Standard Implementation
    /// Routine services follow standard scheduling and procedures
    /// </summary>
    public class RoutineService : Service
    {
        // ===== ROUTINE-SPECIFIC ATTRIBUTES =====
        private string operatingHours;
        private int maxAppointmentsPerDay;
        private int currentAppointments;
        private string serviceCategory;  // Healthcare, Education, Transport, etc.
        private bool requiresAppointment;

        // ===== CONSTRUCTOR =====
        public RoutineService(int serviceId, string serviceName, string description,
                             double budgetAllocated, string operatingHours,
                             int maxAppointmentsPerDay, string serviceCategory,
                             bool requiresAppointment)
            : base(serviceId, serviceName, description, budgetAllocated)
        {
            this.operatingHours = operatingHours;
            this.maxAppointmentsPerDay = maxAppointmentsPerDay;
            this.currentAppointments = 0;
            this.serviceCategory = serviceCategory;
            this.requiresAppointment = requiresAppointment;
        }

        // ===== PUBLIC PROPERTIES =====

        public string OperatingHours
        {
            get { return operatingHours; }
            set { operatingHours = value; }
        }

        public int MaxAppointmentsPerDay
        {
            get { return maxAppointmentsPerDay; }
            set { maxAppointmentsPerDay = value; }
        }

        public int CurrentAppointments
        {
            get { return currentAppointments; }
            set { currentAppointments = value; }
        }

        public string ServiceCategory
        {
            get { return serviceCategory; }
            set { serviceCategory = value; }
        }

        public bool RequiresAppointment
        {
            get { return requiresAppointment; }
            set { requiresAppointment = value; }
        }

        // ===== HELPER METHODS =====

        /// <summary>
        /// Check available slots
        /// </summary>
        public int GetAvailableSlots()
        {
            return maxAppointmentsPerDay - currentAppointments;
        }

        /// <summary>
        /// Check if slots are available
        /// </summary>
        public bool HasAvailableSlots()
        {
            return GetAvailableSlots() > 0;
        }

        // ===== OVERRIDE PROVIDE SERVICE =====

        /// <summary>
        /// Override: Routine service provision with standard procedures
        /// Demonstrates: Specialized implementation
        /// </summary>
        public override void ProvideService(string citizenName)
        {
            Console.WriteLine($"\n📋 ===== ROUTINE SERVICE ===== 📋");
            Console.WriteLine($"Service: {ServiceName}");
            Console.WriteLine($"Category: {serviceCategory}");
            Console.WriteLine($"Citizen: {citizenName}");
            Console.WriteLine($"Operating Hours: {operatingHours}");
            Console.WriteLine($"Requires Appointment: {(requiresAppointment ? "✅ YES" : "❌ NO")}");
            Console.WriteLine($"Available Slots: {GetAvailableSlots()}/{maxAppointmentsPerDay}");
        }

        // ===== OVERRIDE ACTIVATION METHOD =====

        /// <summary>
        /// Override: Activate routine service
        /// Demonstrates: Standard activation with schedule
        /// </summary>
        public override void ActivateService()
        {
            base.ActivateService();
            Console.WriteLine($"   Operating Hours: {operatingHours}");
        }

        // ===== OVERRIDE DISPLAY SERVICE INFO =====

        /// <summary>
        /// Override: Display routine service information
        /// Demonstrates: Method overriding with different details
        /// </summary>
        public override void DisplayServiceInfo()
        {
            base.DisplayServiceInfo();
            Console.WriteLine($"--- Routine Service Details ---");
            Console.WriteLine($"Category: {serviceCategory}");
            Console.WriteLine($"Operating Hours: {operatingHours}");
            Console.WriteLine($"Max Appointments/Day: {maxAppointmentsPerDay}");
            Console.WriteLine($"Current Booked: {currentAppointments}");
            Console.WriteLine($"Available Slots: {GetAvailableSlots()}");
            Console.WriteLine($"Requires Appointment: {(requiresAppointment ? "✅ YES" : "❌ NO")}");
        }

        // ===== OVERRIDE OBJECT METHODS =====

        /// <summary>
        /// Override ToString from Object class
        /// Shows routine-specific format
        /// </summary>
        public override string ToString()
        {
            return $"📋 {ServiceName} ({serviceCategory}) [ID: {ServiceId}, Hours: {operatingHours}, Slots: {GetAvailableSlots()}/{maxAppointmentsPerDay}]";
        }

        // ===== ROUTINE SERVICE-SPECIFIC METHODS =====

        /// <summary>
        /// Book an appointment
        /// Demonstrates: Routine service booking procedure
        /// </summary>
        public bool BookAppointment(string citizenName)
        {
            if (!HasAvailableSlots())
            {
                Console.WriteLine($"❌ No available slots for {ServiceName}!");
                return false;
            }

            currentAppointments++;
            Console.WriteLine($"✅ Appointment booked for {citizenName} at {ServiceName}");
            Console.WriteLine($"   Available slots remaining: {GetAvailableSlots()}");
            return true;
        }

        /// <summary>
        /// Cancel an appointment
        /// </summary>
        public bool CancelAppointment(string citizenName)
        {
            if (currentAppointments > 0)
            {
                currentAppointments--;
                Console.WriteLine($"✅ Appointment cancelled for {citizenName}");
                Console.WriteLine($"   Available slots now: {GetAvailableSlots()}");
                return true;
            }

            Console.WriteLine($"❌ No appointments to cancel!");
            return false;
        }

        /// <summary>
        /// Check service status
        /// </summary>
        public void CheckStatus()
        {
            Console.WriteLine($"\n📊 Status Report: {ServiceName}");
            Console.WriteLine($"Operating Hours: {operatingHours}");
            Console.WriteLine($"Appointments Today: {currentAppointments}/{maxAppointmentsPerDay}");
            Console.WriteLine($"Available Slots: {GetAvailableSlots()}");
            Console.WriteLine($"Occupancy: {((currentAppointments * 100) / maxAppointmentsPerDay):F1}%");
        }
    }
}
