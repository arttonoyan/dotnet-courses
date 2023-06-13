namespace _005_GC_Resurrection;

internal class Program
{
    public static Example StaticExample;

    static async Task Main(string[] args)
    {
        for (int i = 0; i < 100000; i++)
        {
            var ex = new Example(i);
        }

        GC.Collect();
        await Task.Delay(1000);

        Console.WriteLine(StaticExample.GetNumber());

        ////////////////////////////////////////////////////////////////////////////////
        StaticExample = null;

        GC.Collect();
        await Task.Delay(1000);

        Console.WriteLine(StaticExample.GetNumber());

        Console.ReadLine();
    }
}

public class Example
{
    private readonly int _number;
    public Example(int number)
    {
        _number = number;
    }

    public int GetNumber()
    {
        return _number;
    }

    ~Example()
    {
        if (_number == 10)
        {
            Console.WriteLine("I died...");
            Program.StaticExample = this;
            GC.ReRegisterForFinalize(this);
        }
    }
}
