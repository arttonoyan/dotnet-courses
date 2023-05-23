namespace _001_Queue;

internal class Program
{
    static void Main(string[] args)
    {
        //268435456 -> 1GB
        var queue = new Queue<int>();
        for (int i = 0; i < int.MaxValue; i++)
        {
            queue.Enqueue(i);
        }
    }
}
