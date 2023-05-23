namespace _001_Stack;

internal class Program
{
    static void Main(string[] args)
    {
        //268435456 -> 1GB
        var stack = new Stack<int>();
        for (int i = 0; i < int.MaxValue; i++)
        {
            stack.Push(i);
        }
    }
}
