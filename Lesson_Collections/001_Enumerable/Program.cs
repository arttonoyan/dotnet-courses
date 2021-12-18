namespace _001_Enumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootNode = new ListNode { value = 10 };
            var node1 = new ListNode { value = 20 };
            rootNode.next = node1;
            var node2 = new ListNode { value = 30 };
            node1.next = node2;
            var node3 = new ListNode { value = 40 };
            node2.next = node3;
        }
    }

    class ListNode
    {
        public int value;
        public ListNode next;

        public override string ToString() => $"{value}, next: {next?.value}";
    }
}
