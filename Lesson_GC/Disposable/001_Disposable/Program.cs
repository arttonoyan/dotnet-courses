namespace _001_Disposable;

internal class Program
{
    static void Main(string[] args)
    {
        using var ex = new Example();

        Console.WriteLine("Hi from using");
        throw new Exception();

        Console.WriteLine("Done");

        Console.ReadLine();
    }
}

//public struct Example : IDisposable
public class Example : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Dispose called");
    }
}
