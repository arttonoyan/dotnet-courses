namespace _003_Dispsable_DisposePattern;

//https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose#implement-the-dispose-pattern
internal class Program
{
    static void Main(string[] args)
    {
        var ex = new Example();
        for (int i = 0; i < 10; i++)
        {
            ex.Dispose();
        }

        Console.WriteLine("Done");

        Console.ReadLine();
    }
}

public class Example : IDisposable
{
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
    ~Example()
    {
        Dispose(false);
    }
}
