namespace _003_GC_WaitFinalizers;

internal class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 50; i++)
        {
            var ex = new Example();
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();

        for (int i = 0; i < 60; i++)
        {
            Console.Write(".");
        }
    }
}

public class Example
{
    ~Example()
    {
        for (int i = 0; i < 80; i++)
        {
            Console.Write("-");
        }
    }
}
