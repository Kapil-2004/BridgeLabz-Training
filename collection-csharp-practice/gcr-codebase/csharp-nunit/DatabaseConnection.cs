using System;

namespace CSharpNUnit
{
    public class DatabaseConnection
    {
        public bool IsConnected { get; private set; }

        public void Connect()
        {
            IsConnected = true;
            System.Console.WriteLine("Database connected");
        }

        public void Disconnect()
        {
            IsConnected = false;
            System.Console.WriteLine("Database disconnected");
        }

        public string GetConnectionStatus()
        {
            return IsConnected ? "Connected" : "Disconnected";
        }
    }
}
