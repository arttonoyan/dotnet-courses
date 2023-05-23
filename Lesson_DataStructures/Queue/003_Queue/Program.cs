namespace _003_Queue;

//https://referencesource.microsoft.com/#System/compmod/system/collections/generic/queue.cs,aa3beab99b2e0db2
internal class Program
{
    static void Main(string[] args)
    {
        var queue = new MyQueue<int>();
        queue.Enqueue(10);
        queue.Enqueue(20);
        queue.Enqueue(30);
        queue.Enqueue(40);
        queue.Enqueue(50);

        queue.Dequeue();
        queue.Enqueue(10);
        queue.Enqueue(10);
        queue.Enqueue(10);
        queue.Enqueue(10);

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

        queue.Enqueue(555);
        queue.TrimExcess();

        Console.ReadLine();
    }
}
