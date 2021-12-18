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

            //var enumerator = rootNode.GetEnumerator();
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

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        public override string ToString() => $"{value}, next: {next?.value}";

        

        private class Enumerator : IEnumerator
        {
            private ListNode _node;
            public Enumerator(ListNode root)
            {
                _node = root;
            }

            public object Current { get; private set; }

            public bool MoveNext()
            {
                if (_node == null)
                    return false;

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
