using System;

namespace AddressBookSystem
{
    public class AddressBookMain
    {
        // Start method called from Program.cs
        public void Start()
        {
            Console.WriteLine("Welcome to Address Book System");

            AddressBookUtility utility = new AddressBookUtility(10); // capacity = 10
            Menu menu = new Menu(utility);
            menu.ShowMenu();
        }
    }
}
