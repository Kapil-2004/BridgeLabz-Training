using System;

namespace SmartCheckout
{
    public class SmartCheckoutMenu
    {
        private ISmartCheckout checkoutUtil;

        public SmartCheckoutMenu()
        {
            checkoutUtil = new SmartCheckoutUtility();
        }

        public void ShowMenu()
        {
            int choice;

            do
            {
                Console.WriteLine("\n===== SmartCheckout – Supermarket Billing =====");
                Console.WriteLine("1. Add Customer to Queue");
                Console.WriteLine("2. Serve Customer");
                Console.WriteLine("3. Show Queue");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        checkoutUtil.AddCustomer();
                        break;

                    case 2:
                        checkoutUtil.ServeCustomer();
                        break;

                    case 3:
                        checkoutUtil.ShowQueue();
                        break;

                    case 4:
                        Console.WriteLine("Exiting SmartCheckout...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 4);
        }
    }
}
