using System;

namespace TechVille.Services
{
    /// <summary>
    /// Module 9: IBookable Interface
    /// Demonstrates: Interface defining contract for bookable services
    /// All services that allow booking must implement this interface
    /// </summary>
    public interface IBookable
    {
        /// <summary>
        /// Check if service has available slots
        /// </summary>
        bool HasAvailableSlots();

        /// <summary>
        /// Book a service for a citizen
        /// </summary>
        bool BookService(string citizenName);

        /// <summary>
        /// Get available slots count
        /// </summary>
        int GetAvailableSlots();

        /// <summary>
        /// Get maximum capacity
        /// </summary>
        int GetMaxCapacity();
    }

    /// <summary>
    /// Module 9: ICancellable Interface
    /// Demonstrates: Interface defining contract for cancellable services
    /// All services that allow cancellation must implement this interface
    /// </summary>
    public interface ICancellable
    {
        /// <summary>
        /// Cancel a booking by citizen name
        /// </summary>
        bool CancelBooking(string citizenName);

        /// <summary>
        /// Check if cancellation is allowed
        /// </summary>
        bool IsCancellationAllowed();

        /// <summary>
        /// Get cancellation deadline
        /// </summary>
        int GetCancellationDeadlineHours();
    }

    /// <summary>
    /// Module 9: ITrackable Interface
    /// Demonstrates: Interface defining contract for trackable services
    /// All services that track status must implement this interface
    /// </summary>
    public interface ITrackable
    {
        /// <summary>
        /// Get current service status
        /// </summary>
        string GetServiceStatus();

        /// <summary>
        /// Get service performance metrics
        /// </summary>
        void DisplayPerformanceMetrics();

        /// <summary>
        /// Track a specific booking
        /// </summary>
        string TrackBooking(string citizenName);
    }

    /// <summary>
    /// Module 9: IServiceProvider Interface
    /// Demonstrates: Interface for general service provider contract
    /// All service providers must implement this interface
    /// </summary>
    public interface IServiceProvider
    {
        /// <summary>
        /// Get provider name
        /// </summary>
        string GetProviderName();

        /// <summary>
        /// Check if provider is operational
        /// </summary>
        bool IsOperational();

        /// <summary>
        /// Get provider rating (0-100)
        /// </summary>
        double GetProviderRating();

        /// <summary>
        /// Display provider details
        /// </summary>
        void DisplayProviderInfo();
    }

    /// <summary>
    /// Module 9: IReportable Interface
    /// Demonstrates: Interface for services that can generate reports
    /// Optional contract for advanced tracking
    /// </summary>
    public interface IReportable
    {
        /// <summary>
        /// Generate performance report
        /// </summary>
        string GenerateReport();

        /// <summary>
        /// Export data
        /// </summary>
        void ExportData(string format);

        /// <summary>
        /// Get statistics
        /// </summary>
        void DisplayStatistics();
    }
}
