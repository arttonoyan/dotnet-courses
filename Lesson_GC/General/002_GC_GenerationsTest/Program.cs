namespace _002_GC_GenerationsTest;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine($"MaxGeneration number is {GC.MaxGeneration + 1}");

        Example ex = new Example();

        Task.Run(() => PopulateHeapAsync());

        for (int i = 0; i < 50; i++)
        {
            Console.Write($"Object is in {GC.GetGeneration(ex)} generation. ");
            // GC.GetTotalMemory(false)  => without GC.Collect();
            Console.WriteLine($"Heap size is {GC.GetTotalMemory(false) / 1024}");
            await Task.Delay(100);
        }

        Console.WriteLine($"0 generation has been checked {GC.CollectionCount(0)} times");
        Console.WriteLine($"1 generation has been checked {GC.CollectionCount(1)} times");
        Console.WriteLine($"2 generation has been checked {GC.CollectionCount(2)} times");

        Console.ReadLine();
    }

    static async Task PopulateHeapAsync()
    {
        Helper[] helpers = new Helper[1000];

        for (int i = 0; i < helpers.Length; i++)
        {
            helpers[i] = new Helper();
            //var helper = new Helper();
            await Task.Delay(5);
        }
    }
}

public class Example
{
    byte[] arr = new byte[1024]; // 1 KB

    public Example()
    {
        Console.WriteLine("I was born...");
    }
    ~Example()
    {
        Console.WriteLine("I died...");
    }
}

public class Helper
{
    byte[] array = new byte[1024 * 50]; // 50 KB
}
