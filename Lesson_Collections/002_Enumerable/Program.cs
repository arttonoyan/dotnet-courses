namespace _002_Enumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode rootNode = new ListNode { value = 10 };
            rootNode
                .Add(20)
                .Add(30)
                .Add(40);
        }
    }

    class ListNode
    {
        public int value;
        public ListNode next;

        public ListNode Add(int item)
        {
            next = new ListNode { value = item };
            return next;
        }

        public override string ToString() => $"{value}, next: {next?.value}";
    }
}
