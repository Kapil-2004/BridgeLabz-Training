using System;
using System.Collections;

namespace RailwayReservationSystem
{
    class ReservationMenu
    {
        public void ShowMenu()
        {
            PassengerUtility utility = new PassengerUtility();
            int choice;

            Console.WriteLine("Wlcome to Railway Reservation System");
            do
            {
                Console.WriteLine("\n---- MENU ----");
                Console.WriteLine("1. Add Passenger");
                Console.WriteLine("2. Search Passenger by PNR");
                Console.WriteLine("3. Sort Passenger by PNR");
                Console.WriteLine("4. Display Passenger");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                            utility.AddPassenger();
                            break;
                    case 2:
                            utility.SerachPassenger();
                            break;
                    case 3: 
                            utility.SortPassenger();
                            break;
                    case 4:
                            utility.Display();
                            break;
                    case 0:
                        Console.WriteLine("Thank you for using Railway Reservation System!");
                        break;

                    default:
                            Console.WriteLine("Invalid Choice");
                            break;
                }        
                
            }while(choice !=0 );
        }
    }
}