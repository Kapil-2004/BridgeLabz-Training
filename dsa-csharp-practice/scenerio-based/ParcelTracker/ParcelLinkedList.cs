using System;

namespace ParcelTracker
{ 
class ParcelLinkedList
{
    private ParcelStage head;

    public bool IsEmpty()
    {
        return head == null;
    }

    public void InsertAtEnd(string stageName)
    {
        ParcelStage newNode = new ParcelStage(stageName);

        if (head == null)
        {
            head = newNode;
            return;
        }

        ParcelStage temp = head;
        while (temp.Next != null)
        {
            temp = temp.Next;
        }
        temp.Next = newNode;
    }

    public bool InsertAfter(string afterStage, string newStage)
    {
        ParcelStage temp = head;

        while (temp != null && temp.StageName != afterStage)
        {
            temp = temp.Next;
        }

        if (temp == null)
            return false;

        ParcelStage node = new ParcelStage(newStage);
        node.Next = temp.Next;
        temp.Next = node;
        return true;
    }

    public void Traverse()
    {
        if (head == null)
        {
            Console.WriteLine("No parcel tracking data available.");
            return;
        }

        ParcelStage temp = head;
        Console.Write("Parcel Tracking Path: ");

        while (temp != null)
        {
            Console.Write(temp.StageName + " -> ");
            temp = temp.Next;
        }

        Console.WriteLine("END");
    }

    public bool BreakAfter(string stageName)
    {
        ParcelStage temp = head;

        while (temp != null && temp.StageName != stageName)
        {
            temp = temp.Next;
        }

        if (temp == null)
            return false;

        temp.Next = null;
        return true;
    }
}
}
