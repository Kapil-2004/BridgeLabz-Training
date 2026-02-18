namespace TechVille.DataStructure
{
    public class CircularLinkedList
    {
        private class Node
        {
            public string Data;
            public Node Next;

            public Node(string data)
            {
                Data = data;
            }
        }

        private Node head;

        public void Add(string data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                head.Next = head;
                return;
            }

            Node temp = head;
            while (temp.Next != head)
            {
                temp = temp.Next;
            }

            temp.Next = newNode;
            newNode.Next = head;
        }

        public void Display()
        {
            if (head == null) return;

            Node temp = head;
            do
            {
                System.Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
            while (temp != head);
        }
    }
}
