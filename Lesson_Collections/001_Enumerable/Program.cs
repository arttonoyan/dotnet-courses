namespace _001_Enumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode rootNode = new ListNode { value = 10 };
            ListNode node1 = new ListNode { value = 20 };
            rootNode.next = node1;
            ListNode node2 = new ListNode { value = 30 };
            node1.next = node2;
            ListNode node3 = new ListNode { value = 40 };
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
