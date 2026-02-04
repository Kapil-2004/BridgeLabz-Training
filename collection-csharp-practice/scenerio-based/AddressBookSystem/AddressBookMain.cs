using System;

namespace AddressBookSystem
{
    public class AddressBookMain
    {
        public void Start()
        {
            // Use AddressBookManagerUtility (Dictionary-based)
            AddressBookManagerUtility manager = new AddressBookManagerUtility();

            // Pass the manager to the existing Menu
            Menu menu = new Menu(manager);

            menu.ShowMenu();
        }
    }
}
