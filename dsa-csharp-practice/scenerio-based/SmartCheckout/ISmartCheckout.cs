using System;

namespace SmartCheckout
{
    public interface ISmartCheckout
    {
        void AddCustomer();
        void ServeCustomer();
        void ShowQueue();
    }
}
