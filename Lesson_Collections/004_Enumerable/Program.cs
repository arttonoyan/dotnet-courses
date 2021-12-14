using System.Collections;

namespace _004_Enumerable
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

            IEnumerator enumerator = rootNode.GetEnumerator();
            while (enumerator.MoveNext())
            {
                int item = (int)enumerator.Current;
            }
            enumerator.Reset();

            #region Compiler Code Generation

            //IEnumerator enumerator = rootNode.GetEnumerator();
            //try
            //{
            //    while (enumerator.MoveNext())
            //    {
            //        int item = (int)enumerator.Current;
            //    }
            //}
            //finally
            //{
            //    enumerator.Reset();
            //}

            #endregion
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
