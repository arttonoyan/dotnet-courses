using System;

namespace _000_LinkedList_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(20);
            var node = list.AddLast(30);

            //MyLinkedListNode<int> node = new MyLinkedListNode<int>(list, -1000);
            list.AddAfter(node, -1000);

            foreach (int value in list)
            {
                Console.WriteLine(value);
            }

            MyLinkedListNode<int> node30 = list.Find(30);
            MyLinkedListNode<int> node20 = list.FindLast(20);

            if (list.Contains(30))
            {

            }

            int[] arr = new int[list.Count];
            list.CopyTo(arr, 0);

            Array array = new object[list.Count];
            list.CopyTo(array, 0);

            list.RemoveFirst();
            list.RemoveLast();

            list.Clear();

            Console.ReadLine();
        }
    }
}
