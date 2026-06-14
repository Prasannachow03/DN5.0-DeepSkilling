namespace DSA
{
    // A Node holds data and points to next node
    public class Node
    {
        public int Data;
        public Node? Next;
    }

    public class SinglyLinkedList
    {
        private Node? head;

        // Add at beginning
        public void Add(int data)
        {
            head = new Node { Data = data, Next = head };
        }

        // Print all nodes
        public void Print()
        {
            var curr = head;
            Console.Write("List: ");
            while (curr != null)
            {
                Console.Write(curr.Data + " -> ");
                curr = curr.Next;
            }
            Console.WriteLine("null");
        }

        // Search for a value
        public bool Search(int val)
        {
            var curr = head;
            while (curr != null)
            {
                if (curr.Data == val) return true;
                curr = curr.Next;
            }
            return false;
        }

        // Delete a value
        public void Delete(int val)
        {
            if (head == null) return;

            // If head itself is the value
            if (head.Data == val)
            {
                head = head.Next;
                Console.WriteLine($"Deleted {val} from list.");
                return;
            }

            var curr = head;
            while (curr.Next != null)
            {
                if (curr.Next.Data == val)
                {
                    curr.Next = curr.Next.Next;
                    Console.WriteLine($"Deleted {val} from list.");
                    return;
                }
                curr = curr.Next;
            }
            Console.WriteLine($"{val} not found in list.");
        }
    }
}