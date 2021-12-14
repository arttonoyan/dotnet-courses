using System;
using System.Collections;
using System.Collections.Generic;

namespace _007_Enumerable_IReadOnlyCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var listNode = new ListNode<int> { 10, 20, 1000, 40 };
        }
    }

    class ListNode<T> : IReadOnlyList<T>, IReadOnlyCollection<T>, IEnumerable<T>
    {
        public T value;
        public ListNode<T> next;
        private ListNode<T> _last;

        public int Count { get; private set; }

        public T this[int index]
        {
            get 
            {
                if (index < 0 || index > Count)
                    throw new ArgumentOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')'");

                int i = 0;
                var en = GetEnumerator();
                while (en.MoveNext())
                {
                    if (i == index)
                        return en.Current;
                    i++;
                }

                return default;
            }
        }

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

            Count++;
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
