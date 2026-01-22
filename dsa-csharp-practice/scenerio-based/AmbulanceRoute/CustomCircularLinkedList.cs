using System;

namespace AmbulanceRoute
{
    public class CustomCircularLinkedList
    {
        private class Node
        {
            public HospitalUnit Data;
            public Node Next;

            public Node(HospitalUnit data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node head;

        public CustomCircularLinkedList()
        {
            head = null;
        }

        public void Add(HospitalUnit unit)
        {
            Node newNode = new Node(unit);

            if (head == null)
            {
                head = newNode;
                head.Next = head;
                return;
            }

            Node temp = head;
            while (temp.Next != head)
                temp = temp.Next;

            temp.Next = newNode;
            newNode.Next = head;
        }

        public void Remove(string unitName)
        {
            if (head == null)
                return;

            Node curr = head;
            Node prev = null;

            do
            {
                if (curr.Data.Name.Equals(unitName, StringComparison.OrdinalIgnoreCase))
                {
                    if (curr == head && curr.Next == head)
                    {
                        head = null;
                        return;
                    }

                    if (curr == head)
                    {
                        Node last = head;
                        while (last.Next != head)
                            last = last.Next;

                        head = head.Next;
                        last.Next = head;
                    }
                    else
                    {
                        prev.Next = curr.Next;
                    }

                    Console.WriteLine("Unit removed: " + unitName);
                    return;
                }

                prev = curr;
                curr = curr.Next;

            } while (curr != head);

            Console.WriteLine("Unit not found.");
        }

        public HospitalUnit FindNextAvailable()
        {
            if (head == null)
                return null;

            Node temp = head;

            do
            {
                if (temp.Data.IsAvailable)
                    return temp.Data;

                temp = temp.Next;

            } while (temp != head);

            return null;
        }

        public void Rotate()
        {
            if (head != null)
                head = head.Next;
        }

        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("No hospital units available.");
                return;
            }

            Node temp = head;

            Console.WriteLine("\nHospital Units:");

            do
            {
                Console.WriteLine(
                    "- " + temp.Data.Name +
                    " | Available: " + temp.Data.IsAvailable
                );

                temp = temp.Next;

            } while (temp != head);
        }
    }
}
