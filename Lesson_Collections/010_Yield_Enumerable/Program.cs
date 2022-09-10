using System;
using System.Collections;
using System.Collections.Generic;

namespace _010_Yield_Enumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            var listNode = new ListNode<int> { 10, 20, 1000, 40 };
            foreach (int item in listNode)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
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
                value = item;
                _last = this;
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
            var node = this;
            while(node != null)
            {
                yield return node.value;
                node = node.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
