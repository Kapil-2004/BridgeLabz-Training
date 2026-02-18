namespace TechVille.DataStructure
{
    public class DoublyLinkedList
    {
        private class Node
        {
            public string Data;
            public Node Next;
            public Node Prev;

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
                return;
            }

            Node temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = newNode;
            newNode.Prev = temp;
        }

        public void DisplayForward()
        {
            Node temp = head;
            while (temp != null)
            {
                System.Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }
    }
}
