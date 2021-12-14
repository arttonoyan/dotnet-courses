using System.Collections;
using System.Collections.Generic;

namespace _006_Enumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 20, 1000, 40 };
            var list = new List<int> { 10, 20, 2, 40 };
            var listNode = new ListNode<int> { 10, 20, 1000, 40 };

            int sum1 = MyMath.Sum(arr);
            int sum2 = MyMath.Sum(list);
            int sum3 = MyMath.Sum(listNode);
        }
    }

    class ListNode<T> : IEnumerable<T>
    {
        public T value;
        public ListNode<T> next;
        private ListNode<T> _last;

        public ListNode<T> Add(T item)
        {
            if (_last == null)
            {
                next = new ListNode<T> { value = item };
                _last = next;
            }
            else
            {
                _last.next = new ListNode<T> { value = item };
                _last = _last.next;
            }

            return _last;
        }

        public override string ToString() => $"{value}, next: {next.value}";

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class Enumerator : IEnumerator<T>
        {
            public Enumerator(ListNode<T> root)
            {
                _node = root;
            }

            public T Current { get; private set; }
            object IEnumerator.Current => Current;
            private ListNode<T> _node;

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

            public void Dispose() => Reset();
        }
    }
}
