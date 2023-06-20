namespace _003_Dispsable_DisposePattern_Eaxmple;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Main thread Id is {Thread.CurrentThread.ManagedThreadId}");

        Console.WriteLine("Enter any key to continue.");
        Console.ReadLine();

        for (int i = 0; i < 500000; i++)
        {
            /*using*/ var ex = new Example(i);
        }

        Console.WriteLine("Finished.");
        Console.ReadLine();
    }
}

public class Example : IDisposable
{
    private readonly int _number;
    public Example(int number)
    {
        _number = number;
    }

    ~Example()
    {
        Console.WriteLine($"Number {_number}. Thread Id is {Thread.CurrentThread.ManagedThreadId} I died...");
        Dispose(false);
    }

    private bool disposed = false;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Console.WriteLine("Dispose called");
            }

            disposed = true;
        }
    }
}
