using System;

namespace _003_Enumerable
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

            int max = rootNode.value;

            var node = rootNode.next;
            while (node != null)
            {
                if (node.value > max)
                    max = node.value;

                node = node.next;
            }

            Console.ReadLine();
        }
    }

    class ListNode
    {
        public int value;
        public ListNode next;
        private ListNode _last;

        public ListNode Add(int item)
        {
            if (_last == null)
            {
                next = new ListNode { value = item };
                _last = next;
            }
            else
            {
                _last.next = new ListNode { value = item };
                _last = _last.next;
            }

            return _last;
        }

        public override string ToString() => $"{value}, next: {next?.value}";
    }
}
