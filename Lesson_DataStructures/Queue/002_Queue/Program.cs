namespace _002_Queue;

internal class Program
{
    static void Main(string[] args)
    {
        var queue = new Queue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        
        Console.WriteLine($"Queue Count: {queue.Count}");
        Console.WriteLine(new string('-', 10));
        
        int value1 = queue.Peek();
        Console.WriteLine("Peek");
        Console.WriteLine($"value: {value1}, count: {queue.Count}");

        Console.WriteLine(new string('-', 10));

        int value2 = queue.Dequeue();
        Console.WriteLine("Dequeue");
        Console.WriteLine($"value: {value2}, count: {queue.Count}");

        queue.Enqueue(30);
        queue.Enqueue(-20);
        queue.Enqueue(-30);

        if (queue.Contains(30))
        {

        }

        queue.Enqueue(30);
        queue.TrimExcess();

        Console.ReadLine();
    }
}
