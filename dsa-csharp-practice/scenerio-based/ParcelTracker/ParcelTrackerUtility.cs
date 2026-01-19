using System;

namespace ParcelTracker
{

class ParcelTrackerUtility : IParcelTracker
{
    private ParcelLinkedList list = new ParcelLinkedList();

    public void AddParcel()
    {
        Console.Write("Enter parcel stage name: ");
        string stage = Console.ReadLine();
        list.InsertAtEnd(stage);
    }

    public void AddCheckpoint()
    {
        Console.Write("Enter existing stage: ");
        string after = Console.ReadLine();

        Console.Write("Enter new checkpoint: ");
        string checkpoint = Console.ReadLine();

        if (!list.InsertAfter(after, checkpoint))
        {
            Console.WriteLine("Stage not found.");
        }
    }

    public void TrackParcel()
    {
        list.Traverse();
    }

    public void MarkParcelLost()
    {
        Console.Write("Enter stage after which parcel was lost: ");
        string stage = Console.ReadLine();

        if (!list.BreakAfter(stage))
        {
            Console.WriteLine("Stage not found.");
        }
        else
        {
            Console.WriteLine("Parcel marked as lost after: " + stage);
        }
    }
}
}
