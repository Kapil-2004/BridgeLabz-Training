using System;

namespace RailwayReservationSystem
{
    class PassengerUtility : IPassenger
    {
        Passenger[] passengers = new Passenger[100];
        int count = 0;
        Random random = new Random();

        public void AddPassenger()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Base Fare: ");
            double fare = double.Parse(Console.ReadLine());

            string category;
            if (age >= 60)
            {
                category = "Senior";
                fare = fare / 2;
            }
            else
            {
                category = "Normal";
            }

            int pnr = random.Next(1000, 9999); 

            passengers[count++] = new Passenger(name, age, pnr, category, fare);
        }

        // Selection Sort by PNR
        public void SortPassenger()
        {
            for (int i = 0; i < count - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < count; j++)
                {
                    if (passengers[j].PNR < passengers[minIndex].PNR)
                        minIndex = j;
                }

                Passenger temp = passengers[minIndex];
                passengers[minIndex] = passengers[i];
                passengers[i] = temp;
            }
        }

        // Binary search To search pnr
        public void SerachPassenger()
        {
            Display();
            Console.WriteLine("Enter PNR Number to serch:");
            int ToSearch = int.Parse(Console.ReadLine());

            SortPassenger();
            int left =0;
            int right = count-1;

            while(left <= right )
            {
                int mid = (left+right)/2;

                if(ToSearch == passengers[mid].PNR)
                {
                    Passenger p = passengers[mid];
                    Console.WriteLine("Passenger Found:");
                    Console.WriteLine("Name: " + p.Name + "  Age: " + p.Age +"  PNR: "+ p.PNR + "  Fare: "+ p.Fare);
                    return;
                }

                else if(ToSearch > passengers[mid].PNR)
                {
                    left = mid+1;
                }
                else
                {
                    right = mid-1;
                }
            }
            Console.WriteLine("Passenger not found.");

        }

        // Display Passenger
        public void Display()
        {
            for (int i=0 ; i<count ; i++)
            {
                Console.WriteLine("Name: " + passengers[i].Name + "  Age: " + passengers[i].Age +"  PNR: "+ passengers[i].PNR + "  Fare: "+ passengers[i].Fare);
            }
        }
    }
}
