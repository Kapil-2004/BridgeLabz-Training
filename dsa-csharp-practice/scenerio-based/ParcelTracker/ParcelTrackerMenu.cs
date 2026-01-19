using System;

namespace ParcelTracker
{

class ParcelTrackerMenu
{
    private ParcelTrackerUtility tracker = new ParcelTrackerUtility();

    public void ShowMenu()
    {
        int choice;

        do
        {
            Console.WriteLine("\n Parcel Tracker Menu \n");
            Console.WriteLine("1. Add Parcel Stage");
            Console.WriteLine("2. Add Custom Checkpoint");
            Console.WriteLine("3. Track Parcel");
            Console.WriteLine("4. Mark Parcel Lost");
            Console.WriteLine("0. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    tracker.AddParcel();
                    break;

                case 2:
                    tracker.AddCheckpoint();
                    break;

                case 3:
                    tracker.TrackParcel();
                    break;

                case 4:
                    tracker.MarkParcelLost();
                    break;
            }

        } while (choice != 0);
    }
}
}