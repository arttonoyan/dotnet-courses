using System;
using System.Collections;
using System.Collections.Generic;

namespace _000_LinkedList_Sample
{
    public class MyLinkedList<T> : ICollection<T>, IReadOnlyCollection<T>, ICollection
    {
        internal MyLinkedListNode<T> head;

        public int Count { get; private set; }
        public MyLinkedListNode<T> First => head;
        public MyLinkedListNode<T> Last
        {
            get { return head == null ? null : head.Previous; }
        }

        bool ICollection<T>.IsReadOnly => false;

        object ICollection.SyncRoot { get; }

        bool ICollection.IsSynchronized => false;

        #region Add Functions
        void ICollection<T>.Add(T value)
        {
            AddLast(value);
        }

        public MyLinkedListNode<T> AddFirst(T value)
        {
            MyLinkedListNode<T> result = new MyLinkedListNode<T>(this, value);
            if (head == null)
            {
                InternalInsertNodeToEmptyList(result);
            }
            else
            {
                InternalInsertNodeBefore(head, result);
                head = result;
            }
            return result;
        }

        public void AddFirst(MyLinkedListNode<T> node)
        {
            if (head == null)
            {
                InternalInsertNodeToEmptyList(node);
            }
            else
            {
                InternalInsertNodeBefore(head, node);
                head = node;
            }
            node.List = this;
        }

        public MyLinkedListNode<T> AddLast(T value)
        {
            var result = new MyLinkedListNode<T>(this, value);
            if (head == null)
            {
                InternalInsertNodeToEmptyList(result);
            }
            else
            {
                InternalInsertNodeBefore(head, result);
            }
            return result;
        }

        public void AddLast(MyLinkedListNode<T> node)
        {
            if (head == null)
            {
                InternalInsertNodeToEmptyList(node);
            }
            else
            {
                InternalInsertNodeBefore(head, node);
            }
            node.List = this;
        }

        public MyLinkedListNode<T> AddAfter(MyLinkedListNode<T> node, T value)
        {
            MyLinkedListNode<T> result = new MyLinkedListNode<T>(node.List, value);
            InternalInsertNodeBefore(node.next, result);
            return result;
        }

        public void AddAfter(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
        {
            InternalInsertNodeBefore(node.next, newNode);
            newNode.List = this;
        }

        public MyLinkedListNode<T> AddBefore(MyLinkedListNode<T> node, T value)
        {
            MyLinkedListNode<T> result = new MyLinkedListNode<T>(node.List, value);
            InternalInsertNodeBefore(node, result);
            if (node == head)
            {
                head = result;
            }
            return result;
        }

        public void AddBefore(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
        {
            InternalInsertNodeBefore(node, newNode);
            newNode.List = this;
            if (node == head)
            {
                head = newNode;
            }
        }

        private void InternalInsertNodeToEmptyList(MyLinkedListNode<T> newNode)
        {
            newNode.next = newNode;
            newNode.prev = newNode;
            head = newNode;
            Count++;
        }

        private void InternalInsertNodeBefore(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;
            node.prev = newNode;
            Count++;
        }
        #endregion

        #region Remove Functions
        public bool Remove(T value)
        {
            MyLinkedListNode<T> node = Find(value);
            if (node != null)
            {
                InternalRemoveNode(node);
                return true;
            }
            return false;
        }

        public void Remove(MyLinkedListNode<T> node)
        {
            InternalRemoveNode(node);
        }

        public void RemoveFirst()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            InternalRemoveNode(head);
        }

        public void RemoveLast()
        {
            if (head == null)
            {
                throw new InvalidOperationException();
            }

            InternalRemoveNode(head.prev);
        }

        internal void InternalRemoveNode(MyLinkedListNode<T> node)
        {
            if (node.next == node)
            {
                head = null;
            }
            else
            {
                node.next.prev = node.prev;
                node.prev.next = node.next;
                if (head == node)
                {
                    head = node.next;
                }
            }
            node.Invalidate();
            Count--;
        }
        #endregion

        #region Find Functions
        public MyLinkedListNode<T> Find(T value)
        {
            MyLinkedListNode<T> node = head;
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            if (node != null)
            {
                if (value != null)
                {
                    do
                    {
                        if (c.Equals(node.Value, value))
                        {
                            return node;
                        }
                        node = node.next;
                    } while (node != head);
                }
                else
                {
                    do
                    {
                        if (node.Value == null)
                        {
                            return node;
                        }
                        node = node.next;
                    } while (node != head);
                }
            }
            return null;
        }

        public MyLinkedListNode<T> FindLast(T value)
        {
            if (head == null) return null;

            MyLinkedListNode<T> last = head.prev;
            MyLinkedListNode<T> node = last;
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            if (node != null)
            {
                if (value != null)
                {
                    do
                    {
                        if (c.Equals(node.Value, value))
                        {
                            return node;
                        }

                        node = node.prev;
                    } while (node != last);
                }
                else
                {
                    do
                    {
                        if (node.Value == null)
                        {
                            return node;
                        }
                        node = node.prev;
                    } while (node != last);
                }
            }
            return null;
        }
        #endregion

        public void Clear()
        {
            MyLinkedListNode<T> current = head;
            while (current != null)
            {
                MyLinkedListNode<T> temp = current;
                current = current.Next;   // use Next the instead of "next", otherwise it will loop forever
                temp.Invalidate();
            }

            head = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (index < 0 || index > array.Length)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (array.Length - index < Count)
            {
                throw new ArgumentException("");
            }

            MyLinkedListNode<T> node = head;
            if (node != null)
            {
                do
                {
                    array[index++] = node.Value;
                    node = node.next;
                } while (node != head);
            }
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (array.Rank != 1)
            {
                throw new ArgumentException("MultiRank");
            }

            if (array.GetLowerBound(0) != 0)
            {
                throw new ArgumentException("Non Zero Lower Bound");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (array.Length - index < Count)
            {
                throw new ArgumentException("");
            }

            T[] tArray = array as T[];
            if (tArray != null)
            {
                CopyTo(tArray, index);
            }
            else
            {
                //
                // Catch the obvious case assignment will fail.
                // We can found all possible problems by doing the check though.
                // For example, if the element type of the Array is derived from T,
                // we can't figure out if we can successfully copy the element beforehand.
                //
                Type targetType = array.GetType().GetElementType();
                Type sourceType = typeof(T);
                if (!(targetType.IsAssignableFrom(sourceType) || sourceType.IsAssignableFrom(targetType)))
                {
                    throw new ArgumentException("Invalid Array Type");
                }

                object[] objects = array as object[];
                if (objects == null)
                {
                    throw new ArgumentException("Invalid Array Type");
                }
                MyLinkedListNode<T> node = head;
                try
                {
                    if (node != null)
                    {
                        do
                        {
                            objects[index++] = node.Value;
                            node = node.next;
                        } while (node != head);
                    }
                }
                catch (ArrayTypeMismatchException)
                {
                    throw new ArgumentException("Invalid Array Type");
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public struct Enumerator : IEnumerator<T>
        {
            private MyLinkedList<T> list;
            private MyLinkedListNode<T> node;
            private int index;

            internal Enumerator(MyLinkedList<T> list)
            {
                this.list = list;
                node = list.head;
                Current = default;
                index = 0;
            }

            public T Current { get; private set; }
            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (node == null)
                {
                    index = list.Count + 1;
                    return false;
                }

                ++index;
                Current = node.Value;
                node = node.next;
                if (node == list.head)
                {
                    node = null;
                }
                return true;
            }

            void IEnumerator.Reset()
            {
                Current = default;
                node = list.head;
                index = 0;
            }

            public void Dispose() { }
        }
    }

}
