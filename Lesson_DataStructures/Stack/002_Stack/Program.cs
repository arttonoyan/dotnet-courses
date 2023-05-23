namespace _002_Stack;

internal class Program
{
    static void Main(string[] args)
    {
        var stack = new Stack<int>();
        stack.Push(10);
        stack.Push(20);

        Console.WriteLine($"Stack Count: {stack.Count}");
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

        Console.ReadLine();
    }
}
