namespace _001_LinkedList;

internal class Program
{
    static void Main(string[] args)
    {
        //152867621
        var list = new LinkedList<int>();
        LinkedListNode<int> node = list.AddLast(1);

        LinkedListNode<int> node2 = new LinkedListNode<int>(2);
        list.AddLast(node2);

        for (int i = 0; i < int.MaxValue; i++)
        {
            //list.AddLast(i);
            list.AddFirst(i);
        }
    }
}
