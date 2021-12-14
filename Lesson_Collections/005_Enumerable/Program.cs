using System;
using System.Collections;

namespace _005_Enumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListNode rootNode = new ListNode { value = 10 };
            //rootNode.Add(20);
            //rootNode.Add(30);
            //rootNode.Add(40);

            ListNode rootNode = new ListNode { 10, 20, 30, 40 };

            foreach (var item in rootNode)
            {

            }
        }
    }

    class ListNode : IEnumerable
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

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        private class Enumerator : IEnumerator
        {
            public Enumerator(ListNode root)
            {
                _node = root;
            }

            public object Current { get; private set; }
            private ListNode _node;

            public bool MoveNext()
            {
                if (_node == null)
                    return false;
                _node = null;
                Current = _node.value;
                _node = _node.next;
                return true;
            }

            public void Reset()
            {
                _node = null;
            }
        }
    }
}
