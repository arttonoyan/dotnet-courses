namespace _000_LinkedList_Sample
{
    public sealed class MyLinkedListNode<T>
    {
        internal MyLinkedListNode<T> next;
        internal MyLinkedListNode<T> prev;

        public MyLinkedListNode(T value)
        {
            Value = value;
        }

        internal MyLinkedListNode(MyLinkedList<T> list, T value)
        {
            List = list;
            Value = value;
        }

        public T Value { get; set; }

        public MyLinkedList<T> List { get; internal set; }

        public MyLinkedListNode<T> Next
        {
            get { return next == null || next == List.head ? null : next; }
        }

        public MyLinkedListNode<T> Previous
        {
            get { return prev == null || this == List.head ? null : prev; }
        }

        internal void Invalidate()
        {
            List = null;
            next = null;
            prev = null;
        }
    }

}
