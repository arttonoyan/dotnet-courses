namespace _001_GC_LargeObjectGen;

internal class Program
{
    static void Main(string[] args)
    {
        //byte[] data = new byte[85];
        byte[] data = new byte[85000];
        //var data = new BigExample();

        var gen = GC.GetGeneration(data);
        Console.WriteLine(gen);

        Console.ReadLine();
    }
}

public class BigExample
{
    // 1000000 byte = 9766 KB = 9.5 MB
    byte[] arr = new byte[10000000];
}

public class Example
{
    ~Example()
    {
        Console.WriteLine("Example died...");
    }
}
