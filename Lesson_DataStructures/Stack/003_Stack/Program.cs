namespace _003_Stack;

internal class Program
{
    static void Main(string[] args)
    {
        var stack = new MyStack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        stack.Push(40);
        stack.Push(50);

        int value = stack.Pop();
        stack.Push(10);
        stack.Push(10);
        stack.Push(10);
        stack.Push(10);

        Console.WriteLine($"Queue Count: {stack.Count}");
        Console.WriteLine(new string('-', 10));

        int value1 = stack.Peek();
        Console.WriteLine("Peek");
        Console.WriteLine($"value: {value1}, count: {stack.Count}");

        Console.WriteLine(new string('-', 10));

        int value2 = stack.Pop();
        Console.WriteLine("Dequeue");
        Console.WriteLine($"value: {value2}, count: {stack.Count}");

        stack.Push(30);
        stack.Push(-20);
        stack.Push(-30);

        if (stack.Contains(30))
        {

        }

        stack.Push(30);
        stack.TrimExcess();

        stack.Push(555);
        stack.TrimExcess();

        stack.Clear();

        Console.ReadLine();
    }
}
